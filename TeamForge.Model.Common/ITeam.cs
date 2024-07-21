using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeamForge.Model.Common
{
    public interface ITeam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? CoachId { get; set; }
        public ICoach Coach { get; set; }
    }

}
