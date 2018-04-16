using Proiect.bll.Models;
using Proiect.Contracts;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Mappers
{
    public class AssignmentAPIMapper : IAssignmentAPIMapper
    {
        private ILaboratoryAPIMapper _iLaboratoryAPIMapper;

        public AssignmentAPIMapper(ILaboratoryAPIMapper laboratoryAPIMapper)
        {
            _iLaboratoryAPIMapper = laboratoryAPIMapper;            
        }

        public AssignmentModel Map(AssignmentAPIModel assignmentAPIModel)
        {
            if (assignmentAPIModel == null)
            {
                return null;
            }
            
            var labModel = _iLaboratoryAPIMapper.Map(assignmentAPIModel.Laboratory);
            
            var assign = new AssignmentModel();
            assign.Name = assignmentAPIModel.Name;
            assign.Deadline = assignmentAPIModel.Deadline;
            assign.Description = assignmentAPIModel.Description;
            assign.Laboratory = labModel;          
            return assign;

            //return new AssignmentModel
            //{
            //    AssignmentStatus = assignment,
            //    Student = studentModel,
            //    Laboratory = labModel
            //};

            //AssignmentModel assignmentModel = new AssignmentModel(assignment, studentModel, labModel);

            //return assignmentModel;
        }

        public AssignmentAPIModel Map(AssignmentModel assignmentModel)
        {
            if (assignmentModel == null)
            {
                return null;
            }
            
            var labAPIModel = _iLaboratoryAPIMapper.Map(assignmentModel.Laboratory);


            return new AssignmentAPIModel
            {
                Name = assignmentModel.Name,
                Deadline = assignmentModel.Deadline,
                Description = assignmentModel.Description,
                Laboratory = labAPIModel
            };


            //AssignmentAPIModel assignmentAPIModel = new AssignmentAPIModel(assignment, studentAPIModel, labAPIModel);

            //return assignmentAPIModel;

        }
    }
}