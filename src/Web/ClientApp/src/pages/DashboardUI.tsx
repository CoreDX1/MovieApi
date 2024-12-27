import { useState } from 'react'
import { Dashboard } from '../components/Dashboard/Dashboard'
import { Sidebar } from '../components/Sidebar/Sidebar'
import { User } from '../components/User/User'
import Movie from './Movie'
import Settings from './Settings'

export type View = 'dashboard' | 'movie' | 'user' | 'settings'

export const DashboardUI = () => {
    const [currentView, setCurrentView] = useState<View>('dashboard')
    // Función para cambiar la vista
    const changeView = (view: View) => {
        setCurrentView(view)
    }

    // Mapear las vistas al componente correspondiente
    const views: Record<View, JSX.Element> = {
        dashboard: <Dashboard />,
        movie: <Movie />,
        user: <User />,
        settings: <Settings />,
    }

    return (
        <>
            <main className="grid gap-4 p-4 grid-cols-[220px,_1fr] ">
                <Sidebar changeView={changeView} />
                <div className="bg-white rounded-lg pb-4 shadow">{views[currentView]}</div>
            </main>
        </>
    )
}
