using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ApiFilmes.Data;
using ApiFilmes.Data.Dtos;
using ApiFilmes.Model;
using ApiFilmes.Service;
using Grpc.Core;
using FluentResults;

namespace ApiFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService service)
        {
            _filmeService = service;
        }

        [ProducesResponseType(typeof(Filme), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof (Filme), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof (Filme), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public object IncluiFilme([FromBody]CreateFilmeDto dto)
        {
            try
            {
                return _filmeService.IncluiFilme(dto);
               // return CreatedAtAction(nameof(ListaFilme), new { Id = readDto.Id }, readDto);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }

        [ProducesResponseType(typeof(Filme),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult ListaFilme()
        {
            try
            {
                List<ReadFilmeDto> filmes = _filmeService.ListaFilme();

                if (filmes.Count == 0) return Problem(detail: "Banco de dados vazio.", title: "Not Found", statusCode: 404);
                return Ok(filmes);
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }

        [ProducesResponseType(typeof(Filme), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status500InternalServerError)]
        [HttpPut("{Id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            try
            {
                Filme atualiza = _filmeService.AtualizaFilme( filmeDto);

                if (atualiza == null) return Problem(detail: "Id invalido.", title: "Bad Requests", statusCode: 400);
                return Ok(atualiza);
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
        }

        [ProducesResponseType(typeof(Filme), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{Id}")]
        public IActionResult DeletaFilme(int id)
        {
            try
            {
                Result deleta = _filmeService.DeletaFilme(id);

                if (deleta.IsFailed) return Problem(detail: "Id invalido", title: "Bad Requests", statusCode: 404);
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.GetBaseException().Message);
            }
            
        }

    }
}
