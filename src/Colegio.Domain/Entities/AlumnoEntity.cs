using System.Collections.Generic;

namespace Colegio.Domain.Entities
{
    public class AlumnoEntity
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }

        public virtual IEnumerable<AlumnoAsignaturaEntity> AlumnoAsignaturas { get; set; }

    }
}
