using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public partial class Permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerId { get; set; }
        public int UserId { get; set; }
        public string LevelUser { get; set; }
        public string PmsUser { get; set; }
        public DateTime? PmsCreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? PmsDeletedAt { get; set; }

        public User User { get; set; }
    }
}
