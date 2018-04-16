using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Models
{
    public class AttendanceModel
    {
        //private bool attendance;
        //private StudentModel studentModel;
        //private LaboratoryModel labModel;

        //public AttendanceModel(bool attendance, StudentModel studentModel, LaboratoryModel labModel)
        //{
        //    this.attendance = attendance;
        //    this.studentModel = studentModel;
        //    this.labModel = labModel;
        //}
        public AttendanceModel()
        {

        }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LabId { get; set; }
        public bool AttendanceStatus { get; set; }
        public StudentModel Student { get; set; }
        public LaboratoryModel Laboratory { get; set; }
    }
}
