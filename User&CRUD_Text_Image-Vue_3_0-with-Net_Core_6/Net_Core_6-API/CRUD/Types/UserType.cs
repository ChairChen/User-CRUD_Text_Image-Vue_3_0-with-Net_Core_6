namespace CRUD.Types
{
    public class UserType//此格式用於接收網頁傳送資料
    {
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
