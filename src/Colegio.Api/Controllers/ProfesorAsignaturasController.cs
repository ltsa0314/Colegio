using Colegio.Domain.Entities;
using Colegio.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Colegio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorAsignaturasController : ControllerBase
    {
        private readonly IProfesorAsignaturaRepository _repository;
        public ProfesorAsignaturasController(IProfesorAsignaturaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {

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
        public IActionResult Insert(ProfesorAsignaturaEntity entity)
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
        public IActionResult Update(ProfesorAsignaturaEntity entity)
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