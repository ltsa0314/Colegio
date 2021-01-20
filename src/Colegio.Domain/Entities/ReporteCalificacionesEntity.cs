using System;
using System.Collections.Generic;
using System.Text;

namespace Colegio.Domain.Entities
{
    public class ReporteCalificacionesEntity
    {
        public int Ano { get; set; }
        public string IdentificacionAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string CodigoMateria { get; set; }
        public string NombreMateria { get; set; }
        public string IdentificacionProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public decimal Calificacionfinal { get; set; }
        public string Aprobo { get; set; }
    }
}
