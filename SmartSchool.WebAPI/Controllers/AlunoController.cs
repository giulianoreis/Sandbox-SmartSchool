using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a =>
                a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome));

            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id,Aluno aluno)
        {
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
            
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id,Aluno aluno)
        {
            var Daluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);  //delete aluino
            if (Daluno ==null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Daluno = _context.Alunos.FirstOrDefault(a => a.Id == id);  //delete aluino
            if (Daluno ==null) return BadRequest("Aluno não encontrado");
            _context.Update(Daluno);
            _context.SaveChanges();
            return Ok();

        }


    }
}