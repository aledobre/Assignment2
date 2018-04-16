using Proiect.bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Contracts
{
    public interface IAssignmentService
    {
        void AddAssignment(AssignmentModel assignmentModel);

        List<AssignmentModel> GetAll();

        List<AssignmentModel> GetByLabNumber(int labNumber);

        AssignmentModel GetByLabAndName(int labNumber, string name);

        AssignmentModel GetById(int id);

        AssignmentModel GetByName(string name);

        bool CheckIfAssignmentExists(int labNumber, string name);

        void DeleteAssignment(AssignmentModel assignmentModel);

        void UpdateAssignment(AssignmentModel assignmentModel);
    }
}
