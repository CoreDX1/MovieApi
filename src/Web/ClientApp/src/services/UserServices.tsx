import ky from 'ky'
import { UserRequest, UserResponse } from '../interfaces/User'

export class User {
    private url: string

    constructor(url: string) {
        this.url = url
    }
    public async UserLogin(user: UserRequest): Promise<UserResponse> {
        const response = await ky.post(`${this.url}/login`, {
            json: user,
        })

        return await response.json()
    }
}
