﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model.Common;

namespace TeamForge.Model.Common
{
    public interface IPlayer
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IUser User { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public int Blocking { get; set; }
        public int Attacking { get; set; }
        public int Serving { get; set; }
        public int Passing { get; set; }
        public int Setting { get; set; }
        public double OverallRating { get; set; } // Not stored in the database
    }
}
