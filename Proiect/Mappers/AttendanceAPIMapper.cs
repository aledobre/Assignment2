using Proiect.bll.Models;
using Proiect.Contracts;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Mappers
{
    public class AttendanceAPIMapper : IAttendanceAPIMapper
    {
        private ILaboratoryAPIMapper _iLaboratoryAPIMapper;
        private IStudentAPIMapper _iStudentAPIMapper;

        public AttendanceAPIMapper(ILaboratoryAPIMapper laboratoryAPIMapper, IStudentAPIMapper studentAPIMapper)
        {
            _iLaboratoryAPIMapper = laboratoryAPIMapper;
            _iStudentAPIMapper = studentAPIMapper;
        }

        public AttendanceModel Map(AttendanceAPIModel attendanceAPIModel)
        {
            if (attendanceAPIModel == null)
            {
                return null;
            }

            var attendance = false;
            var studentModel = _iStudentAPIMapper.Map(attendanceAPIModel.Student);
            var labModel = _iLaboratoryAPIMapper.Map(attendanceAPIModel.Laboratory);

            if(attendanceAPIModel.AttendanceStatus == "Present")
            {
                attendance = true;
            }
            else if(attendanceAPIModel.AttendanceStatus == "Absent")
            {
                attendance = false;
            }

            var att = new AttendanceModel();
            att.AttendanceStatus = attendance;
            att.Student = studentModel;
            att.Laboratory = labModel;
            return att;

            //return new AttendanceModel
            //{
            //    AttendanceStatus = attendance,
            //    Student = studentModel,
            //    Laboratory = labModel
            //};

            //AttendanceModel attendanceModel = new AttendanceModel(attendance, studentModel, labModel);

            //return attendanceModel;
        }

        public AttendanceAPIModel Map(AttendanceModel attendanceModel)
        {
            if (attendanceModel == null)
            {
                return null;
            }

            var attendance = "Absent";
            var studentAPIModel = _iStudentAPIMapper.Map(attendanceModel.Student);
            var labAPIModel = _iLaboratoryAPIMapper.Map(attendanceModel.Laboratory);

            if (attendanceModel.AttendanceStatus == true)
            {
                attendance = "Present";
            }
            else if (attendanceModel.AttendanceStatus == false)
            {
                attendance = "Absent";
            }

            return new AttendanceAPIModel
            {
                AttendanceStatus = attendance,
                Student = studentAPIModel,
                Laboratory = labAPIModel
            };


            //AttendanceAPIModel attendanceAPIModel = new AttendanceAPIModel(attendance, studentAPIModel, labAPIModel);

            //return attendanceAPIModel;

        }
    }
}