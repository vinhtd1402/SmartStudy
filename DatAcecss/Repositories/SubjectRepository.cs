using DataAcecss.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAcecss.Repositories
{
    public class SubjectRepository
    {
        private readonly SmartStudyContext _context;

        public SubjectRepository()
        {
            _context = new SmartStudyContext();
        }

        public List<Subject> GetAllSubjects()
        {
            return _context.Subjects.ToList();
        }

        public Subject? GetSubjectById(int id)
        {
            return _context.Subjects.FirstOrDefault(s => s.SubjectId == id);
        }


        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        public void DeleteSubject(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }
    }
}
