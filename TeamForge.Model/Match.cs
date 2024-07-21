using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model.Common;
using static System.Formats.Asn1.AsnWriter;

namespace TeamForge.Model
{
    public class Match : IMatch
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public Guid? Team1Id { get; set; }
        public Team Team1 { get; set; }
        public Guid? Team2Id { get; set; }
        public Team Team2 { get; set; }
        ITeam IMatch.Team1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        ITeam IMatch.Team2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
