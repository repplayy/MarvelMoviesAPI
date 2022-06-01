using AutoMapper;
using FilmesAPI.Models;
using MoviesAPI.Data.Dtos;

namespace MoviesAPI.Profiles
{
    public class MovieProfile : Profile
    {

        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Movie, CreateMovieDto>();
            CreateMap<UpdateMovieDto, Movie>();
        }


    }
}
