using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class LaboratoryAPIModel
    {
        public int LabNumber { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Curricula { get; set; }
        public string Description { get; set; }

        public IEnumerable<AssignmentAPIModel> Assignments { get; set; }

    }
}