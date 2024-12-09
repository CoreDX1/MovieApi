import { Route } from 'wouter'
import { SingIn } from './pages/SingIn'
import { DashboardUI } from './pages/DashboardUI'

function App() {
    return (
        <>
            <Route path="/login" component={SingIn} />
            <Route path="/dashboard" component={DashboardUI} />
        </>
    )
}

export default App
