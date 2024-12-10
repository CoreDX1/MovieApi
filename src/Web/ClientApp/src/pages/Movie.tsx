
import { useEffect, useState } from 'react'

import { service } from '../services/Service'
import { MovieResponse } from '../services/MovieServices'
import {
    Box,
    Button,
    IconButton,
    Modal,
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography,
} from '@mui/material'
import { Add, DeleteOutline } from '@mui/icons-material'
import { FiEdit2 } from 'react-icons/fi'
import { RiDeleteBinLine } from 'react-icons/ri'
import { AddMovie } from '../components/Dashboard/AddMovie'

export const Movie = () => {


    const [movies, setMovies] = useState<MovieResponse>({
        status: 0,
        message: '',
        errors: [],
        validationErrors: [],
        data: [],
        location: ''
    })
    const getMovies = async () => {
        const response = await service.Movie.getMovies()
        setMovies(response)
    }

    const [open, setOpen] = useState(false)
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    useEffect(() => {
        getMovies()
    }, [])

    return (
        <Box sx={{ display: 'flex' }}>
            <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
                <Typography variant="h5" gutterBottom>
                    Product List
                </Typography>
                <Box
                    sx={{
                        display: 'flex',
                        gap: 2,
                        height: '35px',
                    }}
                >
                    <Button
                        startIcon={<Add />}
                        variant="text"
                        onClick={() => handleOpen()}
                        sx={{
                            backgroundColor: 'rgba(0, 255, 31, 0.15)', // Cambia el fondo al blanco
                            borderStyle: 'solid',
                            borderWidth: '1px',
                            borderColor: 'rgb(0, 255, 20)',
                            color: 'rgb(0, 255, 35)',
                            '&:hover': {
                                backgroundColor: 'rgba(0, 0, 0, 0.04)', // Añade un fondo semitransparente al pasar el mouse
                            },
                        }}
                    >
                        Add
                    </Button>
                    {open && (
                        <Modal open={open} onClose={handleClose}>
                            <AddMovie />
                        </Modal>
                    )}
                    <Button
                        startIcon={<DeleteOutline />}
                        variant="text"
                        sx={{
                            backgroundColor: 'rgba(255, 0, 0, 0.15)', // Cambia el fondo al blanco
                            borderStyle: 'solid',
                            borderWidth: '1px',
                            borderColor: 'rgb(255, 0, 20)',
                            color: 'rgb(255, 0, 0)',
                            '&:hover': {
                                backgroundColor: 'rgba(0, 0, 0, 0.04)', // Añade un fondo semitransparente al pasar el mouse
                            },
                        }}
                    >
                        Delete
                    </Button>
                </Box>

                <TableContainer component={Paper}>
                    <Table arial-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell>ID</TableCell>
                                <TableCell>Title</TableCell>
                                <TableCell>Year</TableCell>
                                <TableCell>Duration</TableCell>
                                <TableCell>Genre</TableCell>
                                <TableCell>Action</TableCell>
                            </TableRow>
                        </TableHead>

                        {movies.data.map((movie) => (
                            <TableBody key={movie.id}>
                                <TableRow>
                                    <TableCell>{movie.id}</TableCell>
                                    <TableCell>{movie.title}</TableCell>
                                    <TableCell>{movie.year}</TableCell>
                                    <TableCell>{movie.duration}</TableCell>
                                    <TableCell>{movie.genre}</TableCell>
                                    <TableCell>
                                        <div className="flex gap-2">
                                            <IconButton
                                                color="primary"
                                                className="hover:text-blue-500"

                                                sx={{ fontSize: 20 }}
                                            >
                                                <FiEdit2 />
                                            </IconButton>
                                            <IconButton
                                                color="secondary"
                                                className="hover:text-red-500"
                                                onClick={() => console.log(movie.movieCode)}
                                                sx={{ fontSize: 20 }}
                                            >
                                                <RiDeleteBinLine />
                                            </IconButton>
                                        </div>
                                    </TableCell>
                                </TableRow>
                            </TableBody>
                        ))}
                    </Table>
                </TableContainer>
            </Box>
        </Box>
    )
}
