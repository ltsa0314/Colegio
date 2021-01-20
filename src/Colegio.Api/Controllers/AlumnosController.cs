using Colegio.Domain.Entities;
using Colegio.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Colegio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoRepository _repository;
        private readonly IAlumnoAsignaturaRepository _asignaturaRepository;
        public AlumnosController(IAlumnoRepository repository, IAlumnoAsignaturaRepository asignaturaRepository)
        {
            _repository = repository;
            _asignaturaRepository = asignaturaRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                // 200
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {
                //400
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Report")]
        public IActionResult GetReport() {
            try
            {
                // 200
                return Ok(_repository.GetReport());
            }
            catch (Exception ex)
            {
                //400
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert(AlumnoEntity entity)
        {
            try
            {
                _repository.Insert(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(AlumnoEntity entity)
        {
            try
            {
                _repository.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_asignaturaRepository.ExistsByAlumnoId(id))
                {
                    throw new ArgumentException("No puede eliminar el alumno, ya tiene asignaturas");
                }
                _repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}