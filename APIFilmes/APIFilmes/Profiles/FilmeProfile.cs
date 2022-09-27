using APIFilmes.Data.DTO;
using APIFilmes.Models;
using AutoMapper;

namespace APIFilmes.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<FilmeDto, Filme>(); // filmeDto => filme 
            CreateMap<Filme, FilmeDtoToRead>(); // filme => filmeDtoToRead
        }
    }

}
