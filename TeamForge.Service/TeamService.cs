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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public void AddTeam(Team team)
        {
            teamRepository.AddTeam(team);
        }

        public Team GetTeamById(Guid teamId)
        {
            return teamRepository.GetTeamById(teamId);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return teamRepository.GetAllTeams();
        }

        public void UpdateTeam(Team team)
        {
            teamRepository.UpdateTeam(team);
        }

        public void DeleteTeam(Guid teamId)
        {
            teamRepository.DeleteTeam(teamId);
        }
    }
}
