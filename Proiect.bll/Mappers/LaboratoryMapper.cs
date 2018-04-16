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
    public class LaboratoryMapper : ILaboratoryMapper
    {
        public LaboratoryModel Map(LaboratoryDTO laboratoryDTO)
        {
            if (laboratoryDTO == null)
            {
                return null;
            }

            return new LaboratoryModel
            {
                Id = laboratoryDTO.Id,
                LabNumber = laboratoryDTO.LabNumber,
                Date = laboratoryDTO.Date,
                Title = laboratoryDTO.Title,
                Curricula = laboratoryDTO.Curricula,
                Description = laboratoryDTO.Description
            };

        }

        public LaboratoryDTO Map(LaboratoryModel laboratoryModel)
        {
            if (laboratoryModel == null)
            {
                return null;
            }

            return new LaboratoryDTO
            {
                Id = laboratoryModel.Id,
                LabNumber = laboratoryModel.LabNumber,
                Date = laboratoryModel.Date,
                Title = laboratoryModel.Title,
                Curricula = laboratoryModel.Curricula,
                Description = laboratoryModel.Description
            };
        }
    }
}
