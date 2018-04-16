using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Contracts
{
    public interface IAttendanceAPIShortMapper
    {
        AttendanceAPIShortModel Map(AttendanceAPIModel attendanceAPIModel);
        AttendanceAPIModel Map(AttendanceAPIShortModel attendanceModel);
    }
}
