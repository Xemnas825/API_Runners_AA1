namespace RunnerApi.Models
{
    public class Recorrido
    {
        public int Id { get; set; }
        public decimal Kilometros { get; set; }
        public int? CaloriasQuemadas { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }

        public int RunnerId { get; set; }
    }
}
