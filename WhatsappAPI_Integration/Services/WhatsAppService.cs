using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WhatsappAPI_Integration.Models;

namespace WhatsappAPI_Integration.Services
{
    public class WhatsAppService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _phoneNumberId;
        private readonly string _accessToken;

        public WhatsAppService(HttpClient httpClient, IOptions<WhatsAppApi> config)
        {
            _httpClient = httpClient;
            _baseUrl = config.Value.BaseUrl;
            _phoneNumberId = config.Value.PhoneNumberId;
            _accessToken = config.Value.AccessToken;
        }

        public async Task SendMessageAsync(string to, string message)
        {
            var payload = new
            {
                messaging_product = "whatsapp",
                to = to,
                type = "text",
                text = new { body = message }
            };

            await SendRequestAsync(payload);
        }

        public async Task SendImageAsync(string to, string imageUrl, string caption = "")
        {
            var payload = new
            {
                messaging_product = "whatsapp",
                to = to,
                type = "image",
                image = new { link = imageUrl, caption = caption }
            };

            await SendRequestAsync(payload);
        }

        public async Task SendDocumentAsync(string to, string documentUrl, string caption = "")
        {
            var payload = new
            {
                messaging_product = "whatsapp",
                to = to,
                type = "document",
                document = new { link = documentUrl, caption = caption }
            };

            await SendRequestAsync(payload);
        }

        public async Task SendVideoAsync(string to, string videoUrl, string caption = "")
        {
            var payload = new
            {
                messaging_product = "whatsapp",
                to = to,
                type = "video",
                video = new { link = videoUrl, caption = caption }
            };

            await SendRequestAsync(payload);
        }

        private async Task SendRequestAsync(object payload)
        {
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var requestContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}{_phoneNumberId}/messages")
            {
                Content = requestContent
            };
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }

}
