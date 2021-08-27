using BackEnd.Models.SaveToFile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.PublicationRepository
{
    public interface IPublicationRepository
    {
        IEnumerable<Publication> GetAll(out int totalitems);
        IEnumerable<Publication> GetPublications(int page, out int totalitems, int size=3);
        Publication GetPublicationbyTitle(string Titleofgame);
        Publication GetPublicationbyId(int id);
        void AddPublication(IList<IFormFile> images,string filepath,string titleofgame, string description, DateTime datarealese, string[] platforms, string[] localizations, string[] genres, string[] manufactures, string[] regionRestrict, string series, double price);
        void EditPublication(int id, IList<IFormFile> filenames,string filepath, string titleofgame, string description, DateTime datarealese, string[] platforms, string[] localizations, string[] genres, string[] manufactures, string[] regionRestrict, string series, double price);
        void RemovePublication(int id);
        IEnumerable AddComment(string username, int idpublication, string text);
        void AddMark(int idpublication, string username, double numberofmark);
        IEnumerable<Publication> GetManyPublication(string[] genres, string[] manufactures, string[] platforms, string[] localizations);
        void RemoveComment(int id);
         void AverageRating();
        void SaveToJson();
        void LoadfromJson();
       
    }
}
