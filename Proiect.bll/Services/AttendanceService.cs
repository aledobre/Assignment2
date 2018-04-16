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
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _iAttendanceRepository;
        private readonly IAttendanceMapper _iAttendanceMapper;

        public AttendanceService(IAttendanceRepository iAttendanceRepository, IAttendanceMapper iAttendanceMapper)
        {
            _iAttendanceRepository = iAttendanceRepository;
            _iAttendanceMapper = iAttendanceMapper;
        }

        public void AddAttendance(AttendanceModel attendanceModel)
        {
            var att = _iAttendanceMapper.Map(attendanceModel);
            _iAttendanceRepository.Add(att);
            _iAttendanceRepository.SaveChanges();
        }

        public bool CheckIfAttendanceExists(int labNumber, string username)
        {
            bool attendExists = false;
            foreach (AttendanceModel attend in GetAll())
            {

                if (attend.Laboratory.LabNumber == labNumber && attend.Student.Username == username)
                    attendExists = true;
            }
            return attendExists;
        }

        public List<AttendanceModel> GetAll()
        {
            var attendanceList = _iAttendanceRepository.GetAll().ToList();
                

            List<AttendanceModel> attendanceModelsList = new List<AttendanceModel>();

            attendanceList.ForEach(s => attendanceModelsList.Add(_iAttendanceMapper.Map(s)));           

            return attendanceModelsList;
        }

        public AttendanceModel GetByLabAndStud(int labNumber, string username)
        {
            List<AttendanceModel> attendanceModelsList = GetAll();
            AttendanceModel result = new AttendanceModel();

            foreach (AttendanceModel attendance in attendanceModelsList)
            {
                if (labNumber == attendance.Laboratory.LabNumber && username == attendance.Student.Username)
                {
                    result = attendance;
                }
            }

            return result;
        }

        public List<AttendanceModel> GetByLabNumber(int labNumber)
        {
            List<AttendanceModel> attendanceModelsList = GetAll();
            List<AttendanceModel> result = new List<AttendanceModel>();

            foreach(AttendanceModel attendance in attendanceModelsList)
            {
                if(labNumber == attendance.Laboratory.LabNumber)
                {
                    result.Add(attendance);
                }
            }

            return result;
        }

        public List<AttendanceModel> GetByStudent(string username)
        {
            List<AttendanceModel> attendanceModelsList = GetAll();
            List<AttendanceModel> result = new List<AttendanceModel>();

            foreach (AttendanceModel attendance in attendanceModelsList)
            {
                if (username == attendance.Student.Username)
                {
                    result.Add(attendance);
                }
            }

            return result;
        }

        public void DeleteAttendance(AttendanceModel attendanceModel)
        {
            _iAttendanceRepository.Delete(_iAttendanceMapper.Map(attendanceModel));
            _iAttendanceRepository.SaveChanges();
        }

        public void UpdateAttendance(AttendanceModel attendanceModel)
        {
            //var att_dto = _iAttendanceMapper.Map(attendanceModel);
            _iAttendanceRepository.Update(new dal.DTOs.AttendanceDTO {Id=attendanceModel.Id,AttendanceStatus=attendanceModel.AttendanceStatus });
            _iAttendanceRepository.SaveChanges();
        }
    }
}
