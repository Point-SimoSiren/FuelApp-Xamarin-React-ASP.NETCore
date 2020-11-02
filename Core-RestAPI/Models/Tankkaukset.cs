using System;
using System.Collections.Generic;

namespace TimesheetRestApi.Models
{
    public partial class Tankkaukset
    {
        public int TankkausId { get; set; }
        public DateTime? Pvm { get; set; }
        public decimal? Litraa { get; set; }
        public decimal? Euroa { get; set; }
        public string Reknro { get; set; }
        public int Mittarilukema { get; set; }
        public int? Ajomaara { get; set; }
        public decimal? Keskikulutus { get; set; }
    }
}
