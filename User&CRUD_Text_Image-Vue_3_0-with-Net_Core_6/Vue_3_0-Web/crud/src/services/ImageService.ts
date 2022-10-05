import http from '@/http-common'
class ImageService {
    public readonly ImageBaseUrl: string = "https:\\\\localhost:7076";
    AuthCheck(Perm: any): Promise<any> {
        return http.post(`/User/auth`, Perm, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
    GetAllImage(): Promise<any> {
        return http.get(`/Image`, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
    GetImage(Id: any): Promise<any> {
        return http.get(`/Image/${Id}`, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
    PostImage(data: any): Promise<any> {
        return http.post(`/Image`, data, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`,
                'Content-Type': 'multipart/form-data'
            }
        })
    }
    UpdateImage(Id: any, data: any): Promise<any> {
        return http.put(`/Image/${Id}`, data, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
    DeleteImage(Id: any): Promise<any> {
        return http.delete(`/Image/${Id}`, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    }
}
export default new ImageService()