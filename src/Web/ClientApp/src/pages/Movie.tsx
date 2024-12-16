import { useEffect, useState } from 'react'
import { service } from '../services/Service'
import { Box, Button, Modal, Typography } from '@mui/material'
import { Add } from '@mui/icons-material'
import { AddMovie } from '../components/Dashboard/AddMovie'
import { Result } from '../interfaces/Result'
import { MovieResponse } from '../interfaces/Movie'
import { MoviesTable } from '../components/MoviesTable/MoviesTable'
import { TfiTrash } from 'react-icons/tfi'
import { FilterMovie } from '../services/MovieServices'

export const Movie = () => {
    const [movies, setMovies] = useState<Result<MovieResponse[]>>({
        status: 0,
        message: '',
        errors: [],
        validationErrors: [],
        data: [],
        location: '',
    })


    const getMovies = async () => {
        const response = await service.Movie.ListAsnync()
        setMovies(response)
    }

    const [open, setOpen] = useState(false)
    const handleOpen = () => setOpen(true)
    const handleClose = () => setOpen(false)

    const handleDeleteProduct = async (id: number) => {
        await service.Movie.Delete(id)
    }

    const handleFilter = async (filter: FilterMovie) => {
        const response = await service.Movie.Filter(filter)
        setMovies(response)
    }

    useEffect(() => {
        getMovies()
    }, [])

    return (
        <Box sx={{ display: 'flex' }} className="col-span-12 p-4 rounded border border-stone-300">
            <Box component="main" sx={{ flexGrow: 1, p: 2 }}>
                <Typography variant="h5" gutterBottom className="col-span-12 p-4 rounded border border-stone-300">
                    Product List
                </Typography>
                <Box
                    sx={{
                        display: 'flex',
                        gap: 1,
                        marginBottom: '10px',
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
                            <Box id="modal-container">
                                <AddMovie />
                            </Box>
                        </Modal>
                    )}
                    <Button
                        startIcon={<TfiTrash />}
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

                <MoviesTable
                    movies={movies.data}
                    onEdit={(id) => console.log('Edit movie', id)}
                    onDelete={handleDeleteProduct}
                    onFilter={handleFilter}
                />
            </Box>
        </Box>
    )
}
