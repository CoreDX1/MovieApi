import { Alert, Avatar, Box, Button, Container, Paper, TextField, Typography } from '@mui/material'
import LockOutlinedIcon from '@mui/icons-material/LockOutlined'
import { ChangeEvent, FormEvent, useState } from 'react'
import { UserRequest } from '../interfaces/User'
import { service } from '../services/Service'
import { useLocation } from 'wouter'

export const SingIn = () => {
    const [credentials, setCredentials] = useState<UserRequest>({
        email: '',
        password: '',
    })

    const [error, setError] = useState<boolean>(false)

    const [, setLocation] = useLocation()

    // Hora voy a hacer login

    const handleLogin = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        const response = await service.User.UserLogin(credentials)

        console.log(response.errors.length > 0)

        if (response.errors.length > 0) {
            setError(true)
        } else {
            setLocation('/dashboard')
        }
    }

    return (
        <Container maxWidth="xs">
            <Paper elevation={10} sx={{ marginTop: 8, padding: 2 }}>
                <Avatar
                    sx={{
                        mx: 'auto',
                        bgcolor: 'secondary.main',
                        textAlign: 'center',
                        mb: 1,
                    }}
                >
                    <LockOutlinedIcon />
                </Avatar>
                <Typography component="h1" variant="h5" sx={{ textAlign: 'center' }}>
                    Sign In
                </Typography>

                {error && (
                    <Alert severity="warning" onClose={() => setError(false)}>
                        This Alert displays the default close icon.
                    </Alert>
                )}

                <Box
                    component="form"
                    noValidate
                    onSubmit={handleLogin}
                    sx={{
                        mt: 2,
                    }}
                >
                    <TextField
                        label="Email"
                        type="email"
                        variant="outlined"
                        fullWidth
                        sx={{ mt: 2 }}
                        value={credentials.email}
                        onChange={(e: ChangeEvent<HTMLInputElement>) =>
                            setCredentials({ ...credentials, email: e.target.value })
                        }
                        required
                    />
                    <TextField
                        label="Password"
                        type="password"
                        fullWidth
                        variant="outlined"
                        sx={{ mt: 2 }}
                        value={credentials.password}
                        onChange={(e: ChangeEvent<HTMLInputElement>) =>
                            setCredentials({ ...credentials, password: e.target.value })
                        }
                        required
                    />
                    <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
                        Sign In
                    </Button>
                </Box>
            </Paper>
        </Container>
    )
}
