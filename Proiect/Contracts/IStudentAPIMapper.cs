using Proiect.bll.Models;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Contracts
{
    public interface IStudentAPIMapper
    {
        StudentModel Map(StudentAPIModel StudentAPIModel);
        StudentAPIModel Map(StudentModel studentModel);
    }
}