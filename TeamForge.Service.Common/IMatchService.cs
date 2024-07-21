using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface IMatchService
    {
        void AddMatch(Match match);
        Match GetMatchById(Guid matchId);
        IEnumerable<Match> GetAllMatches();
        void UpdateMatch(Match match);
        void DeleteMatch(Guid matchId);
    }
}
