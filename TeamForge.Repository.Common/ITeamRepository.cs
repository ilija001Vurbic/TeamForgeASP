using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Repository.Common
{
    public interface ITeamRepository
    {
        void AddTeam(Team team);
        Team GetTeamById(Guid teamId);
        IEnumerable<Team> GetAllTeams();
        void UpdateTeam(Team team);
        void DeleteTeam(Guid teamId);
    }
}
