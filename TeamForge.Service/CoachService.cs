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
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository coachRepository;

        public CoachService(ICoachRepository coachRepository)
        {
            this.coachRepository = coachRepository;
        }

        public void AddCoach(Coach coach)
        {
            coachRepository.AddCoach(coach);
        }

        public Coach GetCoachById(Guid coachId)
        {
            return coachRepository.GetCoachById(coachId);
        }

        public IEnumerable<Coach> GetAllCoaches()
        {
            return coachRepository.GetAllCoaches();
        }

        public void UpdateCoach(Coach coach)
        {
            coachRepository.UpdateCoach(coach);
        }

        public void DeleteCoach(Guid coachId)
        {
            coachRepository.DeleteCoach(coachId);
        }
    }
}
