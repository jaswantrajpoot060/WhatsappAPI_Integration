using Abp.Webhooks;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Api.V2010.Account;
using WhatsappAPI_Integration.Services;

namespace WhatsappAPI_Integration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwilioWhatsAppController : ControllerBase
    {
        private readonly TwilioWhatsAppService _twiliowhatsAppService;

        public TwilioWhatsAppController(TwilioWhatsAppService twiliowhatsAppService)
        {
            _twiliowhatsAppService = twiliowhatsAppService;
        }

        [HttpPost("send-text")]
        public async Task<IActionResult> SendTextMessage(string to, string message)
        {
            await _twiliowhatsAppService.SendMessageAsync(to, message);
            return Ok("Text message sent");
        }

        [HttpPost("send-image")]
        public async Task<IActionResult> SendImageMessage(string to, string imageUrl, string caption)
        {
            await _twiliowhatsAppService.SendImageAsync(to, imageUrl, caption);
            return Ok("Image sent");
        }

        [HttpPost("send-document")]
        public async Task<IActionResult> SendDocumentMessage(string to, string documentUrl, string caption)
        {
            await _twiliowhatsAppService.SendDocumentAsync(to, documentUrl, caption);
            return Ok("Document sent");
        }

        [HttpPost("send-video")]
        public async Task<IActionResult> SendVideoMessage(string to, string videoUrl, string caption)
        {
            await _twiliowhatsAppService.SendVideoAsync(to, videoUrl, caption);
            return Ok("Video sent");
        }
        //[HttpGet]
        //public async Task<string> GetMessageStatus(string messageSid)
        //{
        //    var message = await MessageResource.FetchAsync(messageSid);
        //    return message.Status.ToString();
        //}
        [HttpPost("webhook")]
        public IActionResult Webhook([FromBody] WebhookPayload payload)
        {
            // Process incoming message or status update
            return Ok();
        }

    }

}
