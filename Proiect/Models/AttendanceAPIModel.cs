using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class AttendanceAPIModel
    {
        //private string attendance;
        //private StudentAPIModel studentAPIModel;
        //private LaboratoryAPIModel labAPIModel;

        //public AttendanceAPIModel(string attendance, StudentAPIModel studentAPIModel, LaboratoryAPIModel labAPIModel)
        //{
        //    this.attendance = attendance;
        //    this.studentAPIModel = studentAPIModel;
        //    this.labAPIModel = labAPIModel;
        //}

        public string AttendanceStatus { get; set; }
        public StudentAPIModel Student { get; set; }
        public LaboratoryAPIModel Laboratory { get; set; }
    }
}