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
        public IActionResult Connect()
        {
            _twitch.Connect();
            return Ok("Twitch connected");
        }

        [HttpPost("send")]
        public IActionResult Send([FromBody] string message)
        {
            _twitch.SendMessage(message);
            return Ok("Message sent");
        }

    }
}
