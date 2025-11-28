using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public class Predictions
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int PredictionWindow { get; set; }
        public bool bIsClosed { get; set; } = false;

        public ICollection<PredictionOutcome> PredictionOutcomes { get; set; } = new List<PredictionOutcome>();
    }

    public class PredictionOutcome
    {
        public int Id { get; set; }
        public int PredictionId { get; set; }
        public string Label { get; set; } = "";
        public bool bIsWinner { get; set; } = false;
    }

    public class PredictionBet
    {
        public int Id { get; set; }
        public int PredictionId { get; set; }
        public int OutcomeId { get; set; }
        public string Username { get; set; } = "";
        public int Amount { get; set; }
        public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
    }
}
