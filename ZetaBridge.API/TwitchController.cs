using Microsoft.AspNetCore.Mvc;
using ZetaBridge.Core.Services;

namespace ZetaBridge.API
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class TwitchController : ControllerBase
    {
        private readonly TwitchConnections _twitch;

        public TwitchController(TwitchConnections twitch)
        {
            _twitch = twitch;
        }

        [HttpPost("connect")]
        public async Task<IActionResult> Connect()
        {
            await _twitch.ConnectAsync(CancellationToken.None);
            return Ok("Twitch connected");
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody]string channel, string message)
        {
            await _twitch.SendMessageAsync(channel, message);
            return Ok("Message sent");
        }

    }
}
