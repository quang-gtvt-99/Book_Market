using System;
using System.Collections.Generic;

namespace BookMarket.Models
{
    public partial class Permission
    {
        public int PerId { get; set; }
        public int UserId { get; set; }
        public string LevelUser { get; set; }
        public string PmsUser { get; set; }
        public DateTime? PmsCreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? PmsDeletedAt { get; set; }
    }
}
