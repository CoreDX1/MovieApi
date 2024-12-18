import { FC, useEffect, useState } from 'react'
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
    IconButton,
    Button,
    CircularProgress,
    Modal,
    Box,
} from '@mui/material'
import { FiArrowUpRight, FiEdit2 } from 'react-icons/fi'
import { MovieResponse } from '../../interfaces/Movie'
import { Link } from 'wouter'
import { HiChevronUpDown } from 'react-icons/hi2'
import { CiTrash } from 'react-icons/ci'
import { FilterMovie } from '../../services/MovieServices'
import { EditMovie } from '../Dashboard/EditMovie'


type ListOfMovies = MovieResponse[]

interface Props {
    movies: ListOfMovies
    onEdit: (id: number) => Promise<void>
    onDelete: (id: number) => Promise<void>
    onFilter: (filter: FilterMovie) => Promise<void>
}

export const MoviesTable: FC<Props> = ({ movies, onEdit, onDelete, onFilter}) => {
    const headers = [
        { label: 'Id', sortable: true },
        { label: 'Title', sortable: true },
        { label: 'Year', sortable: true },
        { label: 'Duration', sortable: true },
        { label: 'Genre', sortable: true },
        { label: 'Action', sortable: true },
    ]

    const [currentFilter, setCurrentFilter] = useState<FilterMovie>({
        orderBy: 'asc',
        name: '',
    })

    const [Id, setId] = useState(0)

    const [progress, setProgress] = useState(false)
    const [openEdit, setOpenEdit] = useState(false)

    const handleOpenEdit = (id: number) => {
        setOpenEdit(true)
        setId(id)
        onEdit(id)
    }

    const handleCloseEdit = () => setOpenEdit(false)

    useEffect(() => {
        if (progress) {
            // Simulate API call delay, remove this if you have actual API response handling
            setTimeout(() => {
                setProgress(false)
            }, 500) // Adjust delay as needed based on your API response time
        }
    }, [progress])

    const handleSort = (column: string) => {
        // setProgress(true)
        console.log('Movie Table', currentFilter)
        const newOrderBy = currentFilter.orderBy === 'asc' ? 'desc' : 'asc'
        const newFilter: FilterMovie = { orderBy: newOrderBy, name: column }

        setCurrentFilter(newFilter) // Actualiza el estado interno del filtro
        onFilter(newFilter) // Llama a la función del padre con el filtro actualizado
    }

    return (
        <TableContainer component={Paper}>
            <Table aria-label="simple table">
                <TableHead>
                    <TableRow>
                        {headers.map(({ label, sortable }) => (
                            <TableCell key={label} sx={{ padding: '4px' }}>
                                {sortable ? (
                                    <Button
                                        sx={{
                                            color: 'black',
                                            display: 'flex',
                                            width: '100%',
                                            justifyContent: 'space-between',
                                            backgroundColor: 'rgba(0, 0, 0, 0.04)',
                                        }}
                                        onClick={() => handleSort(label.toLowerCase())}
                                    >
                                        {label} <HiChevronUpDown />
                                    </Button>
                                ) : (
                                    label
                                )}
                            </TableCell>
                        ))}
                    </TableRow>
                </TableHead>
                <TableBody>
                    {progress ? (
                        <TableRow>
                            <TableCell colSpan={headers.length} align="center">
                                <CircularProgress />
                            </TableCell>
                        </TableRow>
                    ) : (
                        movies.map((movie) => (
                            <TableRow key={movie.id} sx={{ ':hover': { backgroundColor: 'rgba(0, 0, 0, 0.04)' } }}>
                                <TableCell>{movie.id}</TableCell>
                                <TableCell>
                                    <Link href="#" className="text-violet-600 underline flex items-center gap-1">
                                        {movie.title}
                                        <FiArrowUpRight />
                                    </Link>
                                </TableCell>
                                <TableCell>{movie.year}</TableCell>
                                <TableCell>{movie.duration}</TableCell>
                                <TableCell>{movie.genre}</TableCell>
                                <TableCell>
                                    <div className="flex gap-2 justify-center">
                                        <IconButton
                                            onClick={() => handleOpenEdit(movie.id)}
                                            color="primary"
                                            className="hover:text-blue-500"
                                            sx={{ fontSize: 20 }}
                                        >
                                            <FiEdit2 />
                                        </IconButton>

                                        <IconButton
                                            color="secondary"
                                            className="hover:text-red-500"
                                            onClick={() => onDelete(movie.id)}
                                            sx={{ fontSize: 20 }}
                                        >
                                            <CiTrash />
                                        </IconButton>
                                    </div>
                                </TableCell>
                            </TableRow>
                        ))
                    )}
                </TableBody>
            </Table>
            {openEdit && (
                <Modal open={openEdit} onClose={handleCloseEdit}>
                    <Box id="modal-container">
                        <EditMovie id={Id} onEdit={onEdit} />
                    </Box>
                </Modal>
            )}
        </TableContainer>
    )
}
