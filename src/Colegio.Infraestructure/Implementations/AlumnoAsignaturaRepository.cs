using Colegio.Domain.Data;
using Colegio.Domain.Entities;
using Colegio.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Domain.Repositories.Implementations
{
    public class AlumnoAsignaturaRepository : IAlumnoAsignaturaRepository
    {
        private readonly ColegioDbContext _context;

        public AlumnoAsignaturaRepository(ColegioDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var entity = _context.AlumnoAsignaturas.Find(id);
            _context.AlumnoAsignaturas.Remove(entity);
            _context.SaveChanges();
        }

        public bool ExistsByAlumnoId(int alumnoId)
        {
            var exists = _context.AlumnoAsignaturas.Any(x => x.AlumnoId == alumnoId);
            return exists;
        }

        public List<AlumnoAsignaturaEntity> GetAll(int alumnoid)
        {
            var entities = _context.AlumnoAsignaturas.Where(x=> x.AlumnoId == alumnoid).ToList();
            return entities;
        }


        public AlumnoAsignaturaEntity GetById(int alumnoId, int asignaturaId, int ano)
        {
            var entity = _context.AlumnoAsignaturas.Find(alumnoId, asignaturaId, ano);
            return entity;
        }

        public void Insert(AlumnoAsignaturaEntity entity)
        {
            _context.AlumnoAsignaturas.Add(entity);
            _context.SaveChanges();
        }

        public void Update(AlumnoAsignaturaEntity entity)
        {
            _context.AlumnoAsignaturas.Update(entity);
            _context.SaveChanges();
        }

        
    }
}
