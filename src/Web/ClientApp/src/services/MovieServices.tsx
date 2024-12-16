import ky from 'ky'
import { Result } from '../interfaces/Result'
import { MovieRequest, MovieResponse } from '../interfaces/Movie'

export type FilterMovie = {
    title: string
    orderBy: string
}

export class MovieService {
    private url: string

    constructor(url: string) {
        this.url = url
    }

    public async ListAsnync(): Promise<Result<MovieResponse[]>> {
        const response = await ky.get(`${this.url}`)
        return await response.json()
    }

    public async GetById(id: number): Promise<Result<MovieResponse>> {
        const response = await ky.get(`${this.url}/${id}`)
        return await response.json()
    }

    public async AddMovie(movie: MovieRequest): Promise<Result<MovieResponse>> {
        const response = await ky.post(`${this.url}`, {
            json: movie,
        })
        return await response.json()
    }

    public async Delete(id: number): Promise<Result<MovieResponse>> {
        const response = await ky.delete(`${this.url}/${id}`)
        return await response.json()
    }

    public async Filter(filter: FilterMovie): Promise<Result<MovieResponse[]>> {
        const response = await ky.post(`${this.url}/filter`, {
            json: filter,
        })
        return await response.json()
    }
}
