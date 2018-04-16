using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Contracts
{
    public interface IAssignmentAPIShortMapper
    {
        AssignmentAPIShortModel Map(AssignmentAPIModel assignmentAPIModel);
        AssignmentAPIModel Map(AssignmentAPIShortModel assignmentModel);
    }
}
