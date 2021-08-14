using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BackEnd.Models.SaveToFile
{
    public interface  FileSave<T>
    {


        public List<string> Uploads(IList<IFormFile> photos, IWebHostEnvironment _appEnvironment, string directory)
        {
            string filename;
            List<string> filenames=new List<string>();

            if (!Directory.Exists(_appEnvironment.WebRootPath + directory))
                Directory.CreateDirectory(_appEnvironment.WebRootPath + directory);
            // сохраняем файл в папку Files в каталоге wwwroot
            foreach (var item in photos)
            {
                filename = item.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + directory + filename, FileMode.Create))
                {

                    item.CopyTo(fileStream);


                }
                filenames.Add(filename);
            }

            return filenames;
        }



        public async Task<bool> Upload(IFormFile photo, IWebHostEnvironment _appEnvironment, string directory="/images/Avatar/")
        {
            string filename = photo.FileName;
       

            if (!Directory.Exists(_appEnvironment.WebRootPath + directory))
                Directory.CreateDirectory(_appEnvironment.WebRootPath + directory);
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + directory + filename, FileMode.Create))
            {

                await photo.CopyToAsync(fileStream);


            }

            return photo != null;
        }

        public async Task SaveToJson(string filename, IEnumerable<T> collection)
        {

            using (FileStream fs=new FileStream(filename, FileMode.OpenOrCreate))
            {

                await JsonSerializer.SerializeAsync(fs, collection);

            }

        }

        public void SaveToXml(string filename, IEnumerable<T> collection)
        {
             XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs=new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, collection);

            }
        }

        public async Task LoadFromJson(string filename,  IEnumerable<T> collection)
        {
          
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
               collection = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(fs);
             
            }
          
        }

        public async Task LoadFromXml(string filename, IEnumerable<T> collection)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                collection = (IEnumerable<T>)formatter.Deserialize(fs);

            }

        }



    }
}
