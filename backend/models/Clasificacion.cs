namespace RunnerApi.Models
{
    public class Clasificacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Visible { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int RunnerId { get; set; }
    }
}
