using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Models
{
    public class StudentModel
    {
        public StudentModel(string token, string username, string pass, string name, string email, int groupnr, string hobby)
        {
            Token = token;
            Username = username;
            EncPassword = pass;
            Name = name;
            Email = email;
            GroupNo = groupnr;
            Hobby = hobby;
        }

        public int Id { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string EncPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int GroupNo { get; set; }
        public string Hobby { get; set; }

        public IEnumerable<SubmissionModel> Submissions { get; set; }

        public StudentModel()
        {
            Submissions = new HashSet<SubmissionModel>();
        }
    }
}
