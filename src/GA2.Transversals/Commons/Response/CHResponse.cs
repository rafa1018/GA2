namespace GA2.Transversals.Commons
{
    /// <summary>
    /// Reposense CH
    /// <author>Oscar Julian Rojas</author>
    /// <date>14/05/2021</date>
    /// </summary>
    public class CHResponse<T>
    {
        public int Tipo { get; set; }
        public string Respuesta { get; set; }
        public object Parametros { get; set; }
        public T JsonRespuestaObject { get; set; }
    }
}