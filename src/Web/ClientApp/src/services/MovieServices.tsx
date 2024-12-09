import ky from 'ky'

export interface MovieResponse {
    status: number
    message: string
    errors: string[]
    validationErrors: string[]
    data: Data[]
    location: string
}

export interface Data {
    id: number
    title: string
    synopsis: string
    year: number
    duration: number
    genre: string
    image: string
    movieCode: string
}

export class MovieService {
    private url: string

    constructor(url: string) {
        this.url = url
    }

    public async getMovies(): Promise<MovieResponse> {
        const response = await ky.get(`${this.url}`)
        return await response.json()
    }
}
