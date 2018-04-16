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
    public class AssignmentService : IAssignmentService
    {

        private readonly IAssignmentRepository _iAssignmentRepository;
        private readonly IAssignmentMapper _iAssignmentMapper;

        public AssignmentService(IAssignmentRepository iAssignmentRepository, IAssignmentMapper iAssignmentMapper)
        {
            _iAssignmentRepository = iAssignmentRepository;
            _iAssignmentMapper = iAssignmentMapper;
        }

        public void AddAssignment(AssignmentModel assignmentModel)
        {
            var assign = _iAssignmentMapper.Map(assignmentModel);
            _iAssignmentRepository.Add(assign);
            _iAssignmentRepository.SaveChanges();
        }

        public bool CheckIfAssignmentExists(int labNumber, string name)
        {
            bool assignExists = false;
            foreach (AssignmentModel assign in GetAll())
            {

                if (assign.Laboratory.LabNumber == labNumber && assign.Name == name)
                    assignExists = true;
            }
            return assignExists;
        }

        public void DeleteAssignment(AssignmentModel assignmentModel)
        {
            _iAssignmentRepository.Delete(_iAssignmentMapper.Map(assignmentModel));
            _iAssignmentRepository.SaveChanges();
        }

        public List<AssignmentModel> GetAll()
        {
            var assignmentList = _iAssignmentRepository.GetAll()
                .Select(a => a)
                .OrderBy(l => l.LabId)
                .ToList();

            IList<AssignmentModel> assignmentModelsList = new List<AssignmentModel>();

            assignmentList.ForEach(s => assignmentModelsList.Add(_iAssignmentMapper.Map(s)));

            List<AssignmentModel> modelList = assignmentModelsList as List<AssignmentModel>;

            return modelList;
        }

        public List<AssignmentModel> GetByLabNumber(int labNumber)
        {
            
            List<AssignmentModel> assignmentModelsList = GetAll();
            List<AssignmentModel> result = new List<AssignmentModel>();

            foreach (AssignmentModel assignment in assignmentModelsList)
            {
                if (labNumber == assignment.Laboratory.LabNumber)
                {
                    result.Add(assignment);
                }
            }

            return result;           
        }

        public AssignmentModel GetByLabAndName(int labNumber, string name)
        {
            List<AssignmentModel> assignmentModelsList = GetAll();
            AssignmentModel result = new AssignmentModel();

            foreach (AssignmentModel assignment in assignmentModelsList)
            {
                if (labNumber == assignment.Laboratory.LabNumber && name == assignment.Name)
                {
                    result = assignment;
                }
            }

            return result;
        }

        public AssignmentModel GetByName(string name)
        {
            List<AssignmentModel> assignmentModelsList = GetAll();
            AssignmentModel result = new AssignmentModel();

            foreach (AssignmentModel assignment in assignmentModelsList)
            {
                if (name == assignment.Name)
                {
                    result = assignment;
                }
            }

            return result;
        }

        public AssignmentModel GetById(int id)
        {
            return _iAssignmentMapper.Map((_iAssignmentRepository.GetById(id)));
        }

        public void UpdateAssignment(AssignmentModel assignmentModel)
        {
            assignmentModel.Id = GetByLabAndName(assignmentModel.Laboratory.LabNumber, assignmentModel.Name).Id;
            _iAssignmentRepository.Update(_iAssignmentMapper.Map(assignmentModel));
            _iAssignmentRepository.SaveChanges();
        }
    }
}
