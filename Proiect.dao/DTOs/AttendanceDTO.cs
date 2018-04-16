using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.dal.DTOs
{
    [Table("Attendances")]
    public class AttendanceDTO
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LabId { get; set; }
        public bool AttendanceStatus { get; set; }

        [ForeignKey("StudentId")]
        public StudentDTO Student { get; set; }
        [ForeignKey("LabId")]
        public LaboratoryDTO Laboratory { get; set; }

    }
}
