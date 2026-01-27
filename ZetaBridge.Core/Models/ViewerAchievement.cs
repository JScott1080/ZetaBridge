using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaBridge.Core.Models
{
    public class ViewerAchievement
    {
        public int Id { get; set; }
        public string ViewerId { get; set; } = string.Empty;
        public int AchievementId { get; set; }
        public int Progress { get; set; }
        public DateTime UnlockedAt { get; set; }
    }
}
