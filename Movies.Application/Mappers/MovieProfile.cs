using AutoMapper;
using Movies.Application.Models.Movies;
using Movies.Domain.Models;
using System;

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
                .ForMember(d => d.Synopsis, (o) => o.MapFrom(src => src.Synopsis))
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
                .ForMember(d => d.ReleaseYear, (o) => o.MapFrom(src => src.ReleaseYear))
                .ForMember(d => d.Synopsis, (o) => o.MapFrom(src => src.Synopsis));

            CreateMap<MovieModel, MovieViewModel>()
                .ForMember(d => d.Id, (o) => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, (o) => o.MapFrom(src => src.Name))
                .ForMember(d => d.ReleaseYear, (o) => o.MapFrom(src => src.ReleaseYear))
                .ForMember(d => d.Synopsis, (o) => o.MapFrom(src => src.Synopsis));
        }
    }
}
