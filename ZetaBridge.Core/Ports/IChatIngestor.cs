using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaBridge.Core.Models;

namespace ZetaBridge.Core.Ports
{
    internal interface IChatIngestor
    {
        event EventHandler<ChatMessageEvent> OnMessage;
        Task ConnectAsync(CancellationToken ct);
        Task DisconnectAsync(CancellationToken ct);
        Task SendMessageAsync(string channel, string message);
    }
}
