using Proiect.bll.Contracts;
using Proiect.Contracts;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Mappers
{
    public class SubmissionAPIShortMapper : ISubmissionAPIShortMapper
    {
        private IStudentService _iStudentService;
        private IAssignmentService _iAssignmentService;
        private IStudentAPIMapper _iStudentAPIMapper;
        private IAssignmentAPIMapper _iAssignmentAPIMapper;

        public SubmissionAPIShortMapper(IStudentAPIMapper studentAPIMapper, IAssignmentAPIMapper assignmentAPIMapper, IStudentService studentService, IAssignmentService assignmentService)
        {
            _iStudentService = studentService;
            _iAssignmentService = assignmentService;
            _iStudentAPIMapper = studentAPIMapper;
            _iAssignmentAPIMapper = assignmentAPIMapper;
        }

        public SubmissionAPIShortModel Map(SubmissionAPIModel submissionAPIModel)
        {
            if (submissionAPIModel == null)
            {
                return null;
            }

            return new SubmissionAPIShortModel
            {
                AssignmentName = submissionAPIModel.Assignment.Name,
                Grade = submissionAPIModel.Grade,
                Link = submissionAPIModel.Link,
                Remark = submissionAPIModel.Remark,
                StudentUsername = submissionAPIModel.Student.Username
            };
        }

        public SubmissionAPIModel Map(SubmissionAPIShortModel submissionModel)
        {
            if (submissionModel == null)
            {
                return null;
            }

            return new SubmissionAPIModel
            {
                Link = submissionModel.Link,
                Grade = submissionModel.Grade,
                Remark = submissionModel.Remark,
                Student = _iStudentAPIMapper.Map(_iStudentService.GetByUsername(submissionModel.StudentUsername)),
                Assignment = _iAssignmentAPIMapper.Map(_iAssignmentService.GetByName(submissionModel.AssignmentName))
            };
        }
    }
}