using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Microsoft.Extensions.Options;
using IBuy.API.DTOs;
using System.Text;

namespace IBuy.API.Services
{
    public class MailjetEmailService
    {
        private readonly IMailjetClient _client;
        private readonly MailjetSettings _settings;

        public MailjetEmailService(IMailjetClient client, IOptions<MailjetSettings> settings)
        {
            _client = client;
            _settings = settings.Value;
        }

        public async Task<bool> SendRegistrationEmailAsync(string toEmail, string userName)
        {
            var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(_settings.SenderEmail, _settings.SenderName))
                .WithSubject("Benvenuto su IBuy!")
                .WithHtmlPart($"<h3>Ciao {userName}!</h3><p>Grazie per la registrazione su IBuy. Siamo felici di averti con noi!</p>")
                .WithTo(new SendContact(toEmail))
                .Build();

            var response = await _client.SendTransactionalEmailAsync(email);
            return response.Messages != null && response.Messages.Any();
        }

        public async Task<bool> SendPurchaseConfirmationEmailAsync(string toEmail, string userName, List<CartItemDto> items, decimal total)
        {
            var sb = new StringBuilder();
            sb.Append($"<h3>Ciao {userName},</h3>");
            sb.Append("<p>Grazie per il tuo ordine! Ecco il riepilogo dei tuoi acquisti:</p>");
            sb.Append("<ul>");

            foreach (var item in items)
            {
                sb.Append($"<li><strong>{item.ProductName}</strong> x{item.Quantity} – €{(item.Price * item.Quantity):0.00}</li>");
            }

            sb.Append("</ul>");
            sb.Append($"<p><strong>Totale:</strong> €{total:0.00}</p>");
            sb.Append("<p>A presto su IBuy!</p>");

            var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(_settings.SenderEmail, _settings.SenderName))
                .WithSubject("Conferma acquisto IBuy")
                .WithHtmlPart(sb.ToString())
                .WithTo(new SendContact(toEmail))
                .Build();

            var response = await _client.SendTransactionalEmailAsync(email);
            return response.Messages != null && response.Messages.Any();
        }

        public async Task<bool> SendOrderCanceledEmailAsync(string toEmail, string userName, string productName, int quantity, DateTime date)
        {
            var sb = new StringBuilder();
            sb.Append($"<h3>Ciao {userName},</h3>");
            sb.Append($"<p>Il tuo ordine per <strong>{productName}</strong> x{quantity} del {date:dd/MM/yyyy HH:mm} è stato <strong>annullato</strong>.</p>");
            sb.Append("<p>L'importo ti verrà rimborsato secondo i tempi previsti.</p>");
            sb.Append("<p>Contattaci per qualsiasi dubbio.</p>");

            var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(_settings.SenderEmail, _settings.SenderName))
                .WithSubject("Annullamento Ordine IBuy")
                .WithHtmlPart(sb.ToString())
                .WithTo(new SendContact(toEmail))
                .Build();

            var response = await _client.SendTransactionalEmailAsync(email);
            return response.Messages != null && response.Messages.Any();
        }

        public async Task<bool> SendOrderReturnedEmailAsync(string toEmail, string userName, string productName, int quantity, DateTime date)
        {
            var sb = new StringBuilder();
            sb.Append($"<h3>Ciao {userName},</h3>");
            sb.Append($"<p>Hai effettuato un <strong>reso</strong> per il prodotto <strong>{productName}</strong> x{quantity} acquistato il {date:dd/MM/yyyy HH:mm}.</p>");
            sb.Append("<p>L'importo ti verrà rimborsato secondo i tempi previsti.</p>");
            sb.Append("<p>Grazie per aver acquistato con noi!</p>");

            var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(_settings.SenderEmail, _settings.SenderName))
                .WithSubject("Reso confermato - IBuy")
                .WithHtmlPart(sb.ToString())
                .WithTo(new SendContact(toEmail))
                .Build();

            var response = await _client.SendTransactionalEmailAsync(email);
            return response.Messages != null && response.Messages.Any();
        }
    }
}
