using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ImageController : ControllerBase
    {
        private static string Path = "";
        //field: 使用到models裡面呼叫的DbContext來進行資料庫操作
        private readonly DataBaseContext DataBaseContext;
        //constructor: 建構子
        public ImageController(DataBaseContext DataBaseContext, IWebHostEnvironment WebHostEnvironment)
        {
            this.DataBaseContext = DataBaseContext;
            Path = WebHostEnvironment!.WebRootPath;
        }

        // Get: https://localhost:7076/api/Image/ +Id
        [HttpGet]
        public async Task<ActionResult<List<DataBaseContext>>> GetAllImage()
        {
            return Ok(await DataBaseContext.Images.ToListAsync());// 取得所有資料庫的資料
        }

        // Get: https://localhost:7076/api/Image/ +Id
        [HttpGet("{Id}")]
        public async Task<ActionResult<DataBaseContext>> GetImage(byte Id)
        {
            var Image = await DataBaseContext.Images.FindAsync(Id);//依照Id取得資料庫資料
            if (Image == null)
                return BadRequest("Image Id Not Found.");
            return Ok(Image);
        }

        // Post: https://localhost:7076/api/Image
        [HttpPost]
        public async Task<ActionResult> UploadImage(List<IFormFile> Files)
        {
            try
            {
                var Perm = User?.Claims.FirstOrDefault(FindPerm => FindPerm.Type == "PostPerm")?.Value;// 檢查token內claim裡面的權限
                if (Perm == null || Convert.ToBoolean(Perm) == false)
                    return Unauthorized("Not Allow This Method.");
                if (Files == null || Files.Count == 0)
                    return BadRequest("None File Upload.");
                foreach (IFormFile File in Files)
                {
                    if (File.ContentType != "image/jpeg")
                        return new UnsupportedMediaTypeResult();// http status 415
                    using (FileStream stream = new FileStream(Path + "\\images\\" + File.FileName, FileMode.Create))
                    {
                        await File.CopyToAsync(stream);
                    }
                    var Image = new Image();
                    Image.DateTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", new CultureInfo("en-US"));
                    Image.ImageUrl = "\\images\\" + File.FileName;
                    DataBaseContext.Images.Add(Image);// 新增ImageURL一個欄位, Id 和 Date 資料庫會自動產生
                }
                await DataBaseContext.SaveChangesAsync();// await 等待執行完再接續執行
                return Ok("File Upload successful.");
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }

        // PUT api/<FileController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult> PutImage(byte Id, IFormFile File)
        {
            try
            {
                var Perm = User?.Claims.FirstOrDefault(FindPerm => FindPerm.Type == "PutPerm")?.Value;// 檢查token內claim裡面的權限
                if (Perm == null || Convert.ToBoolean(Perm) == false)
                    return Unauthorized("Not Allow This Method.");
                var Image = await DataBaseContext.Images.FindAsync(Id);//依照Id取得資料庫資料
                if (Image == null)
                    return BadRequest("Image Id Not Found.");

                if (!System.IO.File.Exists(Path + Image.ImageUrl))
                    return BadRequest("Image File Not Found.");

                if (File.ContentType != "image/jpeg")
                    return new UnsupportedMediaTypeResult();

                System.IO.File.Delete(Path + Image.ImageUrl);
                using (FileStream stream = new FileStream(Path + "\\images\\" + File.FileName, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }
                Image.ImageUrl = "\\images\\" + File.FileName;
                Image.DateTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", new CultureInfo("en-US"));
                await DataBaseContext.SaveChangesAsync();// await 等待執行完再接續執行
                return Ok("File Update successful.");
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }

        // DELETE api/<FileController>/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteImage(byte Id)
        {
            try
            {
                var Perm = User?.Claims.FirstOrDefault(FindPerm => FindPerm.Type == "DeletePerm")?.Value;// 檢查token內claim裡面的權限
                if (Perm == null || Convert.ToBoolean(Perm) == false)
                    return Unauthorized("Not Allow This Method.");
                var Image = await DataBaseContext.Images.FindAsync(Id);//依照Id取得資料庫資料
                if (Image == null)
                    return BadRequest("Image Id Not Found.");

                if (!System.IO.File.Exists(Path + Image.ImageUrl))
                    return BadRequest("Image File Not Found.");

                System.IO.File.Delete(Path + Image.ImageUrl);
                DataBaseContext.Images.Remove(Image);
                await DataBaseContext.SaveChangesAsync();// await 等待執行完再接續執行
                return Ok("File Delete successful.");
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }
    }
}
