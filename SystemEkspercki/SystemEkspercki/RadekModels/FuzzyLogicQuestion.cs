using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models
{
    public class FuzzyLogicQuestion:Question
    {
        public virtual ICollection<FuzzyLogicAnswer> FuzzyLogicAnswer { get; set; } 
    }
}