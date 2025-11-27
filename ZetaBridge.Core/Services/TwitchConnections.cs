using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Interfaces;

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
            _client.OnJoinedChannel += Client_OnJoinedChannel;
        }

        public async Task Connect() => await _client.ConnectAsync();

        async Task Client_OnConnected(object? sender, OnConnectedEventArgs e)
        {
            Console.WriteLine($"Connected to Twitch as {e.BotUsername}");
            await _client.JoinChannelAsync("channel_name");
        }

        async Task Client_OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine($"Joined channel {e.Channel.ToString()}");
            await _client.SendMessageAsync(e.Channel, "Hello, I am the Zeta Bridge. Now connected!");
        }

        async Task Client_OnMessageRecieved(object? sender, OnMessageReceivedArgs e)
        {
            Console.WriteLine($"{e.ChatMessage.Username}#{e.ChatMessage.Channel}: {e.ChatMessage.Message}");
        }

        async Task Client_SendMessage(string message)
        {
            _client.SendMessageAsync(_client.JoinedChannels[0], message);
        }
    }
}
