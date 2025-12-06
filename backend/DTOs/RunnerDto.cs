namespace RunnerApi.DTOs
{
    public class RunnerDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public bool Valido { get; set; }
        public int? GrupoId { get; set; }
    }
}
