using ApiFilmes.Data.Dtos;
using ApiFilmes.Data;
using ApiFilmes.Model;
using System.Collections.Generic;
using AutoMapper;
using FluentResults;

namespace ApiFilmes.Service
{

    public class FilmeService
    {
        private IMapper _mapper;
        private DataContext _context;

        public FilmeService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadFilmeDto IncluiFilme(CreateFilmeDto dto)
        {
            Filme filme = _mapper.Map<Filme>(dto);
            _context.Filme.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> ListaFilme()
        {
            List<Filme> filme = _context.Filme.ToList();

            if(filme == null)
            {
                return null;
            }

            return _mapper.Map<List<ReadFilmeDto>>(filme);
        }

        public Filme AtualizaFilme( UpdateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filme.Update(filme);

            if (_context.SaveChanges() > 0)
            {
                return filme;
            }

            return null;
        }

        public Result DeletaFilme(int id)
        {
            Filme filme = _context.Filme.FirstOrDefault(f => f.Id == id);

            if(filme == null)
            {
                return Result.Fail("Filme nao encontrado");
            }
            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
