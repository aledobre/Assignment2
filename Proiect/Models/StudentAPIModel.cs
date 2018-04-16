using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class StudentAPIModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string EncPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int GroupNo { get; set; }
        public string Hobby { get; set; }

        public IEnumerable<SubmissionAPIModel> Submissions { get; set; }

    }
}