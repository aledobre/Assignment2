using Proiect.bll.Models;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Contracts
{
    public interface IAssignmentAPIMapper
    {
        AssignmentModel Map(AssignmentAPIModel assignmentAPIModel);
        AssignmentAPIModel Map(AssignmentModel assignmentModel);
    }
}
