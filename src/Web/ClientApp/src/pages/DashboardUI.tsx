import { Dashboard } from '../components/Dashboard/Dashboard'
import { Sidebar } from '../components/Sidebar/Sidebar'

export const DashboardUI = () => {
    return (
        <>
            <main className="grid gap-4 p-4 grid-cols-[220px,_1fr] ">
                <Sidebar />
                <Dashboard />
            </main>
        </>
    )
}
