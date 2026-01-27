using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public class Grimoire : Collectible
    {
        public bool IsActive { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.Now;

        public DateTime? ArchivedAt { get; set; }

        public int TotalCopies { get; set; }

        public string? MediaURl {  get; set; }

        public string? IconURL { get; set; }
    }
}
