﻿using System.Collections.Generic;

namespace NetChallenge.Domain
{
    public class Office
    {
        public string LocationName { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public IEnumerable<string> AvailableResources { get; set; }
    }
}