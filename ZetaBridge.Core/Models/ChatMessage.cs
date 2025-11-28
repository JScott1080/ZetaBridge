using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Platform { get; set; } = "";
        public string Channel { get; set; } = "";
        public string Username { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
