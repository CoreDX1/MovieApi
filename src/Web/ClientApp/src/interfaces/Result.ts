export interface Result<T> {
    status: number
    message: string
    errors: string[]
    validationErrors: string[]
    data: T
    location: string
}