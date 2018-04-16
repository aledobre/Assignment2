using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class SubmissionAPIShortModel
    {
        public string StudentUsername { get; set; }
        public string AssignmentName { get; set; }
        public string Link { get; set; }
        public string Remark { get; set; }
        public float Grade { get; set; }
    }
}