using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Interfaces;
using ZetaBridge.Core.Models;
using ZetaBridge.Core.Ports;

namespace ZetaBridge.Core.Services
{
    public class TwitchConnections : IChatIngestor
    {
        private readonly TwitchClient _client;
        private readonly string _channel;

        public event EventHandler<ChatMessageEvent>? OnMessage;

        public TwitchConnections(string username, string accessToken, string channel)
        {
            _channel = channel;
            var credentials = new ConnectionCredentials(username, accessToken);
            _client = new TwitchClient();
            _client.Initialize(credentials, channel);

            _client.OnMessageReceived += Client_OnMessageReceived;
            _client.OnConnected += Client_OnConnected;
            _client.OnJoinedChannel += Client_OnJoinedChannel;
        }

        public async Task ConnectAsync(CancellationToken ct)
        {
            await _client.ConnectAsync();
        }

        public async Task DisconnectAsync(CancellationToken ct)
        {
            await _client.DisconnectAsync();
        }

        public async Task SendMessageAsync(string channel, string message)
        {
            if (_client.IsConnected)
                await _client.SendMessageAsync(_client.JoinedChannels[0], message);
        }

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

        async Task Client_OnMessageReceived(object? sender, OnMessageReceivedArgs e)
        {
            Console.WriteLine($"{e.ChatMessage.Username}#{e.ChatMessage.Channel}: {e.ChatMessage.Message}");
            var evt = new ChatMessageEvent(
                Platform: "Twitch",
                Channel: e.ChatMessage.Channel,
                Username: e.ChatMessage.Username,
                Text: e.ChatMessage.Message,
                Timestamp: DateTimeOffset.UtcNow
            );

            OnMessage?.Invoke(this, evt);

        }
    }
}
