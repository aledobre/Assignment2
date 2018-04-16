using Proiect.bll.Models;
using Proiect.Contracts;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Mappers
{
    public class LaboratoryAPIMapper : ILaboratoryAPIMapper
    {
        public LaboratoryModel Map(LaboratoryAPIModel laboratoryAPIModel)
        {
            if (laboratoryAPIModel == null)
            {
                return null;
            }

            return new LaboratoryModel
            {
                LabNumber = laboratoryAPIModel.LabNumber,
                Date = laboratoryAPIModel.Date,
                Title = laboratoryAPIModel.Title,
                Curricula = laboratoryAPIModel.Curricula,
                Description = laboratoryAPIModel.Description
            };
        }

        public LaboratoryAPIModel Map(LaboratoryModel laboratoryModel)
        {
            if (laboratoryModel == null)
            {
                return null;
            }

            return new LaboratoryAPIModel
            {
                LabNumber = laboratoryModel.LabNumber,
                Date = laboratoryModel.Date,
                Title = laboratoryModel.Title,
                Curricula = laboratoryModel.Curricula,
                Description = laboratoryModel.Description
            };
        }
    }
}