namespace obras_mvc_ef.Models
{
    public class Exposicion
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<Obras>? ObrasExpuestas { get; set; }
    }
}
