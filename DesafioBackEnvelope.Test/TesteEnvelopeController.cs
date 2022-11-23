using DesafioBackEnvelope.Application.DTOs;
using DesafioBackEnvelope.Application.Interfaces;
using DesafioBackEnvelope.Application.Services;
using DesafioBackEnvelope.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace DesafioBackEnvelope.Test
{
    public class TesteEnvelopeController
    {
        //private readonly IEnvelopeService _envelopeService;

        public TesteEnvelopeController()
        {
            //_envelopeService = new EnvelopeService(new Mock<IConfiguration>().Object);
        }


        [Theory]
        [InlineData("Novo Contrato", 2697, "TesteAPI")]
        public async void CriarNovoEnvelope(string descricao,int idRepositorio, string nomeRepositorio)
        {

            using MultipartFormDataContent content = new()
            {
                CreateFileContent(File.OpenRead("D:\\lael\\Contratos\\CodeGroup\\Desafio AVMB - Gabriel.pdf"), "Desafio AVMB - Gabriel.pdf", "application/pdf"),
            };


            string url = $"api/v1/Envelope?descricao={descricao}&idRepositorio={idRepositorio}&nomeRepositorio={nomeRepositorio}'";

            await using var application = new EnvelopeApiApplication();
            var client = application.CreateClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token.id_token);

            var result = await client.PostAsync(url, content);

            Assert.Equal((int)result.StatusCode, 200);
        }

            [Theory]
        [InlineData(21262)]
        public async void ChecarStatus(int idEnvelope)
        {
            await using var application = new EnvelopeApiApplication();

            string url = $"api/v1/Envelope/{idEnvelope}";

            var client = application.CreateClient();

            var result = await client.GetAsync(url);

            Assert.Equal((int)result.StatusCode, 200);
        }


        private StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
        {
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"files\"",
                FileName = "\"" + fileName + "\""
            }; // the extra quotes are key here
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return fileContent;
        }
    }
}