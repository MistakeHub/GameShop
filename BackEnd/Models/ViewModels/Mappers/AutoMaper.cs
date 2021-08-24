using AutoMapper;
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
                 ForMember(p => p.Id, opt => opt.MapFrom(d => d.Id)).
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
                 ForMember(p => p.Images, opt => opt.MapFrom(d => d.Images.Select(p=>p.Url))).
                 ForMember(p => p.Comments, opt => opt.MapFrom(d => d.Comments)
                 ).ForMember(p=>p.Filenames, opt=> opt.MapFrom(d=>d.Images.Select(p=>p.Filename)));

            CreateMap<Cart, CartViewModel>().ForMember(p => p.Publication, opt => opt.MapFrom(d => d.Publications)).ForMember(p => p.Countof, opt => opt.MapFrom(d => d.Countof)).ForMember(p => p.Sumof, opt => opt.MapFrom(d => d.Sum)).
                ForMember(p=>p.Image, opt=>opt.MapFrom(d=>d.Publications.Select(d=>d.Images).Select(a=>a.Select(d=>d.Url))));

            CreateMap<User, UserViewModel>().ForMember(p => p.Login, opt => opt.MapFrom(d => d.Login)).ForMember(p => p.CountofComments, opt => opt.MapFrom(d => d.Comments.Count())).ForMember(d => d.Avatar, opt => opt.MapFrom(d => d.Avatar.Url)).
                ForMember(p=>p.Role, opt=> opt.MapFrom(d=>d.Role.TitleofRole)).ForMember(p=>p.Statuse, opt=>opt.MapFrom(d=>d.Status.Titleofstatuse));
        }
    }
}
