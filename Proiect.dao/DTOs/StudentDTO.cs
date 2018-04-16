using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.dal.DTOs
{
    [Table("Student")]
    public class StudentDTO
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string EncPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int GroupNo { get; set; }
        public string Hobby { get; set; }

        public IEnumerable<SubmissionDTO> Submissions { get; set; }
        public IEnumerable<AttendanceDTO> Attendances { get; set; }

        public StudentDTO()
        {
            Submissions = new HashSet<SubmissionDTO>();
            Attendances = new HashSet<AttendanceDTO>();
        }
    }
}
