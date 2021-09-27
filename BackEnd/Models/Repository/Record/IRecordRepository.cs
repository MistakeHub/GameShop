using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.Record
{
    public interface IRecordRepository
    {
        IEnumerable MostPurcheasableProduct(DateTime? from,DateTime? to, string[] genres, string[] manufactures, string[] platforms, string[] localizations);

        IEnumerable MostProfitableProduct(DateTime? from, DateTime? to, string[] genres, string[] manufactures, string[] platforms, string[] localizations);

        IEnumerable MostProfitableRatingProduct( string[] genres, string[] manufactures, string[] platforms, string[] localizations);

     


    }
}
