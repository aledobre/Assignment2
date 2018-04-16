using Proiect.bll.Contracts;
using Proiect.Contracts;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Mappers
{
    public class AttendanceAPIShortMapper : IAttendanceAPIShortMapper
    {
        private IStudentService _iStudentService;
        private ILaboratoryService _iLaboratoryService;
        private IStudentAPIMapper _iStudentAPIMapper;
        private ILaboratoryAPIMapper _iLaboratoryAPIMapper;

        public AttendanceAPIShortMapper(IStudentAPIMapper studentAPIMapper, ILaboratoryAPIMapper laboratoryAPIMapper, IStudentService studentService, ILaboratoryService laboratoryService)
        {
            _iStudentService = studentService;
            _iLaboratoryService = laboratoryService;
            _iStudentAPIMapper = studentAPIMapper;
            _iLaboratoryAPIMapper = laboratoryAPIMapper;
        }

        public AttendanceAPIShortModel Map(AttendanceAPIModel attendanceAPIModel)
        {
            if (attendanceAPIModel == null)
            {
                return null;
            }

            return new AttendanceAPIShortModel
            {
                AttendanceStatus = attendanceAPIModel.AttendanceStatus,
                Username = attendanceAPIModel.Student.Username,
                LabNumber = attendanceAPIModel.Laboratory.LabNumber
            };
        }

        public AttendanceAPIModel Map(AttendanceAPIShortModel attendanceModel)
        {
            if (attendanceModel == null)
            {
                return null;
            }

            return new AttendanceAPIModel
            {
                AttendanceStatus = attendanceModel.AttendanceStatus,
                Student = _iStudentAPIMapper.Map(_iStudentService.GetByUsername(attendanceModel.Username)),
                Laboratory = _iLaboratoryAPIMapper.Map(_iLaboratoryService.GetByLabNumber(attendanceModel.LabNumber))
            };
        }
    }
}