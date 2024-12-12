import { Box, Button, Container, MenuItem, TextField, Typography } from '@mui/material'
import { useState } from 'react'
import { MovieRequest } from '../../interfaces/Movie'
import { service } from '../../services/Service'

export const AddMovie = () => {
    const [form, setForm] = useState<MovieRequest>({
        title: '',
        synopsis: '',
        year: 1,
        duration: 1,
        genre: '',
        image: '',
    })

    const genres = ['Action', 'Comedy', 'Drama', 'Horror', 'Sci-Fi', 'Romance'] // Ejemplo de géneros

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target
        setForm({ ...form, [name]: value })
    }

    const handleSubmit = async () => {
        console.log(form)
        const response = await service.Movie.AddMovie(form)
        console.log(response)
    }

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
                    Add New Movie
                </Typography>
                <Box component="form" noValidate autoComplete="off">
                    <TextField
                        label="Title"
                        name="title"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        required
                        value={form.title}
                        onChange={handleChange}
                    />
                    <TextField
                        label="Synopsis"
                        name="synopsis"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        multiline
                        rows={3}
                        value={form.synopsis}
                        onChange={handleChange}
                    />
                    <TextField
                        label="Year"
                        name="year"
                        type="number"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        required
                        value={form.year}
                        onChange={handleChange}
                    />
                    <TextField
                        label="Duration (minutes)"
                        name="duration"
                        type="number"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        required
                        value={form.duration}
                        onChange={handleChange}
                    />
                    <TextField
                        select
                        label="Género"
                        name="genre"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        value={form.genre}
                        onChange={handleChange}
                    >
                        {genres.map((genre, index) => (
                            <MenuItem key={index} value={genre}>
                                {genre}
                            </MenuItem>
                        ))}
                    </TextField>
                    <TextField
                        label="Image URL"
                        name="image"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        value={form.image}
                        onChange={handleChange}
                    />
                    <Button variant="contained" color="primary" fullWidth sx={{ mt: 2 }} onClick={handleSubmit}>
                        Add Movie
                    </Button>
                </Box>
            </Container>
        </div>
    )
}