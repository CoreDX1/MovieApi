import { ChangeEvent, FC, FormEvent } from 'react'
import { UserRequest } from '../../interfaces/User'
import { Box, Button, TextField } from '@mui/material'

type Props = {
    credentials: UserRequest
    setCredentials: (credentials: UserRequest) => void
    handleLogin: (e: FormEvent<HTMLFormElement>) => void
}

export const SignInForm: FC<Props> = ({ credentials, setCredentials, handleLogin }) => (
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
            onChange={(e: ChangeEvent<HTMLInputElement>) => setCredentials({ ...credentials, email: e.target.value })}
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
)
