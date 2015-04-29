using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models
{
    public class FuzzyQuestion:Question
    {
        public virtual ICollection<Answer> Answers { get; set; } 
    }
}