using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RunnerApi.Models
{
    // Mapeamos la clase a la tabla 'runners'
    [Table("runners")] 
    public class Runner
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("apellido")]
        public string Apellido { get; set; }

        [Column("dni")]
        public string Dni { get; set; }

        [Column("correo")]
        public string Correo { get; set; }

        [Column("contrasena")]
        public string Contrasena { get; set; }

        [Column("valido")]
        public bool Valido { get; set; }

        [Column("grupo_id")]
        public int? GrupoId { get; set; }
    }
}
