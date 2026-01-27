using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace obras_mvc_ef.Models
{
    public class Exposicion
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        [DisplayName("Fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [DisplayName("Fecha de fin")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        public List<Obras>? ObrasExpuestas { get; set; }
    }
}
