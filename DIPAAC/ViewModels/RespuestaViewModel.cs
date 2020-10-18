namespace DIPAAC.ViewModels
{
    public class RespuestaViewModel
    {
        public int Id { get; set; }

        public bool EsCorrecta { get; set; }

        public string RespuestaIngresada { get; set; }

        public string Pregunta { get; set; }

        public int CuestionarioId { get; set; }

        public virtual CuestionarioViewModel Cuestionario { get; set; }
    }
}