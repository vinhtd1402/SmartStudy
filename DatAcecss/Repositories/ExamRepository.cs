using DataAcecss.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAcecss.Repositories
{
    public class ExamRepository
    {
        private readonly SmartStudyContext _context;

        public ExamRepository()
        {
            _context = new SmartStudyContext();
        }

        public List<Exam> GetAllExams()
        {
            return _context.Exams.ToList();
        }

        public List<Exam> GetExamsBySubjectId(int subjectId)
        {
            return _context.Exams.Where(e => e.SubjectId == subjectId).ToList();
        }

        public void AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
        }

        public void UpdateExam(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();
        }

        public void DeleteExam(int examId)
        {
            var exam = _context.Exams.Find(examId);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                _context.SaveChanges();
            }
        }
    }
}
