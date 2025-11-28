using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaBridge.Core.Models;
using ZetaBridge.Core.Ports;

namespace ZetaBridge.Core.Services
{
    public class YouTubeConnections : IChatIngestor
    {
        private readonly YouTubeService _service;
        private readonly string _liveChatId;
        private CancellationTokenSource? _cts;

        public event EventHandler<ChatMessageEvent> OnMessage;

        public YouTubeConnections(string apiKey, string liveChatId)
        {
            _liveChatId = liveChatId;
            _service = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "ZetaBridge"
            });
        }

        public async Task ConnectAsync(CancellationToken ct)
        {
            _cts = CancellationTokenSource.CreateLinkedTokenSource(ct);

            // Poll YouTube LiveChatMessages API
            _ = Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    var request = _service.LiveChatMessages.List(_liveChatId, "snippet,authorDetails");
                    var response = await request.ExecuteAsync(_cts.Token);

                    foreach (var msg in response.Items)
                    {
                        var evt = new ChatMessageEvent(
                            Platform: "YouTube",
                            Channel: msg.Snippet.LiveChatId,
                            Username: msg.AuthorDetails.DisplayName,
                            Text: msg.Snippet.DisplayMessage,
                            Timestamp: DateTimeOffset.Parse(msg.Snippet.PublishedAtRaw)
                        );

                        OnMessage?.Invoke(this, evt);
                    }

                    // Poll every 5 seconds
                    await Task.Delay(TimeSpan.FromSeconds(5), _cts.Token);
                }
            }, _cts.Token);

        }

        public Task DisconnectAsync(CancellationToken ct)
        {
            _cts?.Cancel();
            return Task.CompletedTask;
        }

        public Task SendMessageAsync(string channel, string message)
        {
            // YouTube API does not allow sending messages with API key only.
            // Requires OAuth2 with proper scopes (youtube.force-ssl).
            throw new NotSupportedException("Sending messages requires OAuth2 credentials.");
        }
    }
}
