using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public class GrimoireVariant
    {
        public int Id { get; set; }
        public string ViewerID { get; set; } = string.Empty;
        public int GrimoireId { get; set; }
        public int Tier { get; set; }
        public int ClaimOrder { get; set; }
        public DateTime ClaimedAt { get; set; } = DateTime.UtcNow;

        public string? TierFrameUrl { get; set; }
    }
}
