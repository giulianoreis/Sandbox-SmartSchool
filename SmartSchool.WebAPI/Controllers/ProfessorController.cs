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
            private readonly IRepository _repo; 
            public ProfessorController(DataContext context, IRepository repo)
            {
                _repo = repo;
            }

            [HttpGet]
            public IActionResult Get()
            {
            var vProf = _repo.GetAllProfessores(true); 
                
                return Ok(vProf);
            }

            [HttpGet("ById/{id}")]
            public IActionResult GetById(int id)
            {
                var prof = _repo.GetProfessorById(id,false);

                if (prof == null) return BadRequest("Professor não encontrado");

                return Ok(prof);
            }

            [HttpPost]
            public IActionResult Post(Professor profe)
            {
                _repo.Add(profe);

                if(_repo.SaveChanges())
                {
                    return Ok(profe);

                }
                return BadRequest("Profe Não Cadastrado");
            }


            [HttpPut("{id}")]
            public IActionResult Put(int id,Professor profe)
            {
                var p = _repo.GetProfessorById(id);
                if (p == null) return BadRequest("Profe não encontrado");
                
                _repo.Update(p);
                if(_repo.SaveChanges())
                {
                    return Ok(p);

                }
                return BadRequest("Profe Não atualizado");
            }

            [HttpPatch("{id}")]
            public IActionResult Patch(int id,Professor profe)
            {
                var p = _repo.GetAlunoById(id);
                if (p == null) return BadRequest("Profe não encontrado");
                
                _repo.Update(p);
                
                if(_repo.SaveChanges())
                {
                    return Ok(p);

                }
                return BadRequest("Profe Não Cadastrado");
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var p = _repo.GetProfessorById(id);
            
                if (p == null) return BadRequest("Profe não encontrado");
        
                _repo.Delete(p);
                
                if(_repo.SaveChanges())
                {
                    return Ok("Profe Defenestrado");

                }
                return BadRequest("saporraNÃOservepranada");
            }
        }
    }