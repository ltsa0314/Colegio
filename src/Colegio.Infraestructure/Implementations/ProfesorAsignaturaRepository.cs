using Colegio.Domain.Data;
using Colegio.Domain.Entities;
using Colegio.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Domain.Repositories.Implementations
{
    public class ProfesorAsignaturaRepository : IProfesorAsignaturaRepository
    {
        private readonly ColegioDbContext _context;

        public ProfesorAsignaturaRepository(ColegioDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var entity = _context.ProfesorAsignaturas.Find(id);
            _context.ProfesorAsignaturas.Remove(entity);
            _context.SaveChanges();
        }

        public List<ProfesorAsignaturaEntity> GetAll()
        {
            var entities = _context.ProfesorAsignaturas.ToList();
            return entities;
        }

        public ProfesorAsignaturaEntity GetById(int id)
        {
            var entity = _context.ProfesorAsignaturas.Find(id);
            return entity;
        }

        public void Insert(ProfesorAsignaturaEntity entity)
        {
            _context.ProfesorAsignaturas.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ProfesorAsignaturaEntity entity)
        {
            _context.ProfesorAsignaturas.Update(entity);
            _context.SaveChanges();
        }
    }
}
