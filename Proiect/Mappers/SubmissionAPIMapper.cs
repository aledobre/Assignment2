using Proiect.bll.Models;
using Proiect.Contracts;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Mappers
{
    public class SubmissionAPIMapper : ISubmissionAPIMapper
    {
        private IAssignmentAPIMapper _iAssignmentAPIMapper;
        private IStudentAPIMapper _iStudentAPIMapper;

        public SubmissionAPIMapper(IAssignmentAPIMapper AssignmentAPIMapper, IStudentAPIMapper studentAPIMapper)
        {
            _iAssignmentAPIMapper = AssignmentAPIMapper;
            _iStudentAPIMapper = studentAPIMapper;
        }

        public SubmissionModel Map(SubmissionAPIModel submissionAPIModel)
        {
            if (submissionAPIModel == null)
            {
                return null;
            }

            var studentModel = _iStudentAPIMapper.Map(submissionAPIModel.Student);
            var assignModel = _iAssignmentAPIMapper.Map(submissionAPIModel.Assignment);
            
            var att = new SubmissionModel();
            att.Assignment = assignModel;
            att.Grade = submissionAPIModel.Grade;
            att.Link = submissionAPIModel.Link;
            att.Remark = submissionAPIModel.Remark;
            att.Student = studentModel;
            return att;

            //return new SubmissionModel
            //{
            //    SubmissionStatus = Submission,
            //    Student = studentModel,
            //    Assignment = labModel
            //};

            //SubmissionModel SubmissionModel = new SubmissionModel(Submission, studentModel, labModel);

            //return SubmissionModel;
        }

        public SubmissionAPIModel Map(SubmissionModel submissionModel)
        {
            if (submissionModel == null)
            {
                return null;
            }
                        
            var studentAPIModel = _iStudentAPIMapper.Map(submissionModel.Student);
            var assignAPIModel = _iAssignmentAPIMapper.Map(submissionModel.Assignment);

            return new SubmissionAPIModel
            {
                Student = _iStudentAPIMapper.Map(submissionModel.Student),
                Link = submissionModel.Link,
                Grade = submissionModel.Grade,
                Remark = submissionModel.Remark,
                Assignment = _iAssignmentAPIMapper.Map(submissionModel.Assignment)
            };


            //SubmissionAPIModel SubmissionAPIModel = new SubmissionAPIModel(Submission, studentAPIModel, labAPIModel);

            //return SubmissionAPIModel;

        }
    }
}