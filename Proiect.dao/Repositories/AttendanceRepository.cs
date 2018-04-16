using Proiect.dal.Context;
using Proiect.dal.Contracts;
using Proiect.dal.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.dal.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        protected MoodleContext _dbContext;
        protected DbSet<AttendanceDTO> _dbSet;

        public AttendanceRepository(MoodleContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Attendances;
        }

        public void Add(AttendanceDTO attendance)
        {
            _dbContext.Attendances.Add(attendance);
        }

        public void Delete(int key) //delete dupa id-ul attendance-ului
        {
            AttendanceDTO attendanceToDelete = _dbSet.SingleOrDefault(a => a.Id == key);
            Delete(attendanceToDelete);
        }

        public void Delete(AttendanceDTO attendance)
        {
            ////_dbContext.Entry(attendance).State = EntityState.Unchanged;
            //if (_dbContext.Entry(attendance).State == EntityState.Detached)
            //{
            //_dbSet.Attach(attendance);
            //}


            //if (attendance != null)
            //{
            //    _dbContext.Entry(attendance).State = EntityState.Detached;
            //}
            //_dbContext.Entry(attendance).State = EntityState.Modified;

            var dpt = _dbContext.Attendances.Find(attendance.Id);
            _dbContext.Entry(dpt).CurrentValues.SetValues(attendance);

            _dbSet.Remove(dpt);
        }

        public IQueryable<AttendanceDTO> GetAll()
        {
            return _dbSet;
        }

        public AttendanceDTO GetByKey(int key) //get by Id
        {
            var attendance = _dbSet.Where(a => a.Id == key).FirstOrDefault();

            return attendance;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(AttendanceDTO attendance)
        {

            List<AttendanceDTO> temp = _dbSet.Where(att => att.Id == attendance.Id).ToList();
            var dpt =temp.FirstOrDefault();

            //var entity = _dbSet.SingleOrDefault(a => a.Id == attendance.Id);

            if (dpt != null)
            {
                dpt.AttendanceStatus = attendance.AttendanceStatus;
            }

        }
    }
}