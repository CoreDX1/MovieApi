import { FiArrowUpRight, FiDollarSign, FiMoreHorizontal } from 'react-icons/fi'
import { service } from '../../services/Service'
import { FC, useEffect, useState } from 'react'
import { MovieResponse } from '../../interfaces/Movie'

export const RecentTransactions = () => {
    const [movies, setMovies] = useState<MovieResponse[]>([])

    const getMovies = async () => {
        const { data } = await service.Movie.ListAsnync()

        // Obtener los ultimos 6 elemetos del movies
        setMovies(data.slice(-6).reverse())
    }

    useEffect(() => {
        getMovies()
    }, [])

    return (
        <div className="col-span-12 p-4 rounded border border-stone-300">
            <div className="mb-4 flex items-center justify-between">
                <h3 className="flex items-center gap-1.5 font-medium">
                    <FiDollarSign /> Recent Movies
                </h3>
                <button className="text-sm text-violet-500 hover:underline">See all</button>
            </div>
            <table className="w-full table-auto">
                <TableHead />

                <tbody>
                    {movies.map((movie) => (
                        <TableRow key={movie.id} data={movie} />
                    ))}
                </tbody>
            </table>
        </div>
    )
}

const TableHead = () => {
    return (
        <thead>
            <tr className="text-sm font-normal text-stone-500">
                <th className="text-start p-1.5">Customer ID</th>
                <th className="text-start p-1.5">SKU</th>
                <th className="text-start p-1.5">Date</th>
                <th className="text-start p-1.5">Price</th>
                <th className="w-8"></th>
            </tr>
        </thead>
    )
}

type TableRowProps = {
    data: MovieResponse
}

const TableRow : FC<TableRowProps> = ({ data } ) : JSX.Element => {
    return (
        <tr className="border-b border-stone-300 hover:bg-stone-50 transition-colors">
            <td className="p-1.5">
                <a href="#" className="text-violet-600 underline flex items-center gap-1">
                    {data.id} <FiArrowUpRight />
                </a>
            </td>
            <td className="p-1.5">{data.year}</td>
            <td className="p-1.5">{data.title}</td>
            <td className="p-1.5">{data.duration}</td>
            <td className="p-1.5">{data.genre}</td>
            <td className="w-8">
                <button className="hover:bg-stone-200 transition-colors grid place-content-center rounded text-sm size-8">
                    <FiMoreHorizontal />
                </button>
            </td>
        </tr>
    )
}
