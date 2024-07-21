using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;
using TeamForge.Repository.Common;
using TeamForge.Service.Common;

namespace TeamForge.Service
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            this.matchRepository = matchRepository;
        }

        public void AddMatch(Match match)
        {
            matchRepository.AddMatch(match);
        }

        public Match GetMatchById(Guid matchId)
        {
            return matchRepository.GetMatchById(matchId);
        }

        public IEnumerable<Match> GetAllMatches()
        {
            return matchRepository.GetAllMatches();
        }

        public void UpdateMatch(Match match)
        {
            matchRepository.UpdateMatch(match);
        }

        public void DeleteMatch(Guid matchId)
        {
            matchRepository.DeleteMatch(matchId);
        }
    }
}
