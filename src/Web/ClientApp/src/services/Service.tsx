import { MovieService } from './MovieServices'
import { User } from './UserServices'

class Service {
    private url: string = 'http://localhost:5191/api'

    public User = new User(`${this.url}/user`)
    public Movie = new MovieService(`${this.url}/movie`)
}

export const service = new Service()
