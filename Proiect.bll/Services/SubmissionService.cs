using Proiect.bll.Contracts;
using Proiect.bll.Models;
using Proiect.dal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _iSubmissionRepository;
        private readonly ISubmissionMapper _iSubmissionMapper;

        public SubmissionService(ISubmissionRepository iSubmissionRepository, ISubmissionMapper iSubmissionMapper)
        {
            _iSubmissionRepository = iSubmissionRepository;
            _iSubmissionMapper = iSubmissionMapper;
        }

        public void AddSubmission(SubmissionModel SubmissionModel)
        {
            var submission = _iSubmissionMapper.Map(SubmissionModel);
            submission.Grade = 0;
            _iSubmissionRepository.Add(submission);
            _iSubmissionRepository.SaveChanges();
        }

        public bool CheckIfSubmissionExists(string assignName, string username)
        {
            bool submissionExists = false;
            foreach (SubmissionModel submission in GetAll())
            {

                if (submission.Assignment.Name == assignName && submission.Student.Username == username)
                    submissionExists = true;
            }
            return submissionExists;
        }

        public List<SubmissionModel> GetAll()
        {
            var submissionList = _iSubmissionRepository.GetAll()
                .Select(s => s)
                .OrderBy(a => a.AssignmentId)
                .ToList();

            IList<SubmissionModel> submissionModelsList = new List<SubmissionModel>();

            submissionList.ForEach(s => submissionModelsList.Add(_iSubmissionMapper.Map(s)));

            List<SubmissionModel> modelList = submissionModelsList as List<SubmissionModel>;

            return modelList;
        }

        public List<SubmissionModel> GetByAssignId(int id)
        {
            List<SubmissionModel> submissionModelsList = GetAll();
            List<SubmissionModel> result = new List<SubmissionModel>();

            foreach (SubmissionModel submission in submissionModelsList)
            {
                if(submission.AssignmentId == id)
                {
                    result.Add(submission);
                }
            }

            return result;
        }

        public SubmissionModel GetByAssigAndStudent(string assignName, string studentName)
        {
            List<SubmissionModel> submissionModelsList = GetAll();
            SubmissionModel result = new SubmissionModel();

            foreach (SubmissionModel submission in submissionModelsList)
            {
                if(submission.Student.Username == studentName && submission.Assignment.Name == assignName)
                {
                    result = submission;
                }
            }

            return result;
        }

        public void UpdateSubmission(SubmissionModel submissionModel)
        {
            submissionModel.Id = GetByAssigAndStudent(submissionModel.Assignment.Name, submissionModel.Student.Username).Id;
            _iSubmissionRepository.Update(_iSubmissionMapper.Map(submissionModel));
            _iSubmissionRepository.SaveChanges();
        }

        public List<SubmissionModel> GetByAssignName(string assignmentName)
        {
            throw new NotImplementedException();
        }
    }
}
