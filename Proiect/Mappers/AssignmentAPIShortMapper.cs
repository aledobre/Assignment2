using Proiect.bll.Contracts;
using Proiect.Contracts;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Mappers
{
    public class AssignmentAPIShortMapper : IAssignmentAPIShortMapper
    {
        private IAssignmentService _iAssignmentService;
        private IAssignmentMapper _iAssignmentMapper;
        private ILaboratoryService _iLaboratoryService;
        private ILaboratoryAPIMapper _iLaboratoryAPIMapper;


        public AssignmentAPIShortMapper(ILaboratoryAPIMapper laboratoryAPIMapper, ILaboratoryService laboratoryService, IAssignmentService assignmentService, IAssignmentMapper assignmentMapper)
        {
            _iAssignmentService = assignmentService;
            _iAssignmentMapper = assignmentMapper;
            _iLaboratoryService = laboratoryService;
            _iLaboratoryAPIMapper = laboratoryAPIMapper;
        }

        public AssignmentAPIShortModel Map(AssignmentAPIModel assignmentAPIModel)
        {
            if (assignmentAPIModel == null)
            {
                return null;
            }

            return new AssignmentAPIShortModel
            {
                Name = assignmentAPIModel.Name,
                LabNumber = assignmentAPIModel.Laboratory.LabNumber,
                Description = assignmentAPIModel.Description,
                Deadline = assignmentAPIModel.Deadline
            };
        }

        public AssignmentAPIModel Map(AssignmentAPIShortModel assignmentModel)
        {
            if (assignmentModel == null)
            {
                return null;
            }

            return new AssignmentAPIModel
            {
                Name = assignmentModel.Name,
                Laboratory = _iLaboratoryAPIMapper.Map(_iLaboratoryService.GetByLabNumber(assignmentModel.LabNumber)),
                Deadline = assignmentModel.Deadline,
                Description = assignmentModel.Description
            };
        }
    }
}
