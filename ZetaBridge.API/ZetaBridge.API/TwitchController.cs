using Microsoft.AspNetCore.Mvc;
using ZetaBridge.Core.Services;

namespace ZetaBridge.API
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class TwitchController : ControllerBase
    {
        private readonly TwitchConnections _twitch;


    }
}
