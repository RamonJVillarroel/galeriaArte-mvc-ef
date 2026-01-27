using System.ComponentModel.DataAnnotations;

namespace obras_mvc_ef.Models
{
    public class Artista
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string Pais { get; set; }
    }
}
