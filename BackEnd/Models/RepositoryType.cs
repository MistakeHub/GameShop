using BackEnd.Models.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public enum RepositoryType
    {
        CountryRep, GenreRep, LocalizationRep, ManufactureRep, PlatformRep, RoleRep, SeriesRep, StatuesRep
    }

    public delegate T ServiceResolver<T>(RepositoryType serviceType);
}
