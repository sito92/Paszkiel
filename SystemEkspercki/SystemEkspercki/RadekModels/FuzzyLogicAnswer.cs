﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models
{
    public class FuzzyLogicAnswer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }

        public virtual ICollection<FuzzyLogicQuestion> FuzzyLogicQuestions { get; set; }
    }
}