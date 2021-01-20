namespace Colegio.Domain.Entities
{
    public class AlumnoAsignaturaEntity
    {
        public int AlumnoId { get; set; }
        public int AsignaturaId { get; set; }
        public decimal CalificacionFinal { get; set; }
        public int Ano { get; set; }

        public virtual AsignaturaEntity Asignatura { get; set; }
        public virtual AlumnoEntity Alumno { get; set; }
    }
}
