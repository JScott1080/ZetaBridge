using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public enum AchievementType
    {
        Count,
        Trigger,
        Collection
    }

    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public AchievementType Type { get; set; }
        public int RequirementValue { get; set; }
        public string? IconUrl { get; set; }
        public bool IsSecret { get; set; }
    }
}
