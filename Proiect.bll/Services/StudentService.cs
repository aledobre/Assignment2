using Proiect.bll.Contracts;
using Proiect.bll.Models;
using Proiect.dal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _iStudentRepository;
        private readonly IStudentMapper _iStudentMapper;

        public StudentService(IStudentRepository iStudentRepository, IStudentMapper iStudentMapper)
        {
            _iStudentRepository = iStudentRepository;
            _iStudentMapper = iStudentMapper;
        }

        public StudentModel GetByUsername(string username)
        {
            return _iStudentMapper.Map((_iStudentRepository.GetByKey(username)));
        }

        public List<StudentModel> GetAll()
        {
            var studentList= _iStudentRepository.GetAll()
                .Select(s => s)
                .OrderBy(u => u.Username)
                .ToList();

            IList<StudentModel> studentModelsList = new List<StudentModel>();

            studentList.ForEach(s => studentModelsList.Add(_iStudentMapper.Map(s)));

            List<StudentModel> modelList = studentModelsList as List<StudentModel>;

            return modelList;
        }

        public void AddStudent(StudentModel studentModel)
        {
            _iStudentRepository.Add(_iStudentMapper.Map(studentModel));
            _iStudentRepository.SaveChanges();
        }

        public void DeleteStudent(string username)
        {
            _iStudentRepository.Delete(username);
            _iStudentRepository.SaveChanges();
        }

        public void UpdateStudent(StudentModel studentModel)
        {
            _iStudentRepository.Update(_iStudentMapper.Map(studentModel));
            _iStudentRepository.SaveChanges();
        }

        public bool CheckIfStudentExists(string username)
        {
            bool exists = false;
            foreach (StudentModel student in GetAll())
            {

                if (student.Username == username)
                    exists = true;
            }
            return exists;
        }

        public void DeleteStudent(StudentModel studentModel)
        {
            _iStudentRepository.Delete(_iStudentMapper.Map(studentModel).Username);
            _iStudentRepository.SaveChanges();
        }

        public StudentModel GetById(int id)
        {
            return _iStudentMapper.Map((_iStudentRepository.GetByKey(id)));
        }

    }
}
