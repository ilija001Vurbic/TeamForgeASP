using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Repository.Common
{
    public interface IScoreRepository
    {
        Score GetScoreById(Guid scoreId);
        IEnumerable<Score> GetAllScores();
        void AddScore(Score score);
        void UpdateScore(Score score);
        void DeleteScore(Guid scoreId);
    }
}
