using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Carla",
                Sobrenome = "Marins",
                Telefone = "98174587"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Bruna",
                Sobrenome = "Lombardi",
                Telefone = "21478547"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Lidia",
                Sobrenome = "Brondi",
                Telefone = "45621477"
            }


        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a =>
                a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome));

            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id,Aluno aluno)
        {
            return Ok(aluno);
            
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int Id,Aluno aluno)
        {
            return Ok(aluno);
            
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          return Ok();

        }


    }
}