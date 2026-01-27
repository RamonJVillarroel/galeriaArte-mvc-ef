using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace obras_mvc_ef.Models
{
    public class Obras
    {
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Titulo { get; set; }
        [StringLength(100)]
        public string Estilo { get; set; }
        [StringLength(250)]
        public string UrlImagen { get; set; }
        //[ForeignKey("Artista")]
        public Guid ArtistaID { get; set; }
        public Artista? Artista { get; set; }
        public List<Exposicion> ExposicionesObras { get; set; }
    }
}
