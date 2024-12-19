import { useEffect, useState, useReducer } from 'react'
import { service } from '../services/Service'
import { Box, Button, Modal, Typography } from '@mui/material'
import { Add } from '@mui/icons-material'
import { MovieResponse } from '../interfaces/Movie'
import { MoviesTable } from '../components/MoviesTable/MoviesTable'
import { TfiTrash } from 'react-icons/tfi'
import { FilterMovie } from '../services/MovieServices'
import { BiSolidMovie } from 'react-icons/bi'
import { AddMovie } from '../components/Dashboard/AddMovie'

interface State {
    movies: MovieResponse[]
}


const initialState: State = {
    movies: [],
}

type ActionType =
    | { type: 'DELETE'; id: number }
    | { type: 'ADD'; movie: MovieResponse }
    | { type: 'EDIT'; id: number; movie: MovieResponse }
    | { type: 'GET'; movies: MovieResponse[] }
    | { type: 'FILTER'; movies: MovieResponse[] }

interface State {
    movies: MovieResponse[]
}

const reducer = (state: State, action: ActionType) => {
    switch (action.type) {
        case 'GET':
            return { ...state, movies: action.movies }
        case 'DELETE':
            return { ...state, movies: state.movies.filter((movie) => movie.id !== action.id) }
        case 'EDIT':
            return {
                ...state,
                movies: state.movies.map((movie) =>
                    movie.id === action.id ? { ...action.movie, isEdit: true } : movie
                ),
            }
        case 'ADD':
            return { ...state, movies: [...state.movies, action.movie] }
        case 'FILTER':
            return { ...state, movies: action.movies }
    }
}

const Movie = () => {
    const [state, dispatch] = useReducer(reducer, initialState)

    const handleDeleteMovie = async (id: number) => {
        dispatch({ type: 'DELETE', id: id })
    }

    const handleEditMovie = async (id: number) => {
        const { data } = await service.Movie.GetById(id)
        dispatch({ type: 'EDIT', id: id, movie: data })
    }

    const handleAddMovie = async (movie: MovieResponse) => {
        dispatch({ type: 'ADD', movie: movie })
    }

    const getMovies = async () => {
        const { data } = await service.Movie.ListAsnync()
        dispatch({ type: 'GET', movies: data })
    }

    const [open, setOpen] = useState(false)
    const handleOpen = () => setOpen(true)
    const handleClose = () => setOpen(false)

    const handleFilter = async (filter: FilterMovie) => {
        const { data } = await service.Movie.Filter(filter)
        dispatch({ type: 'FILTER', movies: data })
    }

    useEffect(() => {
        getMovies()
    }, [])

    return (
        <Box sx={{ display: 'flex' }} className="col-span-12 p-4 rounded border border-stone-300">
            <Box component="main" sx={{ flexGrow: 1, p: 2 }}>
                <Typography
                    variant="h5"
                    gutterBottom
                    className="col-span-12 p-4 rounded border border-stone-300 flex items-center gap-3"
                >
                    <BiSolidMovie /> Movie List
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
                                <AddMovie onAdd={handleAddMovie} />
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
                    movies={state.movies}
                    onEdit={handleEditMovie}
                    onDelete={handleDeleteMovie}
                    onFilter={handleFilter}
                />
            </Box>
        </Box>
    )
}

export default Movie