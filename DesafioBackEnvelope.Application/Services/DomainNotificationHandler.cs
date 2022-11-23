using DesafioBackEnvelope.Application.Interfaces;


namespace DesafioBackEnvelope.Application.Services
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        public string message { get; private set; } = "";

        public bool HasNotifications()
        {
            return !string.IsNullOrEmpty(this.message);
        }

        public void NewNotification(string message)
        {
            this.message = message;
        }

        public override string ToString()
        {
            return this.message;
        }

        public void Dispose()
        {
            this.message = "";
        }
    }

    public struct ResultResponse
    {
        /// <summary>
        /// Lista de Mensagens
        /// </summary>
        public List<Messages> Messages { get; set; }

    }
    public struct Messages
    {
        /// <summary>
        /// Mensagem do resultado
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Campo com erro
        /// </summary>
        public string ErrorField { get; set; }
    }
}
