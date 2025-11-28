using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public record ChatMessageEvent(
        string Platform,       // e.g. "Twitch", "YouTube"
        string Channel,        // channel name or ID
        string Username,       // who sent the message
        string Text,           // message content
        DateTimeOffset Timestamp // when it was received
    );
}
