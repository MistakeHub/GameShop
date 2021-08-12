﻿using BackEnd.Models.SaveToFile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.PublicationRepository
{
    public interface IPublicationRepository:FileSave<Publication>
    {
        IEnumerable<Publication> GetAll(out int totalitems);
        IEnumerable<Publication> GetPublications(int page, out int totalitems, int size=3);
        Publication GetPublication(string Titleofgame);
        void AddPublication(List<string> images,string titleofgame, string description, DateTime datarealese, string[] platforms, string[] localizations, string[] genres, string[] manufactures, string[] regionRestrict, string series, double price);
        void EditPublication(int id, string titleofgame, string description, DateTime datarealese, int[] platforms, int[] manufactures, int[] localizations, int[] genres, int series, double price);
        void RemovePublication(int id);
        IEnumerable AddComment(string username, int idpublication, string text);
        void AddMark(int idpublication, string username, double numberofmark);
        IEnumerable<Publication> GetManyPublication(string[] genres, string[] manufactures, string[] platforms, string[] localizations);
        void RemoveComment(int id);
         void AverageRating();
    }
}
