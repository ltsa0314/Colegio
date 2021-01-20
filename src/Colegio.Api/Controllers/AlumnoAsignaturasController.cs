using Colegio.Domain.Entities;
using Colegio.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Colegio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoAsignaturasController : ControllerBase
    {
        private readonly IAlumnoAsignaturaRepository _repository;
        public AlumnoAsignaturasController(IAlumnoAsignaturaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{alumnoid}")]
        public IActionResult GetAll(int alumnoid)
        {
            try
            {
                return Ok(_repository.GetAll(alumnoid));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{alumnoId}/{asignaturaId}/{ano}")]
        public IActionResult GetById(int alumnoId, int asignaturaId, int ano)
        {
            try
            {
                return Ok(_repository.GetById(alumnoId, asignaturaId, ano));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Insert(AlumnoAsignaturaEntity entity)
        {
            try
            {
                    if (entity.CalificacionFinal < 0 || entity.CalificacionFinal > 5)
                {
                    throw new ArgumentException("La calificacion final debe estar en el rango de 0 a 5");
                }

                var exists = _repository.GetById(entity.AlumnoId, entity.AsignaturaId, entity.Ano);
                if (exists != null)
                {
                    throw new ArgumentException("A un alumno no se le puede asociar una materia más de una vez en el mismo año académico.");
                }

                _repository.Insert(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(AlumnoAsignaturaEntity entity)
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