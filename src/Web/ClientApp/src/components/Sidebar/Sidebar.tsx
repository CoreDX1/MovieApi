import { AccountToggle } from './AccountToggle'
import { Search } from './Search'
import { RouteSelect } from './RouteSelect'
import { Plan } from './Plan'

interface SidebarProps {
    changeView: (view: string) => void
}

export const Sidebar = ({ changeView }: SidebarProps) => {
    return (
        <div>
            <div className="overflow-y-scroll sticky top-4 h-[calc(100vh-32px-48px)]">
                <AccountToggle />
                <Search />
                <RouteSelect changeView={changeView} />
            </div>
            <Plan />
        </div>
    )
}
