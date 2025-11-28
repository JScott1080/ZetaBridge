using Microsoft.EntityFrameworkCore;
using TwitchLib.Api.Helix.Models.Predictions;
using ZetaBridge.Core.Models;

namespace ZetaBridge.API.Data
{
    public class ZetaBridgeContext : DbContext
    {
        public ZetaBridgeContext(DbContextOptions<ZetaBridgeContext> options) : base(options) { }

        public DbSet<ChatMessage> Messages => Set<ChatMessage>();
        public DbSet<PinnedMessage> PinnedMessages => Set<PinnedMessage>();
        public DbSet<Announcement> Announcements => Set<Announcement>();
        public DbSet<Poll> Polls => Set<Poll>();
        public DbSet<PollOption> PollOptions => Set<PollOption>();
        public DbSet<PollVote> PollVotes => Set<PollVote>();
        public DbSet<Prediction> Predictions => Set<Prediction>();
        public DbSet<PredictionOutcome> PredictionOutcomes => Set<PredictionOutcome>();
        public DbSet<PredictionBet> PredictionBets => Set<PredictionBet>();

    }
}
