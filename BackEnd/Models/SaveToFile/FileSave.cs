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
    public abstract class  FileSave<T>
    {


        public void RemoveDirectory(string absolutepath, string directory)
        {

           string  path = absolutepath + directory;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] fi = directoryInfo.GetFiles();

            foreach (FileInfo f in fi)
            {
                f.Delete();
            }
            if (directoryInfo.Exists)
                directoryInfo.Delete();

        }


        public void RemoveImages(List<string> filenames, string absolutepath, string directory) {

            string path;
            FileInfo file;

            for(int i=0; i < filenames.Count; i++)
            {
                path = absolutepath + directory + filenames[i];
                file = new FileInfo(path);

                if (file.Exists) 
                    file.Delete();

            }


        }


        public List<string> Uploads(IList<IFormFile> photos, string path, string directory)
        {
            string filename;
            List<string> filenames=new List<string>();

            if (!Directory.Exists(path + directory))
                Directory.CreateDirectory(path + directory);
            // сохраняем файл в папку Files в каталоге wwwroot
            foreach (var item in photos)
            {
                filename = item.FileName;
                using (var fileStream = new FileStream(path+ directory + filename, FileMode.Create))
                {

                    item.CopyTo(fileStream);


                }
                filenames.Add(filename);
            }

            return filenames;
        }



        public async Task<bool> Upload(IFormFile photo, string path, string directory="/images/Avatar/")
        {
            string filename = photo.FileName;
       

            if (!Directory.Exists(path + directory))
                Directory.CreateDirectory(path + directory);
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(path + directory + filename, FileMode.Create))
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
