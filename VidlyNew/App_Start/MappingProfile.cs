using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VidlyNew.DTOs;
using VidlyNew.Models;

namespace VidlyNew.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreTypeDTO>();
            Mapper.CreateMap<Rental, RentalDTO>();
            Mapper.CreateMap<Game, GameDTO>();


            //Dto to Domain
            Mapper.CreateMap<MovieDTO, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<RentalDTO, Rental>()
                .ForMember(r => r.Id, opt => opt.Ignore());

            Mapper.CreateMap<GenreTypeDTO, Genre>()
                .ForMember(g => g.Id, opt => opt.Ignore());

            Mapper.CreateMap<GameDTO, Game>()
                .ForMember(ga => ga.Id, opt => opt.Ignore());
        }
    }
}