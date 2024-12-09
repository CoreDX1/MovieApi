import { User } from './UserServices'

export default class Service {
    private url: string = 'http://localhost:5191/api/user'

    public User = new User(this.url)
}
