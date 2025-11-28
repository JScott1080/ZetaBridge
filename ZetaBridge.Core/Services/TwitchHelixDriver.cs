using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Helix.Models.Predictions;
using TwitchLib.Api.Helix.Models.Predictions.CreatePrediction;
using ZetaBridge.Core.Models;

namespace ZetaBridge.Core.Services
{
    public class TwitchHelixDriver
    {
        TwitchAPI twitchAPI;

        string accessToken;
        string clientId;
        string broadcasterId;

        public TwitchHelixDriver()
        {
            accessToken = "YOUR_USER_ACCESS_TOKEN"; // Must have channel:manage:predictions scope
            clientId = "YOUR_CLIENT_ID";
            broadcasterId = "YOUR_BROADCASTER_ID";

            twitchAPI = new TwitchAPI();
            twitchAPI.Settings.AccessToken = accessToken;
            twitchAPI.Settings.ClientId = clientId;
        }

        public async Task StartPrediction(Predictions newPrediction)
        {
            // Convert your PredictionOutcome models into TwitchLib Helix Outcome objects
            var outcomes = GetOutcomes(newPrediction.PredictionOutcomes.ToArray());

            CreatePredictionRequest createPredictionRequest = new CreatePredictionRequest
            {
                BroadcasterId = broadcasterId,
                Title = newPrediction.Title,
                Outcomes = outcomes,
                PredictionWindowSeconds = newPrediction.PredictionWindow
            };

            await twitchAPI.Helix.Predictions.CreatePredictionAsync(
                createPredictionRequest
                );
        }

        private TwitchLib.Api.Helix.Models.Predictions.CreatePrediction.Outcome[] GetOutcomes(PredictionOutcome[] outcomes)
        {
            var twitchOutcomes = new TwitchLib.Api.Helix.Models.Predictions.CreatePrediction.Outcome[outcomes.Length];

            for (int i = 0; i < outcomes.Length; i++)
            {
                twitchOutcomes[i] = new TwitchLib.Api.Helix.Models.Predictions.CreatePrediction.Outcome
                {
                    Title = outcomes[i].Label
                };
            }

            return twitchOutcomes;
        }
    }
}
