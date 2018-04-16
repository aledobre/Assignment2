using Proiect.bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Contracts
{
    public interface IStudentService
    {
        void AddStudent(StudentModel studentModel);

        void DeleteStudent(StudentModel studentModel);

        List<StudentModel> GetAll();

        StudentModel GetByUsername(string username);

        void UpdateStudent(StudentModel studentModel);

        bool CheckIfStudentExists(string username);

        StudentModel GetById(int id);
    }
}
