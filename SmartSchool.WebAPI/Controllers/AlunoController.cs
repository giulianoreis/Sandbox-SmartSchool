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
        public  readonly IRepository _repo ;

        public AlunoController( IRepository repo)
        {
            _repo = repo;
           
        }


        [HttpGet]
        public IActionResult Get()
        {
           var vAlunos = _repo.GetAllAlunos(true); 
            
            return Ok(vAlunos);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id,false);

            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
           
            _repo.Add(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);

            }
            return BadRequest("Aluno Não Cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var Daluno = _repo.GetAlunoById(id);
            if (Daluno == null) return BadRequest("Aluno não encontrado");
              
            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);

            }
            return BadRequest("Aluno Não atualizado");

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var Daluno = _repo.GetAlunoById(id);
            if (Daluno == null) return BadRequest("Aluno não encontrado");
            
             _repo.Update(aluno);
            
            if(_repo.SaveChanges())
            {
                return Ok(aluno);

            }
            return BadRequest("Aluno Não Cadastrado");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Daluno = _repo.GetAlunoById(id);
           
            if (Daluno == null) return BadRequest("Aluno não encontrado");
      
            _repo.Delete(Daluno);
            
            if(_repo.SaveChanges())
            {
                return Ok("Aluno Defenestrado");

            }
            return BadRequest("saporraNÃOservepranada");
        }


    }
}