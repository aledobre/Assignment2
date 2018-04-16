using Proiect.bll.Contracts;
using Proiect.bll.Models;
using Proiect.dal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Mappers
{
    public class AssignmentMapper : IAssignmentMapper
    {
        private ILaboratoryService _iLaboratoryService;
        private ILaboratoryMapper _iLaboratoryMapper;

        public AssignmentMapper(ILaboratoryMapper laboratoryMapper, ILaboratoryService laboratoryService)
        {
            _iLaboratoryMapper = laboratoryMapper;
            _iLaboratoryService = laboratoryService;
        }

        public AssignmentModel Map(AssignmentDTO assignmentDTO)
        {
            if (assignmentDTO == null)
            {
                return null;
            }

            assignmentDTO.Laboratory = _iLaboratoryMapper.Map(_iLaboratoryService.GetById(assignmentDTO.LabId));

            var labModel = _iLaboratoryMapper.Map(assignmentDTO.Laboratory);

            return new AssignmentModel
            {
                Id = assignmentDTO.Id,
                Name = assignmentDTO.Name,
                Deadline = assignmentDTO.Deadline,
                LabId = assignmentDTO.Laboratory.Id,
                Laboratory = labModel
            };
        }

        public AssignmentDTO Map(AssignmentModel assignmentModel)
        {
            if (assignmentModel == null)
            {
                return null;
            }

            var laboratory = _iLaboratoryService.GetByLabNumber(assignmentModel.Laboratory.LabNumber);

            var labDTO = _iLaboratoryMapper.Map(assignmentModel.Laboratory);

            return new AssignmentDTO
            {
                Id = assignmentModel.Id,
                Name = assignmentModel.Name,
                Deadline = assignmentModel.Deadline,
                LabId = assignmentModel.Laboratory.Id,
                Description = assignmentModel.Description,
                Laboratory = labDTO
            };
        }
    }
}
