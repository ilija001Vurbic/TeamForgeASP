using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamForge.Model.Common;

namespace TeamForge.Model
{
    public class Team : ITeam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? CoachId { get; set; }
        public Coach Coach { get; set; }
        ICoach ITeam.Coach { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
