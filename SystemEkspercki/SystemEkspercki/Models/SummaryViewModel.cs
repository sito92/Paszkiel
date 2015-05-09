using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models
{
    public class SummaryViewModel
    {
        public List<Laptop> OrderedLaptops { get; set; }
        public int ActualLimit { get; set; }
        public int MaxLimit { get; set; }

    }
}