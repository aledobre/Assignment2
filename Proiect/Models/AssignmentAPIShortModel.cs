using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class AssignmentAPIShortModel
    {
        public string Name { get; set; }
        public int LabNumber { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}