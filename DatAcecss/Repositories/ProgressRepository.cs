using DataAcecss.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAcecss.Repositories
{
    public class ProgressRepository
    {
        private readonly SmartStudyContext _context;

        public ProgressRepository()
        {
            _context = new SmartStudyContext();
        }

        public List<Progress> GetAllProgresses()
        {
            return _context.Progresses.ToList();
        }

        public List<Progress> GetBySubjectId(int subjectId)
        {
            return _context.Progresses.Where(p => p.SubjectId == subjectId).ToList();
        }

        public void AddProgress(Progress progress)
        {
            _context.Progresses.Add(progress);
            _context.SaveChanges();
        }

        public void UpdateProgress(Progress progress)
        {
            _context.Progresses.Update(progress);
            _context.SaveChanges();
        }

        public void DeleteProgress(int progressId)
        {
            var progress = _context.Progresses.Find(progressId);
            if (progress != null)
            {
                _context.Progresses.Remove(progress);
                _context.SaveChanges();
            }
        }
    }
}
