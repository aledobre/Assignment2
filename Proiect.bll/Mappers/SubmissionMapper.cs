using Proiect.bll.Contracts;
using Proiect.bll.Models;
using Proiect.dal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.bll.Mappers
{
    public class SubmissionMapper : ISubmissionMapper
    {

        private IAssignmentMapper _iAssignmentMapper;
        private IStudentMapper _iStudentMapper;
        private IStudentService _iStudentService;
        private IAssignmentService _iAssignmentService;

        public SubmissionMapper(IAssignmentMapper assignmentMapper, IStudentMapper studentMapper, IStudentService studentService, IAssignmentService assignmentService)
        {
            _iAssignmentMapper = assignmentMapper;
            _iStudentMapper = studentMapper;
            _iStudentService = studentService;
            _iAssignmentService = assignmentService;
        }

        public SubmissionModel Map(SubmissionDTO submissionDTO)
        {
            if (submissionDTO == null)
            {
                return null;
            }

            submissionDTO.Student = _iStudentMapper.Map(_iStudentService.GetById(submissionDTO.StudentId));
            submissionDTO.Assignment = _iAssignmentMapper.Map(_iAssignmentService.GetById(submissionDTO.AssignmentId));

            var studentModel = _iStudentMapper.Map(submissionDTO.Student);
            var assigModel = _iAssignmentMapper.Map(submissionDTO.Assignment);

            return new SubmissionModel
            {
                Id = submissionDTO.Id,
                StudentId = studentModel.Id,
                Student = studentModel,
                AssignmentId = assigModel.Id,
                Assignment = assigModel,
                Link = submissionDTO.Link,
                Remark = submissionDTO.Remark,
                Grade = submissionDTO.Grade
            };
        }

        public SubmissionDTO Map(SubmissionModel submissionModel)
        {
            if (submissionModel == null)
            {
                return null;
            }

            var student = _iStudentService.GetByUsername(submissionModel.Student.Username);
            var Assignment = _iAssignmentService.GetById(submissionModel.Assignment.Id);

            var studentDTO = _iStudentMapper.Map(submissionModel.Student);
            var assignDTO = _iAssignmentMapper.Map(submissionModel.Assignment);

            return new SubmissionDTO
            {
                Id = submissionModel.Id,
                StudentId = studentDTO.Id,
                Student = studentDTO,
                AssignmentId = assignDTO.Id,
                Assignment = assignDTO,
                Link = submissionModel.Link,
                Remark = submissionModel.Remark,
                Grade = submissionModel.Grade

            };
        }
    }
}
