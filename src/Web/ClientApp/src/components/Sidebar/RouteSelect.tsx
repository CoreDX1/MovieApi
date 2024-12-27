import { MouseEventHandler } from 'react'
import { IconType } from 'react-icons'
import { FiHome } from 'react-icons/fi'
import { MdMovie, MdSettings } from 'react-icons/md'
import { View } from '../../pages/DashboardUI'

interface SidebarProps {
    changeView: (view: View) => void
}

const routes = [
    {
        Title: 'Dashboard',
        View: 'dashboard',
        Selected: false,
        Icon: FiHome,
    },
    {
        Title: 'Users',
        View: 'user',
        Selected: false,
        Icon: MdSettings,
    },
    {
        Title: 'Movies',
        View: 'movie',
        Selected: true,
        Icon: MdMovie,
    },
    {
        Title: 'Settings',
        View: 'settings',
        Selected: false,
        Icon: MdSettings,
    },
]

export const RouteSelect = ({ changeView }: SidebarProps) => {
    return (
        <div className="space-y-1">
            {routes.map((route, index) => {
                return (
                    <Route
                        key={index}
                        Icon={route.Icon}
                        selected={route.Selected}
                        action={() => changeView(route.View as View)}
                        title={route.Title}
                    ></Route>
                )
            })}
        </div>
    )
}

type RouteProps = {
    selected: boolean
    Icon: IconType
    title: string
    action: MouseEventHandler<HTMLButtonElement>
}

const Route = ({ selected, Icon, title, action }: RouteProps) => {
    return (
        <button
            className={`flex items-center justify-start gap-2 w-full rounded px-2 py-1.5 text-sm transition-[box-shadow,_background-color,_color] ${
                selected
                    ? 'bg-white text-stone-950 shadow'
                    : 'hover:bg-stone-200 bg-transparent text-stone-500 shadow-none'
            }`}
            onClick={action}
        >
            <Icon className={selected ? 'text-violet-500' : ''} />
            <span>{title}</span>
        </button>
    )
}
