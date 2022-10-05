import http from '@/http-common'
class DataService {
    AuthCheck(Perm: any): Promise<any> {
        return http.post(`/User/auth`, Perm, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
    GetAll(): Promise<any> {
        return http.get(`/DataBase`, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
    Get(Id: any): Promise<any> {
        return http.get(`/DataBase/${Id}`, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
    Post(data: any): Promise<any> {
        return http.post(`/DataBase`, data, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
    Update(Id:any, data: any): Promise<any> {
        return http.put(`/DataBase/${Id}`, data, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
    Delete(Id: any): Promise<any> {
        return http.delete(`/DataBase/${Id}`, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
}
export default new DataService()