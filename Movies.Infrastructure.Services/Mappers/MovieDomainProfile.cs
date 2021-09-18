using AutoMapper;
using Movies.Domain.Models;
using Movies.Infrastructure.Entities;

namespace Movies.Infrastructure.Services.Mappers
{
    public class MovieDomainProfile : Profile
    {
        public MovieDomainProfile()
        {
            CreateMap<MovieModel, Movie>()
                .ForMember(d => d.Id, (o) => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, (o) => o.MapFrom(src => src.Name))
                .ForMember(d => d.ReleaseYear, (o) => o.MapFrom(src => src.ReleaseYear))
                .ForMember(d => d.Synopsis, (o) => o.MapFrom(src => src.Synopsis));

            CreateMap<Movie, MovieModel>()
                .ForMember(d => d.Id, (o) => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, (o) => o.MapFrom(src => src.Name))
                .ForMember(d => d.ReleaseYear, (o) => o.MapFrom(src => src.ReleaseYear))
                .ForMember(d => d.Synopsis, (o) => o.MapFrom(src => src.Synopsis));
        }
    }
}
