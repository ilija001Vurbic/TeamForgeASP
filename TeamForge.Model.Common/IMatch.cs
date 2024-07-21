using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TeamForge.Model.Common
{

    public interface IMatch
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public Guid? Team1Id { get; set; }
        public ITeam Team1 { get; set; }
        public Guid? Team2Id { get; set; }
        public ITeam Team2 { get; set; }
    }
}
