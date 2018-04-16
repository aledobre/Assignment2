using Proiect.bll.Models;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Contracts
{
    public interface ISubmissionAPIShortMapper
    {
        SubmissionAPIShortModel Map(SubmissionAPIModel submissionAPIModel);
        SubmissionAPIModel Map(SubmissionAPIShortModel submissionModel);

    }
}
