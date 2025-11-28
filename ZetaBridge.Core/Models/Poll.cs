using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Question { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsClosed { get; set; } = false;

        public ICollection<PollOption> Options { get; set; } = new List<PollOption>();
    }

    public class PollOption
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public string Label { get; set; } = "";
    }

    public class PollVote
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public int OptionId { get; set; }
        public string Username { get; set; } = "";
        public DateTime VotedAt {  get; set; } = DateTime.UtcNow;
    }
}
