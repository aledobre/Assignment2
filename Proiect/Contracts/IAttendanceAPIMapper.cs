using Proiect.bll.Models;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Contracts
{
    public interface IAttendanceAPIMapper 
    {
        AttendanceModel Map(AttendanceAPIModel attendanceAPIModel);
        AttendanceAPIModel Map(AttendanceModel attendanceModel);
    }
}
