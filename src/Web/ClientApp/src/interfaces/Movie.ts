export type MovieRequest = {
    title: string
    synopsis: string
    year: number
    duration: number
    genre: string
    image: string
}

export type MovieEditDto = {
    title: string
    synopsis: string
    year: number
    duration: number
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
