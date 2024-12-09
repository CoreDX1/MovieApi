import { MouseEventHandler } from 'react'
import { IconType } from 'react-icons'
import { FiHome } from 'react-icons/fi'
import { MdMovie, MdSettings } from 'react-icons/md'

interface SidebarProps {
    changeView: (view: string) => void
}

export const RouteSelect = ({ changeView }: SidebarProps) => {
    return (
        <div className="space-y-1">
            <Route Icon={FiHome} selected={false} action={() => changeView('dashboard')} title="Dashboard" />
            <Route Icon={MdMovie} selected={true} action={() => changeView('movie')} title="Movies" />
            <Route Icon={MdSettings} selected={false} action={() => changeView('settings')} title="Settings" />
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
