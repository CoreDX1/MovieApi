import { Box, Button, Container, MenuItem, TextField, Typography } from '@mui/material'
import { FC } from 'react'

type EditMovieProps = {
    id : number
}

export const EditMovie: FC<EditMovieProps> = ({id}) => {
    const genres = ['Action', 'Comedy', 'Drama', 'Horror', 'Sci-Fi', 'Romance'] // Ejemplo de géneros

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
                    <TextField label="Title" name="title" variant="outlined" fullWidth margin="normal" required />
                    <TextField
                        label="Synopsis"
                        name="synopsis"
                        variant="outlined"
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
                        fullWidth
                        margin="normal"
                        required
                    />
                    <TextField
                        label="Duration (minutes)"
                        name="duration"
                        type="number"
                        variant="outlined"
                        fullWidth
                        margin="normal"
                        required
                    />
                    <TextField select label="Género" name="genre" variant="outlined" fullWidth margin="normal">
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
