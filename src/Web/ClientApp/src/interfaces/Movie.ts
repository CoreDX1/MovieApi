
export type MovieRequest = {
    title: string
    synopsis: string
    year: number
    duration: number
    genre: string
    image: string
}

export interface MovieResponse {
    id: number
    title: string
    synopsis: string
    year: number
    duration: number
    genre: string
    image: string
    movieCode: string
}