using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface ICoachService
    {
        void AddCoach(Coach coach);
        Coach GetCoachById(Guid coachId);
        IEnumerable<Coach> GetAllCoaches();
        void UpdateCoach(Coach coach);
        void DeleteCoach(Guid coachId);
    }
}
