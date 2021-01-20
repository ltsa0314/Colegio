using System.Collections.Generic;

namespace Colegio.Domain.Entities
{
    public class AsignaturaEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual IEnumerable<AlumnoAsignaturaEntity> AlumnoAsignaturas { get; set; }
        public virtual ProfesorAsignaturaEntity ProfesorAsignatura { get; set; }
    }
}

