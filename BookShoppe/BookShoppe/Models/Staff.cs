using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket.Models
{
    public partial class Staff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStaff { get; set; }
        public string LevelStaff { get; set; }
        public int? LevelSlary { get; set; }
        public string FuncStaff { get; set; }
        public int? Cmnd { get; set; }
        public string Edu { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
