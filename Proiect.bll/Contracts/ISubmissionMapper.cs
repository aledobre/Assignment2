using Proiect.bll.Models;
using Proiect.dal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Contracts
{
    public interface ISubmissionMapper
    {
        SubmissionModel Map(SubmissionDTO submissionDTO);
        SubmissionDTO Map(SubmissionModel submissionModel);
    }
}
