using APIFilmes.Data;
using APIFilmes.Data.DTO;
using APIFilmes.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] FilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto); // filmeDto => filme

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { id = filme.id }, filme);
        }


        [HttpGet]
        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes; // Recupera lista de filmes do banco de dados
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);

            if (filme != null)
            {
                FilmeDtoToRead filmeDtoToRead = _mapper.Map<FilmeDtoToRead>(filme); // filme => filmeDtoToRead

                return Ok(filmeDtoToRead);
            }

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] FilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);

            if (filme == null) return NotFound();

            _mapper.Map(filmeDto, filme); // filmeDto => filme
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);

            if (filme == null) return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
