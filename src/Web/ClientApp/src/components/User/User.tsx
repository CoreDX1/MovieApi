import { Box, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from '@mui/material'
import { UserResponse } from '../../interfaces/User'
import { Result } from '../../interfaces/Result'
import { service } from '../../services/Service'
import { useEffect, useState } from 'react'

export const User = () => {
    const [users, setUsers] = useState<Result<UserResponse[]>>({
        status: 0,
        message: '',
        errors: [],
        validationErrors: [],
        data: [],
        location: '',
    })

    const handleGetUsers = async () => {
        const response = await service.User.ListAsnync()
        setUsers(response)
    }
    useEffect(() => {
        handleGetUsers()
    }, [])

    return (
        <Box>
            <Typography variant="h5" gutterBottom sx={{ textAlign: 'center' }}>
                User List
            </Typography>
            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Id</TableCell>
                            <TableCell>Name</TableCell>
                            <TableCell>Email</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {users.data.map((user) => (
                            <TableRow key={user.id}>
                                <TableCell>{user.id}</TableCell>
                                <TableCell>{user.name}</TableCell>
                                <TableCell>{user.email}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </Box>
    )
}
