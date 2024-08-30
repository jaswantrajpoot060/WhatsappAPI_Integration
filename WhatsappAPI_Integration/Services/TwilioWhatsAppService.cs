using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WhatsappAPI_Integration.Models;

namespace WhatsappAPI_Integration.Services
{
    public class TwilioWhatsAppService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _whatsAppFrom;

        public TwilioWhatsAppService(IOptions<TwilioSettings> config)
        {
            _accountSid = config.Value.AccountSid;
            _authToken = config.Value.AuthToken;
            _whatsAppFrom = config.Value.WhatsAppFrom;
        }

        public async Task SendMessageAsync(string to, string message)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var msg = await MessageResource.CreateAsync(
                body: message,
                from: new PhoneNumber($"whatsapp:{_whatsAppFrom}"),
                to: new PhoneNumber($"whatsapp:{to}")
            );
        }

        public async Task SendImageAsync(string to, string imageUrl, string caption = "")
        {
            TwilioClient.Init(_accountSid, _authToken);

            var msg = await MessageResource.CreateAsync(
                body: caption,
                from: new PhoneNumber($"whatsapp:{_whatsAppFrom}"),
                to: new PhoneNumber($"whatsapp:{to}"),
                mediaUrl: new List<Uri> { new Uri(imageUrl) }
            );
        }

        public async Task SendDocumentAsync(string to, string documentUrl, string caption = "")
        {
            TwilioClient.Init(_accountSid, _authToken);

            var msg = await MessageResource.CreateAsync(
                body: caption,
                from: new PhoneNumber($"whatsapp:{_whatsAppFrom}"),
                to: new PhoneNumber($"whatsapp:{to}"),
                mediaUrl: new List<Uri> { new Uri(documentUrl) }
            );
        }

        public async Task SendVideoAsync(string to, string videoUrl, string caption = "")
        {
            TwilioClient.Init(_accountSid, _authToken);

            var msg = await MessageResource.CreateAsync(
                body: caption,
                from: new PhoneNumber($"whatsapp:{_whatsAppFrom}"),
                to: new PhoneNumber($"whatsapp:{to}"),
                mediaUrl: new List<Uri> { new Uri(videoUrl) }
            );
        }
    }

}
