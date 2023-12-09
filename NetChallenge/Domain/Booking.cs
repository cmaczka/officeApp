﻿using System;

namespace NetChallenge.Domain
{
    public class Booking
    {
        public string LocationName { get; set; }
        public string OfficeName { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string UserName { get; set; }
    }
}