using Abp.Webhooks;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Api.V2010.Account;
using WhatsappAPI_Integration.Services;

namespace WhatsappAPI_Integration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhatsAppController : ControllerBase
    {
        private readonly WhatsAppService _whatsAppService;

        public WhatsAppController(WhatsAppService whatsAppService)
        {
            _whatsAppService = whatsAppService;
        }

        [HttpPost("send-text")]
        public async Task<IActionResult> SendTextMessage(string to, string message)
        {
            await _whatsAppService.SendMessageAsync(to, message);
            return Ok("Text message sent");
        }

        [HttpPost("send-image")]
        public async Task<IActionResult> SendImageMessage(string to, string imageUrl, string caption)
        {
            await _whatsAppService.SendImageAsync(to, imageUrl, caption);
            return Ok("Image sent");
        }

        [HttpPost("send-document")]
        public async Task<IActionResult> SendDocumentMessage(string to, string documentUrl, string caption)
        {
            await _whatsAppService.SendDocumentAsync(to, documentUrl, caption);
            return Ok("Document sent");
        }

        [HttpPost("send-video")]
        public async Task<IActionResult> SendVideoMessage(string to, string videoUrl, string caption)
        {
            await _whatsAppService.SendVideoAsync(to, videoUrl, caption);
            return Ok("Video sent");
        }
    }

}
