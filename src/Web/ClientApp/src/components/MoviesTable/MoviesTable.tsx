import { FC } from 'react'
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, IconButton } from '@mui/material'
import { FiEdit2 } from 'react-icons/fi'
import { MovieResponse } from '../../interfaces/Movie'
import { RiDeleteBinLine } from 'react-icons/ri'

interface MoviesTableProps {
    movies: MovieResponse[]
    onEdit: (movieCode: string) => void
    onDelete: (id: number) => Promise<void>
}

export const MoviesTable: FC<MoviesTableProps> = ({ movies, onEdit, onDelete }) => {
    return (
        <TableContainer component={Paper}>
            <Table aria-label="simple table">
                <TableHead>
                    <TableRow sx={{ backgroundColor: 'rgba(0, 0, 0, 0.04)', border: '1px solid rgba(0, 0, 0, 0.12)' }}>
                        <TableCell>Id</TableCell>
                        {/* <TableCell>Imagen</TableCell> */}
                        <TableCell>Title</TableCell>
                        <TableCell>Year</TableCell>
                        <TableCell>Duration</TableCell>
                        <TableCell>Genre</TableCell>
                        <TableCell>Action</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {movies.map((movie) => (
                        <TableRow key={movie.id}>
                            <TableCell>{movie.id}</TableCell>
                            {/* <TableCell>
                            <img src={movie.image} alt="Movie Image" className="w-auto h-20" />
                        </TableCell> */}
                            <TableCell>{movie.title}</TableCell>
                            <TableCell>{movie.year}</TableCell>
                            <TableCell>{movie.duration}</TableCell>
                            <TableCell>{movie.genre}</TableCell>
                            <TableCell>
                                <div className="flex gap-2">
                                    <IconButton
                                        color="primary"
                                        className="hover:text-blue-500"
                                        sx={{ fontSize: 20 }}
                                        onClick={() => onEdit(movie.movieCode)}
                                    >
                                        <FiEdit2 />
                                    </IconButton>
                                    <IconButton
                                        color="secondary"
                                        className="hover:text-red-500"
                                        onClick={() => onDelete(movie.id)}
                                        sx={{ fontSize: 20 }}
                                    >
                                        <RiDeleteBinLine />
                                    </IconButton>
                                </div>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
}
