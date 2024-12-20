import { Route } from 'wouter'
import { DashboardUI } from './pages/DashboardUI'
import { SignIn } from './pages/SingIn'

function App() {
    return (
        <>
            <Route path="/login" component={SignIn} />
            <Route path="/dashboard" component={DashboardUI} />
        </>
    )
}

export default App
