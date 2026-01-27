using Microsoft.AspNetCore.Mvc;
using ZetaBridge.Core.Models;
using ZetaBridge.Core.Services;

namespace ZetaBridge.API
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class TwitchController : ControllerBase
    {
        private readonly TwitchConnections _twitch;
        private readonly TwitchHelixDriver _helixDriver;

        public TwitchController(TwitchConnections twitch, TwitchHelixDriver helixDriver)
        {
            _twitch = twitch;
            _helixDriver = helixDriver;
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

        [HttpPost("announce")]
        public async Task<IActionResult> MakeAnnouncment([FromBody] string moderatorID, string message)
        {
            await _helixDriver.MakeAnAnnouncments(message, moderatorID);
            return Ok("Announcment sent");
        }

        [HttpPost("letsgamble")]
        public async Task<IActionResult> StartPrediction([FromBody]string Title, List<string> PredictionOptions)
        {
            Predictions newPrediction = new Predictions();
            newPrediction.Title = Title;

            foreach(string option in PredictionOptions)
            {
                PredictionOutcome outcome = new PredictionOutcome();
                outcome.Label = option;

                newPrediction.PredictionOutcomes.Add(outcome);
            }

            await _helixDriver.StartPrediction(newPrediction);
            return Ok("Prediction Started");
        }

        [HttpPost("stopgamble")]
        public async Task<IActionResult> EndPrediction([FromBody]string channel, string winningPrediction)
        {
            await _helixDriver.EndPrediction(winningPrediction);
            return Ok("Prediction Ended");
        }

    }
}
