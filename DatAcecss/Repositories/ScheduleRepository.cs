using DataAcecss.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAcecss.Repositories
{
    public class ScheduleRepository
    {
        private readonly SmartStudyContext _context;

        public ScheduleRepository()
        {
            _context = new SmartStudyContext();
        }

        public List<Schedule> GetAllSchedules()
        {
            return _context.Schedules.ToList();
        }

        public List<Schedule> GetSchedulesBySubjectId(int subjectId)
        {
            return _context.Schedules.Where(s => s.SubjectId == subjectId).ToList();
        }

        public void AddSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

        public void UpdateSchedule(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            _context.SaveChanges();
        }

        public void DeleteSchedule(int scheduleId)
        {
            var schedule = _context.Schedules.Find(scheduleId);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
                _context.SaveChanges();
            }
        }
    }
}
