using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL;
using DAL;
using MagicWebsite.Models;

namespace MagicWebsite.App_Start
{
    public class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<UserDM, UserSM>().ReverseMap();
                config.CreateMap<UserSM, UserVM>().ReverseMap();
                config.CreateMap<CardsVM, CardsSM>();
                config.CreateMap<CardsSM, CardsVM>();
                config.CreateMap<CardsDM, CardsSM>().ReverseMap();
                config.CreateMap<CardsSM, CardsVM>().ReverseMap();
                config.CreateMap<DeckVM, DeckSM>().ReverseMap();
                config.CreateMap<DeckSM, DeckDM>().ReverseMap();
            });
        }
    }
}