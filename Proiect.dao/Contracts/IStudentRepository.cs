using Proiect.dal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.dal.Contracts
{
    public interface IStudentRepository : IRepository<StudentDTO, string>
    {
        StudentDTO GetByKey(int key);
    }
}
