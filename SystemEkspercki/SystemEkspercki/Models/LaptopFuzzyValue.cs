using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models
{
    public class LaptopFuzzyValue
    {
        public int Id { get; set; }
        public int LaptopId { get; set; }
        public int FuzzyQuestionId { get; set; }
        public int Value { get; set; }
        public virtual Laptop Laptop { get; set; }
        public virtual FuzzyQuestion FuzzyQuestion { get; set; }
    }
}