﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.ViewModels.Mappers
{
    public class AutoMaper:Profile
    {

        public AutoMaper() {

            CreateMap<Publication, PublicationViewModel>().
                ForMember(p => p.Manufactures, opt => opt.MapFrom(d => d.Game.Manufactures.Select(p => p.Titleofmanufactures))).
                ForMember(p => p.Titleofgame, opt => opt.MapFrom(d => d.Game.Titleofgame)).
                ForMember(p => p.RegionRestricts, opt => opt.MapFrom(d => d.Game.RegionRestricts.Select(p => p.Titleofcountry))).
                ForMember(p => p.Platforms, opt => opt.MapFrom(d => d.Game.Platforms.Select(p => p.Titleofplatform))).
                ForMember(p => p.Genres, opt => opt.MapFrom(d => d.Game.Genres.Select(p => p.Titleofgenre))).
                ForMember(p => p.Series, opt => opt.MapFrom(d => d.Game.Series.Titleofseries)).
                ForMember(p => p.Description, opt => opt.MapFrom(d => d.Game.Description)).
                ForMember(p => p.Marks, opt => opt.MapFrom(d => d.Marks.Select(p => p.Numberofmark))).
                ForMember(p => p.Rating, opt => opt.MapFrom(d => d.Rating)).
                ForMember(p => p.DateRealese, opt => opt.MapFrom(d => d.Game.DateRelese.ToString("D"))).
               
                ForMember(p => p.Localizations, opt => opt.MapFrom(d => d.Game.Localizations.Select(p => p.Titleoflocalization))).
                 ForMember(p => p.Images, opt => opt.MapFrom(d => d.Images));
        
        }
    }
}
