using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{

    [ApiController]
    public class ImageController : ControllerBase
    {
        IWebHostEnvironment _appEnvironment;

        public ImageController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        [Route("getImage/{titleofgame}/{titleimage}")]
        [HttpGet]
        public IActionResult getImage(string titleofgame, string titleimage)
        {

            byte[] b = System.IO.File.ReadAllBytes(@$"wwwroot\images\{titleofgame.Replace(" ", "")}\{titleimage}");   // You can use your own method over here.

            return File(b, "image/png");

        }

        [Route("uploadImage/{directory}")]
        [HttpPost]
        public async Task<bool> Upload(string directory,IFormFile photo)
        {
            string filename = photo.FileName;
           

            if (!Directory.Exists(_appEnvironment.WebRootPath + directory)) 
                Directory.CreateDirectory(_appEnvironment.WebRootPath + directory);
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath+directory+filename, FileMode.Create))
            {
  
                    await photo.CopyToAsync(fileStream);
                
                  
            }
       
            return photo != null;
        }
    }
}
