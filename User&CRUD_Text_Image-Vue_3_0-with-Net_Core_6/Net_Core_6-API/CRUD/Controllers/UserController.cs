// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using CRUD.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataBaseContext DataBaseContext;
        private readonly IConfiguration Configuration;

        //constructor: 建構子
        public UserController(DataBaseContext DataBaseContext, IConfiguration Configuration, IWebHostEnvironment WebHostEnvironment)
        {
            this.DataBaseContext = DataBaseContext;
            this.Configuration = Configuration;
        }

        // POST: http://localhost:7076/api/User/login
        [HttpPost("login")]
        public async Task<ActionResult<DataBaseContext>> Login(UserType User)
        {
            try
            {
                var UserData = await DataBaseContext.Users.Where(FindUser => FindUser.Account == User.Account).ToListAsync();//依照Account取得資料庫資料
                if (UserData.Count == 0)// 檢查用戶存在
                    return BadRequest("Account Not Found.");
                if (UserData.First().Password != User.Password)// 檢查密碼正確
                    return BadRequest("Password Incorrect.");
                var UserPerm = await DataBaseContext.UserPermissions.FindAsync(UserData.First().PermissionId);//依照user->permissionId取得資料庫資料
                if (UserPerm == null)// 檢查使用者擁有權限資料表資料
                    return BadRequest("Permission Not Found.");
                string Token = CreateToken(UserData.First(), UserPerm);// 產生憑證
                UserData.First().Token = Token;// 儲存使用者token
                await DataBaseContext.SaveChangesAsync();// await 等待執行完再接續執行
                return Ok(new {Token=Token});
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }
        private string CreateToken(User User, UserPermission Perm)
        {
            List<Claim> Claims = new List<Claim> {
                new Claim(ClaimTypes.Name, User.Account),
                new Claim("PostPerm", Perm.PostPerm.ToString(), ClaimValueTypes.Boolean),
                new Claim("PutPerm", Perm.PutPerm.ToString(), ClaimValueTypes.Boolean),
                new Claim("DeletePerm", Perm.DeletePerm.ToString(), ClaimValueTypes.Boolean)
            };
            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("JWT:SecretKey").Value));
            var Credential = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);
            var Token = new JwtSecurityToken(
                issuer: Configuration["JWT:Issuer"],
                audience: Configuration["JWT:Audience"],
                claims: Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: Credential);
            var JwtToken = new JwtSecurityTokenHandler().WriteToken(Token);
            return JwtToken;
        }

        // POST: http://localhost:7076/api/User/auth
        [HttpPost("auth"), Authorize]
        public ActionResult<List<string>> Auth()
        {
            try
            {
                var PermList = new List<KeyValuePair<string, bool>>();
                PermList.Add(new KeyValuePair<string, bool>("Post", Convert.ToBoolean(User?.Claims.FirstOrDefault(FindPerm => FindPerm.Type == "PostPerm")?.Value)));
                PermList.Add(new KeyValuePair<string, bool>("Put", Convert.ToBoolean(User?.Claims.FirstOrDefault(FindPerm => FindPerm.Type == "PutPerm")?.Value)));
                PermList.Add(new KeyValuePair<string, bool>("Delete", Convert.ToBoolean(User?.Claims.FirstOrDefault(FindPerm => FindPerm.Type == "DeletePerm")?.Value)));
                return Ok(PermList);
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }
    }
}
