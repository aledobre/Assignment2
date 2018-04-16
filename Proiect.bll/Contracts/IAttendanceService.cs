using Proiect.bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Contracts
{
    public interface IAttendanceService
    {
        void AddAttendance(AttendanceModel attendanceModel);

        List<AttendanceModel> GetAll();

        List<AttendanceModel> GetByStudent(string username);

        List<AttendanceModel> GetByLabNumber(int labNumber);

        bool CheckIfAttendanceExists(int labNumber, string username);

        void DeleteAttendance(AttendanceModel attendanceModel);

        void UpdateAttendance(AttendanceModel attendanceModel);

        AttendanceModel GetByLabAndStud(int labNumber, string username);
    }
}
