using Proiect.bll.Contracts;
using Proiect.bll.Models;
using Proiect.dal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Mappers
{
    public class AttendanceMapper : IAttendanceMapper
    {
        private ILaboratoryMapper _iLaboratoryMapper;
        private IStudentMapper _iStudentMapper;
        private IStudentService _iStudentService;
        private ILaboratoryService _iLaboratoryService;

        public AttendanceMapper(ILaboratoryMapper laboratoryMapper, IStudentMapper studentMapper, IStudentService studentService, ILaboratoryService laboratoryService)
        {
            _iLaboratoryMapper = laboratoryMapper;
            _iStudentMapper = studentMapper;
            _iStudentService = studentService;
            _iLaboratoryService = laboratoryService;
        }

        public AttendanceModel Map(AttendanceDTO attendanceDTO)
        {
            if (attendanceDTO == null)
            {
                return null;
            }

            attendanceDTO.Student = _iStudentMapper.Map(_iStudentService.GetById(attendanceDTO.StudentId));
            attendanceDTO.Laboratory = _iLaboratoryMapper.Map(_iLaboratoryService.GetById(attendanceDTO.LabId));

            var studentModel = _iStudentMapper.Map(attendanceDTO.Student);
            var labModel = _iLaboratoryMapper.Map(attendanceDTO.Laboratory);
            
            return new AttendanceModel
            {
                AttendanceStatus = attendanceDTO.AttendanceStatus,
                Student = studentModel,
                Laboratory = labModel,
                Id = attendanceDTO.Id,
                LabId = attendanceDTO.LabId,
                StudentId = attendanceDTO.StudentId
            };
        }

        public AttendanceDTO Map(AttendanceModel attendanceModel)
        {
            if (attendanceModel == null)
            {
                return null;
            }

            var student = _iStudentService.GetByUsername(attendanceModel.Student.Username); 
            var laboratory = _iLaboratoryService.GetByLabNumber(attendanceModel.Laboratory.LabNumber);

            //var studentDTO = _iStudentMapper.Map(attendanceModel.Student);
            //var labDTO = _iLaboratoryMapper.Map(attendanceModel.Laboratory);

            return new AttendanceDTO
            {
                AttendanceStatus = attendanceModel.AttendanceStatus,
                //Student = studentDTO,
                //Laboratory = labDTO,
                Id = attendanceModel.Id,
                LabId = laboratory.Id,
                StudentId = student.Id
            };
        }
    }
}
