import { FC } from 'react'
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
} from '@mui/material'
import { FiArrowUpRight, FiEdit2 } from 'react-icons/fi'
import { MovieResponse } from '../../interfaces/Movie'
import { Link } from 'wouter'
import { HiChevronUpDown } from 'react-icons/hi2'
import { CiTrash } from 'react-icons/ci'

interface MoviesTableProps {
    movies: MovieResponse[]
    onEdit: (movieCode: string) => void
    onDelete: (id: number) => Promise<void>
}

export const MoviesTable: FC<MoviesTableProps> = ({ movies, onEdit, onDelete }) => {
    const headers = [
        { label: 'Id', sortable: true },
        { label: 'Title', sortable: true },
        { label: 'Year', sortable: true },
        { label: 'Duration', sortable: true },
        { label: 'Genre', sortable: true },
        { label: 'Action', sortable: true },
    ]

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
                                        onClick={() => console.log('sort')}
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
                    {movies.map((movie) => (
                        <TableRow key={movie.id} sx={{ ':hover': { backgroundColor: 'rgba(0, 0, 0, 0.04)' } }}>
                            <TableCell>{movie.id}</TableCell>
                            {/* <TableCell>
                            <img src={movie.image} alt="Movie Image" className="w-auto h-20" />
                        </TableCell> */}
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
                                        color="primary"
                                        className="hover:text-blue-500"
                                        sx={{ fontSize: 20 }}
                                        onClick={() => onEdit(movie.movieCode)}
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
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
}
