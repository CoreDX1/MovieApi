import { useEffect, useState } from 'react'

import { service } from '../services/Service'
import { MovieResponse } from '../services/MovieServices'
import {
    Box,
    Button,
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography,
} from '@mui/material'
import { Add, Delete } from '@mui/icons-material'

export const Movie = () => {
    const [movies, setMovies] = useState<MovieResponse>({
        status: 0,
        message: '',
        errors: [],
        validationErrors: [],
        data: [],
        location: '',
    })
    const getMovies = async () => {
        const response = await service.Movie.getMovies()
        setMovies(response)
    }

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
                        gap: 1,
                        height: '30px',
                    }}
                >
                    <Button
                        startIcon={<Add />}
                        variant="text"
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
                    <Button
                        startIcon={<Delete />}
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
                                    <TableCell>Delete</TableCell>
                                    <TableCell>Update</TableCell>
                                </TableRow>
                            </TableBody>
                        ))}
                    </Table>
                </TableContainer>
            </Box>
        </Box>
    )
}
