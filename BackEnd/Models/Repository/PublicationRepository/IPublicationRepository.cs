using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.PublicationRepository
{
    public interface IPublicationRepository
    {
     
        IEnumerable<Publication> GetPublications(int page, int size=5);
        Publication GetPublication(string Titleofgame);
        void AddPublication(string titleofgame, string description, DateTime datarealese, int idplatforms, int idlocalizations, int idgenres, int idmanufactures, int idregionRestrict, int idseries, double price);
        void EditPublication(int id, string titleofgame, string description, DateTime datarealese, int[] platforms, int[] manufactures, int[] localizations, int[] genres, int series, double price);
        void RemovePublication(int id);
        IEnumerable AddComment(string username, int idpublication, string text);
        void AddMark(int idpublication, string username, double numberofmark);
        IEnumerable<Publication> GetManyPublication(string[] genres, string[] manufactures, string[] platforms, string[] localizations);
        void RemoveComment(int id);
         void AverageRating();
    }
}
