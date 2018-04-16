using Proiect.bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Contracts
{
    public interface ILaboratoryService
    {
        void AddLaboratory(LaboratoryModel laboratoryModel);

        void DeleteLaboratory(LaboratoryModel laboratoryModel);

        List<LaboratoryModel> GetAll();

        LaboratoryModel GetByLabNumber(int labNumber);

        LaboratoryModel GetById(int id);

        List<LaboratoryModel> GetByKeyword(string keyword);

        void UpdateLaboratory(LaboratoryModel laboratoryModel);

        bool CheckIfLaboratoryExists(int labNumber);
    }
}
