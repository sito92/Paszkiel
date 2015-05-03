using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models
{
    public class FuzzyLogicValue
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int FuzzyLogicQuestionId { get; set; }
        public virtual ICollection<Laptop> Laptop { get; set; }
    }
}