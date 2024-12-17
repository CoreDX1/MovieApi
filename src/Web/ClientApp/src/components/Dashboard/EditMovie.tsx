import { Box, Button, Container, MenuItem, TextField, Typography } from '@mui/material'
import { FC, useEffect, useState } from 'react'
import { MovieResponse } from '../../interfaces/Movie'
import { service } from '../../services/Service'

type EditMovieProps = {
    id: number
}

export const EditMovie: FC<EditMovieProps> = ({ id }) => {
    const genres = ['Action', 'Comedy', 'Drama', 'Horror', 'Sci-Fi', 'Romance'] // Ejemplo de géneros


    const [movie, setMovie] = useState<MovieResponse>({} as MovieResponse)

    const handleEdit = async (id: number) => {
        const response = await service.Movie.GetById(id)
        setMovie(response.data)
    }

    useEffect(() => {
        handleEdit(id)
    }, [])

    return (
        <div>
            <Container
                sx={{
                    position: 'absolute',
                    top: '50%',
                    left: '50%',
                    transform: 'translate(-50%, -50%)',
                    backgroundColor: '#fff',
                    padding: 4,
                    borderRadius: 2,
                    boxShadow: 3,
                    width: '400px',
                }}
            >
                <Typography variant="h6" gutterBottom>
                    Edit Movie {id}
                </Typography>
                <Box component="form" noValidate autoComplete="off">
                    <TextField
                        label="Title"
                        name="title"
                        variant="outlined"
                        value={movie.title}
                        fullWidth
                        margin="normal"
                        required
                    />
                    <TextField
                        label="Synopsis"
                        name="synopsis"
                        variant="outlined"
                        value={movie.synopsis}
                        fullWidth
                        margin="normal"
                        multiline
                        rows={3}
                    />
                    <TextField
                        label="Year"
                        name="year"
                        type="number"
                        variant="outlined"
                        value={movie.year}
                        fullWidth
                        margin="normal"
                        required
                    />
                    <TextField
                        label="Duration (minutes)"
                        name="duration"
                        type="number"
                        value={movie.duration}
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        required
                    />
                    <TextField
                        select
                        label="Género"
                        name="genre"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        value={movie.genre}
                    >
                        {genres.map((genre, index) => (
                            <MenuItem key={index} value={genre}>
                                {genre}
                            </MenuItem>
                        ))}
                    </TextField>
                    <TextField label="Image URL" name="image" variant="outlined" fullWidth margin="normal" />
                    <Button variant="contained" color="primary" fullWidth sx={{ mt: 2 }}>
                        Add Movie
                    </Button>
                </Box>
            </Container>
        </div>
    )
}
