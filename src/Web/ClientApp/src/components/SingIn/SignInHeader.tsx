import { Avatar, Typography } from "@mui/material";
import LockOutlinedIcon from '@mui/icons-material/LockOutlined'

export const SignInHeader = () => (
    <>
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
    </>
)