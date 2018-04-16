using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class SubmissionAPIModel
    {
        public StudentAPIModel Student { get; set; }
        public AssignmentAPIModel Assignment { get; set; }
        public string Link { get; set; }
        public string Remark { get; set; }
        public float Grade { get; set; }
    }
}