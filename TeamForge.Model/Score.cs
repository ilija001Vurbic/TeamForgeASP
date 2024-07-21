using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model.Common;

namespace TeamForge.Model
{
    public class Score : IScore
    {
        public Guid Id { get; set; }
        public int TeamIndex { get; set; } // Index of the team in the match
        public int SetNumber { get; set; } // Number of the set
        public int Points { get; set; } // Points scored by the team in the set
    }
}
