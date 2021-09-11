using AutoMapper;
using Movies.Application.Models.Movies;
using Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Application.Mappers
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieModel, MovieModel>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Name, (o) => o.MapFrom(src => src.Name))
                .ForMember(d => d.ReleaseYear, (o) => o.MapFrom(src => src.ReleaseYear))
                .AfterMap((src, dst) =>
                {
                    if (src.Id == null)
                    {
                        dst.Id = Guid.NewGuid().ToString();
                    }
                });

            CreateMap<MovieCreationStatusModel, CreateMovieViewModel>()
                .ForMember(d => d.Id, (o) => o.MapFrom(src => src.Id))
                .ForMember(d => d.Status, (o) => o.MapFrom(src => src.Status));

            CreateMap<UpdateMovieModel, MovieModel>()
                .ForMember(d => d.Id, (o) => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, (o) => o.MapFrom(src => src.Name))
                .ForMember(d => d.ReleaseYear, (o) => o.MapFrom(src => src.ReleaseYear));

            CreateMap<MovieModel, MovieViewModel>()
                .ForMember(d => d.Id, (o) => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, (o) => o.MapFrom(src => src.Name))
                .ForMember(d => d.ReleaseYear, (o) => o.MapFrom(src => src.ReleaseYear));
        }
    }
}
