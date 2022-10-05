import http from '@/http-common'
class UserService {
    Login(Userdata: any): Promise<any> {
        return http.post(`/User/login`, Userdata)
    }
}
export default new UserService()