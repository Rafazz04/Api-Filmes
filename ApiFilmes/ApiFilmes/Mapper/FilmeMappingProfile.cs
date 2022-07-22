using AutoMapper;
using ApiFilmes.Model;
using ApiFilmes.Data.Dtos;
namespace ApiFilmes.Mapper
{
    public class FilmeMappingProfile : Profile
    {
        public FilmeMappingProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
