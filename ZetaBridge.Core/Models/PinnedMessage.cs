using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public class PinnedMessage
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public DateTime PinnedAt { get; set; } = DateTime.UtcNow;

        public ChatMessage? Message { get; set; }
    }
}
