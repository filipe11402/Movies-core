﻿using AutoMapper;
using Movies.Domain.Models;
using Movies.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services.Mappers
{
    public class MovieDomainProfile : Profile
    {
        public MovieDomainProfile()
        {
            CreateMap<MovieModel, Movie>()
                .ForMember(d => d.Id, (o) => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, (o) => o.MapFrom(src => src.Name))
                .ForMember(d => d.ReleaseYear, (o) => o.MapFrom(src => src.ReleaseYear));
        }
    }
}
