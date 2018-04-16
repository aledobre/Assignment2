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
    public class SubmissionRepository : ISubmissionRepository
    {
        protected MoodleContext _dbContext;
        protected DbSet<SubmissionDTO> _dbSet;

        public SubmissionRepository(MoodleContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<SubmissionDTO>();
        }

        public void Add(SubmissionDTO submission)
        {
            _dbSet.Add(submission);
        }

        public IQueryable<SubmissionDTO> GetAll()
        {
            return _dbSet;
        }

        public void Update(SubmissionDTO submission)
        {
            var dpt = _dbContext.Submissions.Find(submission.Id);
            _dbContext.Entry(dpt).CurrentValues.SetValues(submission);

            //var entity = _dbSet.SingleOrDefault(a => a.Id == attendance.Id);

            if (dpt != null)
            {
                dpt = submission;
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public SubmissionDTO GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubmissionDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
