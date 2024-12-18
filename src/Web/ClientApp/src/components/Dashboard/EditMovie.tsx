import { Box, Button, Container, TextField, Typography } from '@mui/material'
import { FC, useEffect, useState } from 'react'
import { MovieResponse } from '../../interfaces/Movie'
import { service } from '../../services/Service'

type Props = {
    id: number
    onEdit: (id: number) => Promise<void>
}

type Form = Omit<MovieResponse, 'id' | 'movieCode'>

export const EditMovie: FC<Props> = ({ onEdit, id }) => {
    const [movie, setMovie] = useState({} as MovieResponse)

    const [formData, setFormData] = useState({} as Form)

    const handleEdit = async (id: number) => {
        const { data } = await service.Movie.GetById(id)
        setMovie(data)
        onEdit(data.id)
    }

    useEffect(() => {
        handleEdit(id)
    }, [id])

    return (
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
                Editar Película
            </Typography>
            <Box component="form" noValidate autoComplete="off">
                <TextField
                    label="Título"
                    name="title"
                    variant="standard"
                    value={movie.title}
                    fullWidth
                    margin="normal"
                    required
                />
                <TextField
                    label="Sinopsis"
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
                    label="Duración (minutos)"
                    name="duration"
                    type="number"
                    value={movie.duration}
                    variant="standard"
                    fullWidth
                    margin="normal"
                    required
                />
                <TextField label="Género" name="genre" variant="standard" fullWidth margin="normal" />
                <TextField label="URL de la imagen" name="image" variant="standard" fullWidth margin="normal" />
                <Button variant="contained" color="primary" fullWidth sx={{ mt: 2 }}>
                    Guardar cambios
                </Button>
            </Box>
        </Container>
    )
}
