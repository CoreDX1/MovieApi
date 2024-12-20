import { Container, Paper } from "@mui/material";

export const SignInRoot = ({ children }: { children: React.ReactNode }) => (
    <Container maxWidth="xs">
        <Paper elevation={10} sx={{ marginTop: 8, padding: 2 }}>
            {children}
        </Paper>
    </Container>
)