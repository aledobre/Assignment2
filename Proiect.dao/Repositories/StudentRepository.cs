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
    public class StudentRepository : IStudentRepository
    {
        protected MoodleContext _dbContext;
        protected DbSet<StudentDTO> _dbSet;

        public StudentRepository(MoodleContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<StudentDTO>();
        }

        public void Add(StudentDTO student)
        {
            _dbSet.Add(student);
        }

        public void Delete(string key) //delete dupa username
        {
            StudentDTO studentToDelete = _dbSet.SingleOrDefault(s => s.Username == key);
            Delete(studentToDelete);
        }

        public void Delete(StudentDTO student)
        {
            if (_dbContext.Entry(student).State == EntityState.Detached)
            {
                _dbSet.Attach(student);
            }

            _dbSet.Remove(student);
        }

        public IQueryable<StudentDTO> GetAll()
        {
            return _dbSet;
        }

        public StudentDTO GetByKey(string key) //get by username
        {
            var student = _dbSet.Where(b => b.Username == key).FirstOrDefault();

            return student;
        }

        public StudentDTO GetByKey(int key) //get by id
        {
            var student = _dbSet.Where(b => b.Id == key).FirstOrDefault();

            return student;
        }


        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(StudentDTO student)
        {

            var entity = _dbSet.SingleOrDefault(l => l.Username == student.Username);

            if (entity != null)
            {
                entity = student;
            }
        }
    }
}
