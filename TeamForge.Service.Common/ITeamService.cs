using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface ITeamService
    {
        void AddTeam(Team team);
        Team GetTeamById(Guid teamId);
        IEnumerable<Team> GetAllTeams();
        void UpdateTeam(Team team);
        void DeleteTeam(Guid teamId);
    }
}
