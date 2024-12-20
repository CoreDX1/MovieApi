import { UserRequest } from '../interfaces/User'
import { service } from '../services/Service'
import { useLocation } from 'wouter'
import { SignInRoot } from '../components/SingIn/SingInRoot'
import { SignInHeader } from '../components/SingIn/SignInHeader'
import { SignInAlert } from '../components/SingIn/SignInAlert'
import { SignInForm } from '../components/SingIn/SignInForm'
import { FormEvent, useState } from 'react'

// Compound Components

// Main Component
export const SignIn = () => {
    const [credentials, setCredentials] = useState<UserRequest>({
        email: '',
        password: '',
    })

    const [error, setError] = useState<boolean>(false)
    const [, setLocation] = useLocation()

    const handleLogin = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        const response = await service.User.UserLogin(credentials)

        if (response.errors.length > 0) {
            setError(true)
        } else {
            setLocation('/dashboard')
        }
    }

    return (
        <SignInRoot>
            <SignInHeader />
            <SignInAlert error={error} onClose={() => setError(false)} />
            <SignInForm credentials={credentials} setCredentials={setCredentials} handleLogin={handleLogin} />
        </SignInRoot>
    )
}
