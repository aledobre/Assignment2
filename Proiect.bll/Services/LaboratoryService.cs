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
    public class LaboratoryService : ILaboratoryService
    {
        private readonly ILaboratoryRepository _iLaboratoryRepository;
        private readonly ILaboratoryMapper _iLaboratoryMapper;

        public LaboratoryService(ILaboratoryRepository iLaboratoryRepository, ILaboratoryMapper iLaboratoryMapper)
        {
            _iLaboratoryRepository = iLaboratoryRepository;
            _iLaboratoryMapper = iLaboratoryMapper;
        }

        public void AddLaboratory(LaboratoryModel laboratoryModel)
        {
            _iLaboratoryRepository.Add(_iLaboratoryMapper.Map(laboratoryModel));
            _iLaboratoryRepository.SaveChanges();
        }

        public bool CheckIfLaboratoryExists(int labNumber)
        {
            bool labExists = false;
            foreach (LaboratoryModel lab in GetAll())
            {

                if (lab.LabNumber == labNumber)
                    labExists = true;
            }
            return labExists;
        }

        public void DeleteLaboratory(LaboratoryModel laboratoryModel)
        {
            _iLaboratoryRepository.Delete(_iLaboratoryMapper.Map(laboratoryModel).LabNumber);
            _iLaboratoryRepository.SaveChanges();
        }

        public List<LaboratoryModel> GetAll()
        {
            var laboratoryList = _iLaboratoryRepository.GetAll()
                .Select(l => l)
                .OrderBy(n => n.LabNumber)
                .ToList();

            IList<LaboratoryModel> laboratoryModelsList = new List<LaboratoryModel>();

            laboratoryList.ForEach(s => laboratoryModelsList.Add(_iLaboratoryMapper.Map(s)));

            List<LaboratoryModel> modelList = laboratoryModelsList as List<LaboratoryModel>;

            return modelList;
        }

        public List<LaboratoryModel> GetByKeyword(string keyword)
        {
            List<LaboratoryModel> allLabs = GetAll();
            List<LaboratoryModel> filteredLab = new List<LaboratoryModel>();

            foreach (LaboratoryModel lab in allLabs)
            {
                if (lab.Curricula.Contains(keyword) || lab.Description.Contains(keyword))
                {
                    filteredLab.Add(lab);
                }
            }

            return filteredLab;
        }

        public LaboratoryModel GetByLabNumber(int labNumber)
        {
            return _iLaboratoryMapper.Map((_iLaboratoryRepository.GetByKey(labNumber)));
        }

        public LaboratoryModel GetById(int id)
        {
            return _iLaboratoryMapper.Map((_iLaboratoryRepository.GetById(id)));
        }

        public void UpdateLaboratory(LaboratoryModel laboratoryModel)
        {
            _iLaboratoryRepository.Update(_iLaboratoryMapper.Map(laboratoryModel));
            _iLaboratoryRepository.SaveChanges();
        }
        
    }
}
