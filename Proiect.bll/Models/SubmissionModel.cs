using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Models
{
    public class SubmissionModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
        public int AssignmentId { get; set; }
        public AssignmentModel Assignment { get; set; }
        public string Link { get; set; }
        public string Remark { get; set; }
        public float Grade { get; set; }
    }
}
