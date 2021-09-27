using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using CsvHelper;
using System.Globalization;
using System.Collections;

namespace BackEnd.Models.SaveToFile
{
    public static class  FileSave<T>
    {


        public static void RemoveDirectory(string absolutepath, string directory)
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


        public static void RemoveImages(List<string> filenames, string absolutepath, string directory) {

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

        public static void SaveToExcel(string filename, IEnumerable collection)
        {

            var csvPath = Path.Combine(Environment.CurrentDirectory, filename);

            using (var streamWriter=new StreamWriter(csvPath))
            {

                using (var csvWriter=new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {

                    csvWriter.WriteRecords(collection);
                }

            }


        }


        public static List<string> Uploads(IList<IFormFile> photos, string path, string directory)
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



        public static async Task<bool> Upload(IFormFile photo, string path, string directory="/images/Avatar/")
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

        public static async Task SaveToJson(string filename, IEnumerable<T> collection)
        {

            using (FileStream fs=new FileStream(filename, FileMode.OpenOrCreate))
            {

                await System.Text.Json.JsonSerializer.SerializeAsync(fs, collection);

            }

        }

        public static void SaveToXml(string filename, IEnumerable<T> collection)
        {
             XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs=new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, collection);

            }
        }

        public static IEnumerable<T> LoadFromJson(string filename)
        {

            IEnumerable<T> collection = null;

            using (Stream Stream = new FileStream(filename, FileMode.Open))
            using (StreamReader SR = new StreamReader(Stream))
            using (JsonReader Reader = new JsonTextReader(SR))
            {
                Newtonsoft.Json.JsonSerializer Serializer = new Newtonsoft.Json.JsonSerializer();
                collection = Serializer.Deserialize<IEnumerable<T>>(Reader);
            }


            return collection;
        }

        public static async Task LoadFromXml(string filename, IEnumerable<T> collection)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                collection = (IEnumerable<T>)formatter.Deserialize(fs);

            }

        }



    }
}
