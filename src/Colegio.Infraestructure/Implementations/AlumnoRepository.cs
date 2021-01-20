using Colegio.Domain.Data;
using Colegio.Domain.Entities;
using Colegio.Domain.Repositories.Interfaces;
using Colegio.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Domain.Repositories.Implementations
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly ColegioDbContext _context;
        private readonly ColegioQuerysDbContext _queryContext;

        public AlumnoRepository(ColegioDbContext context,ColegioQuerysDbContext queryContext)
        {
            _context = context;
            _queryContext = queryContext;
        }

        public void Delete(int id)
        {
            var entity = _context.Alumnos.Find(id);
            _context.Alumnos.Remove(entity);
            _context.SaveChanges();
        }

        public List<AlumnoEntity> GetAll()
        {
            var entities = _context.Alumnos.ToList();
            return entities;
        }

        public AlumnoEntity GetById(int id)
        {
            var entity = _context.Alumnos.Find(id);
            return entity;
        }

        public List<ReporteCalificacionesEntity> GetReport()
        {
            var entities = _queryContext.ReporteCalificaciones.ToList();            
            return entities;

        }

        public void Insert(AlumnoEntity entity)
        {
            _context.Alumnos.Add(entity);
            _context.SaveChanges();
        }

        public void Update(AlumnoEntity entity)
        {
            _context.Alumnos.Update(entity);
            _context.SaveChanges();
        }
    }
}
