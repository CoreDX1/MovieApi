import { useEffect, useState } from 'react'

import { service } from '../services/Service'
import { MovieResponse } from '../services/MovieServices'
import { TableHead } from '@mui/material'
import { FiArrowUpRight, FiMoreHorizontal } from 'react-icons/fi'
import { MdMovie } from 'react-icons/md'

export const Movie = () => {
    const [movies, setMovies] = useState<MovieResponse>({
        status: 0,
        message: '',
        errors: [],
        validationErrors: [],
        data: [],
        location: '',
    })
    const getMovies = async () => {
        const response = await service.Movie.getMovies()
        setMovies(response)
    }

    useEffect(() => {
        getMovies()
    }, [])

    return (
        <div className="col-span-12 p-4 rounded border border-stone-300">
            <div className="mb-4 flex items-center justify-between">
                <h3 className="flex items-center gap-1.5 font-medium">{<MdMovie />} Movies</h3>
                <button className="text-sm text-violet-500 hover:underline">See all</button>
            </div>
            <table className="w-full table-auto">
                <TableHead />

                <tbody>
                    {movies.data.map((movie) => (
                        <TableRow
                            id={movie.id}
                            title={movie.title}
                            year={movie.year}
                            duration={movie.duration}
                            genre={movie.genre}
                        />
                    ))}
                </tbody>
            </table>
        </div>
    )
}

type TableHeadProps = {
    id: number
    title: string
    year: number
    duration: number
    genre: string
}

const TableRow = ({ id, title, year, duration, genre }: TableHeadProps) => {
    return (
        <tr>
            <td className="p-1.5">
                <a href="#" className="text-violet-600 underline flex items-center gap-1">
                    {id} <FiArrowUpRight />
                </a>
            </td>
            <td className="p-1.5">{title}</td>
            <td className="p-1.5">{year}</td>
            <td className="p-1.5">{duration}</td>
            <td className="p-1.5">{genre}</td>
            <td className="w-8">
                <button className="hover:bg-stone-200 transition-colors grid place-content-center rounded text-sm size-8">
                    <FiMoreHorizontal />
                </button>
            </td>
        </tr>
    )
}
