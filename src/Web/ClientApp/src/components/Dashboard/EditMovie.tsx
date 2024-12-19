import { Box, Button, Container, TextField, Typography } from '@mui/material'
import { ChangeEvent, FC, useEffect, useState } from 'react'
import { MovieResponse } from '../../interfaces/Movie'
import { service } from '../../services/Service'
import { Status } from '../../interfaces/Result'

// Definir el tipo Form simplificado
type Form = Omit<MovieResponse, 'id' | 'movieCode'>

type Props = {
    id: number
    onEdit: (id: number) => Promise<void>
}

export const EditMovie: FC<Props> = ({ onEdit, id }) => {
    const [formData, setFormData] = useState<Form>({
        title: '',
        synopsis: '',
        year: 0,
        duration: 0,
        genre: '',
        image: '',
    })
    const [isSubmitting, setIsSubmitting] = useState(false)

    // Función para cargar los datos de la película
    const loadMovieData = async (id: number) => {
        try {
            const { data } = await service.Movie.GetById(id)
            setFormData({
                title: data.title || '',
                synopsis: data.synopsis || '',
                year: data.year || 0,
                duration: data.duration || 0,
                genre: data.genre || '',
                image: data.image || '',
            })
        } catch (error) {
            console.error('Error loading movie data:', error)
        }
    }

    // Función para enviar los cambios al servidor
    const updateMovie = async () => {
        try {
            setIsSubmitting(true)
            const response = await service.Movie.Edit(id, formData)
            if (response.status === Status.OK) {
                console.log('Movie edited successfully')
                onEdit(id)
            } else {
                console.error('Failed to edit movie:', response)
            }
        } catch (error) {
            console.error('Error updating movie:', error)
        } finally {
            setIsSubmitting(false)
        }
    }

    // Manejar cambios en los campos del formulario
    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target
        setFormData((prev) => ({
            ...prev,
            [name]: name === 'year' || name === 'duration' ? +value : value, // Convertir números si es necesario
        }))
    }

    // Cargar datos al montar el componente o cuando cambia el id
    useEffect(() => {
        loadMovieData(id)
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
            <Box component="form" noValidate autoComplete="off" onSubmit={(e) => e.preventDefault()}>
                {/** Campos del formulario **/}
                <TextField
                    label="Título"
                    name="title"
                    variant="standard"
                    value={formData.title}
                    onChange={handleChange}
                    fullWidth
                    margin="normal"
                    required
                />
                <TextField
                    label="Sinopsis"
                    name="synopsis"
                    variant="standard"
                    value={formData.synopsis}
                    onChange={handleChange}
                    fullWidth
                    margin="normal"
                    multiline
                    rows={3}
                />
                <TextField
                    label="Año"
                    name="year"
                    type="number"
                    variant="standard"
                    value={formData.year}
                    onChange={handleChange}
                    fullWidth
                    margin="normal"
                    required
                />
                <TextField
                    label="Duración (minutos)"
                    name="duration"
                    type="number"
                    value={formData.duration}
                    onChange={handleChange}
                    variant="standard"
                    fullWidth
                    margin="normal"
                    required
                />
                <TextField
                    label="Género"
                    name="genre"
                    variant="standard"
                    value={formData.genre}
                    onChange={handleChange}
                    fullWidth
                    margin="normal"
                />
                <TextField
                    label="URL de la imagen"
                    name="image"
                    variant="standard"
                    value={formData.image}
                    onChange={handleChange}
                    fullWidth
                    margin="normal"
                />
                <Button
                    variant="contained"
                    color="primary"
                    fullWidth
                    sx={{ mt: 2 }}
                    onClick={updateMovie}
                    disabled={isSubmitting}
                >
                    {isSubmitting ? 'Guardando...' : 'Guardar cambios'}
                </Button>
            </Box>
        </Container>
    )
}
