namespace RunnerApi.DTOs
{
    public class ClasificacionDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Visible { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int RunnerId { get; set; }
    }
}
