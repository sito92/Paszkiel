using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models
{
    public class BoolLogicValue
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int BoollLogicQuestionId { get; set; }
        public virtual ICollection<Laptop> Laptop { get; set; }
    }
}