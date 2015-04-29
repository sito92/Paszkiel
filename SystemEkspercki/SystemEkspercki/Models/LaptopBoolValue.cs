using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models
{
    public class LaptopBoolValue
    {
        public int Id { get; set; }
        public int LaptopId { get; set; }
        public int BoolQuestionId { get; set; }
        public bool Value { get; set; }

        public virtual Laptop Laptop { get; set; }
        public virtual BoolQuestion BoolQuestion { get; set; }
    }
}