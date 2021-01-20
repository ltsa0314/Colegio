namespace Colegio.Domain.Entities
{
    public class ProfesorAsignaturaEntity
    {
        public int ProfesorId { get; set; }
        public int AsignaturaId { get; set; }

        public virtual ProfesorEntity Profesor { get; set; }
        public virtual AsignaturaEntity Asignatura { get; set; }
    }
}
