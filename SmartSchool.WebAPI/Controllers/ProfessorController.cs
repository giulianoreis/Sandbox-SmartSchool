using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ProfessorController : ControllerBase
        {
            private readonly DataContext _context;          
            public ProfessorController(DataContext context)
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
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (prof == null) return BadRequest("Aluno não encontrado");

            return Ok(prof);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var prof = _context.Professores.FirstOrDefault(a =>
                a.Nome.Contains(nome) );

            if (prof == null) return BadRequest("Aluno não encontrado");

            return Ok(prof);
        }

        [HttpPost]
        public IActionResult Post(Professor profe)
        {
            _context.Add(profe);
            _context.SaveChanges();
            
            return Ok(profe);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id,Professor profe)
        {
            _context.Update(profe);
            _context.SaveChanges();
            return Ok(profe);
            
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id,Professor profe)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);  //delete aluino
            if (prof ==null) return BadRequest("Professor não encontrado");
            _context.Update(prof);
            _context.SaveChanges();
            return Ok(prof);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var profe = _context.Professores.FirstOrDefault(a => a.Id == id);  //delete aluino
            if (profe ==null) return BadRequest("Aluno não encontrado");
            _context.Update(profe);
            _context.SaveChanges();
            return Ok();

        }





        }
    }