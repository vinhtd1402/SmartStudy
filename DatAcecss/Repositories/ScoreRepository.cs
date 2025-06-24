// File: DataAcecss/Repositories/ScoreRepository.cs

using DataAcecss.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAcecss.Repositories
{
    public class ScoreRepository
    {
        private readonly SmartStudyContext _context;

        public ScoreRepository()
        {
            _context = new SmartStudyContext();
        }

        public List<Score> GetAllScores()
        {
            return _context.Scores.ToList();
        }

        public List<Score> GetScoresBySubjectId(int subjectId)
        {
            return _context.Scores.Where(s => s.SubjectId == subjectId).ToList();
        }

        public void AddScore(Score score)
        {
            _context.Scores.Add(score);
            _context.SaveChanges();
        }

        public void UpdateScore(Score score)
        {
            _context.Scores.Update(score);
            _context.SaveChanges();
        }

        public void DeleteScore(int scoreId)
        {
            var score = _context.Scores.Find(scoreId);
            if (score != null)
            {
                _context.Scores.Remove(score);
                _context.SaveChanges();
            }
        }
    }
}
