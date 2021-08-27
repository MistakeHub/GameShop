using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.Record
{
    public interface IRecordRepository
    {
        IEnumerable MostPurcheasableProduct();

        IEnumerable MostProfitableProduct();

        
    }
}
