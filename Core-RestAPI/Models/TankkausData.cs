using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetRestApi.Models
{
    public class TankkausData
    {
        public int TankkausId { get; set; }
        public DateTime? Pvm { get; set; }
        public decimal? Litraa { get; set; }
        public decimal? Euroa { get; set; }
        public string Reknro { get; set; }
        public int Mittarilukema { get; set; }
        
    }
}

