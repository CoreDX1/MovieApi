import { Alert } from '@mui/material'
import { ReactElement } from 'react'

type Props = {
    error: boolean
    onClose: () => void
}

export const SignInAlert: React.FC<Props> = ({ error, onClose }): ReactElement => {
    return (
        <>
            {error && (
                <Alert severity="error" onClose={onClose}>
                    Invalid credentials. Please try again.
                </Alert>
            )}
        </>
    )
}
