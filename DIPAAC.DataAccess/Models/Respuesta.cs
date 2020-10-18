namespace DataAccess.Models
{
    public class Respuesta
    {
        public int Id { get; set; }

        public bool EsCorrecta { get; set; }

        public string Pregunta { get; set; }

        public string RespuestaIngresada { get; set; }

        public int CuestionarioId { get; set; }

        public virtual Cuestionario Cuestionario { get; set; }
    }
}