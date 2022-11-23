namespace DesafioBackEnvelope.Application.DTOs
{
    public class DocumentoDTO
    {
        public string nomeArquivo { get; set; }
        public string mimeType { get; set; }
        /// <summary>
        /// Base64
        /// </summary>
        public string conteudo { get; set; }
    }
}