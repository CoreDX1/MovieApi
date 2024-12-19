import ky from 'ky'
import { UserRequest, UserResponse } from '../interfaces/User'
import { Result } from '../interfaces/Result'

export class User {
    private url: string

    constructor(url: string) {
        this.url = url
    }

    public async ListAsnync(): Promise<Result<UserResponse[]>> {
        const response = await ky.get(`${this.url}`)
        return await response.json()
    }

    public async UserLogin(user: UserRequest): Promise<Result<UserResponse>> {
        const response = await ky.post(`${this.url}/login`, {
            json: user,
        })

        return await response.json()
    }
}
