using Proiect.dal.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Proiect.dal.Context
{
    public class MoodleContext : DbContext
    {
        public MoodleContext() : base(WebConfigurationManager.AppSettings["ConnectionString"])
        {
            Configuration.AutoDetectChangesEnabled = true;
        }
        
        public DbSet<StudentDTO> Student { get; set; }
        public DbSet<AssignmentDTO> Assignment { get; set; }
        public DbSet<LaboratoryDTO> Laboratories { get; set; }
        public DbSet<AttendanceDTO> Attendances { get; set; }
        public DbSet<SubmissionDTO> Submissions { get; set; }
    }
}
