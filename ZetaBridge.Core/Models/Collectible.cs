using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary,
        Mythic
    };

    public abstract class Collectible
    {
        public int ID;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Rarity Rarity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
