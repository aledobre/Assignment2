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
    public class AssignmentRepository : IAssignmentRepository
    {
        protected MoodleContext _dbContext;
        protected DbSet<AssignmentDTO> _dbSet;

        public AssignmentRepository(MoodleContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<AssignmentDTO>();
        }

        public void Add(AssignmentDTO assignment)
        {
            _dbSet.Add(assignment);
        }

        public void Delete(int key) //delete dupa id
        {
            AssignmentDTO assignToDelete = _dbSet.SingleOrDefault(l => l.Id == key);
            Delete(assignToDelete);
        }

        public void Delete(AssignmentDTO assignment)
        {
            //if (_dbContext.Entry(assignment).State == EntityState.Detached)
            //{
            //    _dbSet.Attach(assignment);
            //}

            var dpt = _dbContext.Assignment.Find(assignment.Id);
            _dbContext.Entry(dpt).CurrentValues.SetValues(assignment);
             
            _dbSet.Remove(dpt);
            
        }

        public IQueryable<AssignmentDTO> GetAll()
        {
            return _dbSet;
        }

        public AssignmentDTO GetByKey(int key)
        {
            var assignment = _dbSet.Where(a => a.Laboratory.LabNumber == key).FirstOrDefault();

            return assignment;
        }

        public AssignmentDTO GetById(int key)
        {
            var assignment = _dbSet.Where(a => a.Id == key).FirstOrDefault();

            return assignment;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(AssignmentDTO assignment)
        {
            var dpt = _dbContext.Assignment.Find(assignment.Id);
            _dbContext.Entry(dpt).CurrentValues.SetValues(assignment);

            //var entity = _dbSet.SingleOrDefault(a => a.Id == attendance.Id);

            if (dpt != null)
            {
                dpt = assignment;
            }
        }
    }
}
