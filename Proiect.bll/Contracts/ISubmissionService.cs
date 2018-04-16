using Proiect.bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Contracts
{
    public interface ISubmissionService
    {
        void AddSubmission(SubmissionModel SubmissionModel);

        List<SubmissionModel> GetAll();

        List<SubmissionModel> GetByAssignId(int id);

        List<SubmissionModel> GetByAssignName(string assignmentName);

        SubmissionModel GetByAssigAndStudent(string assignName, string studentName);

        void UpdateSubmission(SubmissionModel submissionModel);

        bool CheckIfSubmissionExists(string assignName, string username);
    }
}
