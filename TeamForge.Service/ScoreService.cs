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
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository scoreRepository;

        public ScoreService(IScoreRepository scoreRepository)
        {
            this.scoreRepository = scoreRepository;
        }

        public Score GetScoreById(Guid scoreId)
        {
            return scoreRepository.GetScoreById(scoreId);
        }

        public IEnumerable<Score> GetAllScores()
        {
            return scoreRepository.GetAllScores();
        }

        public void AddScore(Score score)
        {
            scoreRepository.AddScore(score);
        }

        public void UpdateScore(Score score)
        {
            scoreRepository.UpdateScore(score);
        }

        public void DeleteScore(Guid scoreId)
        {
            scoreRepository.DeleteScore(scoreId);
        }
    }
}
