using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace ZetaBridge.Core.Services
{
    public class TwitchConnections
    {
        private readonly TwitchClient _client;

        public TwitchConnections(string username, string accessToken, string channel)
        {
            var credentials = new ConnectionCredentials(username, accessToken);
            _client = new TwitchClient();
            _client.Initialize(credentials, channel);

            _client.OnMessageReceived += Client_OnMessageRecieved;
            _client.OnConnected += Client_OnConnected;
        }

        public void Connect() => _client.ConnectAsync();

        private void Client_OnConnected(object sender, OnConnectedEventArgs e)
        {
            Console.WriteLine($"Connected to Twitch as {e.BotUsername}");
        }

        private void Client_OnMessageRecieved(object sender, OnMessageReceivedArgs e)
        {
            Console.WriteLine($"[{e.ChatMessage.Username}] {e.ChatMessage.Message}");
        }

        public void Client_SendMessage(string message)
        {
            _client.SendMessageAsync(_client.JoinedChannels[0], message);
        }
    }
}
