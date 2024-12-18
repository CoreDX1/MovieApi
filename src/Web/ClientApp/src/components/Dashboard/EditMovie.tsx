import { Box, Button, Container, TextField, Typography } from '@mui/material'
import { FC, useEffect, useState } from 'react'
import { MovieResponse } from '../../interfaces/Movie'
import { service } from '../../services/Service'

type EditMovieProps = {
    id: number
    onEdit: (id: number) => Promise<void>
}

export const EditMovie: FC<EditMovieProps> = ({ onEdit, id }) => {
    const [movie, setMovie] = useState<MovieResponse>({} as MovieResponse)

    const handleEdit = async (id: number) => {
        const { data } = await service.Movie.GetById(id)
        setMovie(data)
        onEdit(data.id)
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
                    Edit Movie
                </Typography>
                <Box component="form" noValidate autoComplete="off">
                    <TextField
                        label="Title"
                        name="title"
                        variant="standard"
                        value={movie.title}
                        fullWidth
                        margin="normal"
                        required
                    />
                    <TextField
                        label="Synopsis"
                        name="synopsis"
                        variant="standard"
                        value={movie.synopsis}
                        fullWidth
                        margin="normal"
                        multiline
                        rows={3}
                    />
                    <TextField
                        hiddenLabel
                        name="year"
                        type="number"
                        variant="standard"
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
                        variant="standard"
                        fullWidth
                        margin="normal"
                        required
                    />
                    <TextField label="Género" name="genre" variant="standard" fullWidth margin="normal" />

                    <TextField label="Image URL" name="image" variant="standard" fullWidth margin="normal" />
                    <Button variant="contained" color="primary" fullWidth sx={{ mt: 2 }}>
                        Add Movie
                    </Button>
                </Box>
            </Container>
        </div>
    )
}
