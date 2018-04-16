
using Proiect.dal.Context;
using Proiect.dal.Contracts;
using Proiect.dal.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.dal.Repositories
{
    public class LaboratoryRepository : ILaboratoryRepository
    {
        protected MoodleContext _dbContext;
        protected DbSet<LaboratoryDTO> _dbSet;

        public LaboratoryRepository(MoodleContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<LaboratoryDTO>();
        }

        public void Add(LaboratoryDTO laboratory)
        {
            _dbSet.Add(laboratory);
        }

        public void Delete(int key) //delete dupa numarul labului
        {
            LaboratoryDTO labToDelete = _dbSet.SingleOrDefault(l => l.LabNumber == key);
            Delete(labToDelete);
        }

        public void Delete(LaboratoryDTO laboratory)
        {
            if (_dbContext.Entry(laboratory).State == EntityState.Detached)
            {
                _dbSet.Attach(laboratory);
            }
            _dbSet.Remove(laboratory);
        }

        public IQueryable<LaboratoryDTO> GetAll()
        {
            return _dbSet;
        }
        
        public LaboratoryDTO GetByKey(int key)
        {
            var laboratory = _dbSet.Where(l => l.LabNumber == key).FirstOrDefault();

            return laboratory;
        }

        public LaboratoryDTO GetById(int key)
        {
            var laboratory = _dbSet.Where(l => l.Id == key).FirstOrDefault();

            return laboratory;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(LaboratoryDTO laboratory)
        {
            var entity = _dbSet.SingleOrDefault(l => l.LabNumber == laboratory.LabNumber);

            if(entity != null)
            {
                entity = laboratory; 
            }
        }
    }
}
