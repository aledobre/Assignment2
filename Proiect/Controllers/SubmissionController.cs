using Proiect.bll.Contracts;
using Proiect.bll.Models;
using Proiect.Contracts;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proiect.Controllers
{

    [RoutePrefix("api/submission")]
    public class SubmissionController : ApiController
    {
        private ISubmissionService _submissionService;
        private ISubmissionAPIMapper _submissionAPIMapper;
        private ISubmissionAPIShortMapper _submissionAPIShortModel;

        public SubmissionController(ISubmissionAPIShortMapper submissionAPIShortModel, ISubmissionService submissionService, ISubmissionAPIMapper submissionAPIMapper)
        {
            _submissionService = submissionService;
            _submissionAPIMapper = submissionAPIMapper;
            _submissionAPIShortModel = submissionAPIShortModel;
        }

        //[HttpGet]
        //[Route("GetByLab/{AssignmentName}")]
        ////[ResponseType(typeof(SubmissionModel))]
        //public HttpResponseMessage GetByAssignment(string assignmentName)
        //{
        //    var submissionModelList = _submissionService.GetByAssignName(assignmentName);

        //    if (submissionModelList.Count == 0)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    List<SubmissionAPIModel> SubmissionAPIModelList = new List<SubmissionAPIModel>();

        //    foreach (SubmissionModel Submission in SubmissionModelList)
        //    {
        //        SubmissionAPIModelList.Add(_SubmissionAPIMapper.Map(Submission));
        //    }

        //    return Request.CreateResponse(HttpStatusCode.Created, SubmissionAPIModelList);
        //}

        [HttpGet]
        [Route("GetByAssignmentAndStudent/{username}/{assignmentName}")]
        //[ResponseType(typeof(SubmissionModel))]
        public HttpResponseMessage GetByAssigAndStudent(string assignName, string studentUsername)
        {
            var submissionModelList = _submissionService.GetByAssigAndStudent(assignName, studentUsername);

            if (submissionModelList == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.Created, _submissionAPIMapper.Map(submissionModelList));
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            var submissionModelList = _submissionService.GetAll();

            if (submissionModelList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            List<SubmissionAPIModel> SubmissionAPIModelList = new List<SubmissionAPIModel>();

            foreach (SubmissionModel Submission in submissionModelList)
            {
                SubmissionAPIModelList.Add(_submissionAPIMapper.Map(Submission));
            }

            return Request.CreateResponse(HttpStatusCode.Created, SubmissionAPIModelList);
        }

        [HttpPut]
        [Route("UpdateSubmission/{LabNumber}/{Username}")]
        public HttpResponseMessage Update([FromBody]SubmissionAPIShortModel SubmissionAPIShortModel)
        {
            if (SubmissionAPIShortModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (_submissionService.CheckIfSubmissionExists(SubmissionAPIShortModel.AssignmentName, SubmissionAPIShortModel.StudentUsername) == true)
            {
                _submissionService.UpdateSubmission(_submissionAPIMapper.Map(_submissionAPIShortModel.Map(SubmissionAPIShortModel)));
                return Request.CreateResponse(HttpStatusCode.Created, _submissionAPIMapper.Map(_submissionAPIShortModel.Map(SubmissionAPIShortModel)));
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Submission not added yet!");
        }

        [HttpPost]
        [Route("AddSubmission")]
        public HttpResponseMessage Create([FromBody] SubmissionAPIShortModel submissionAPIShortModel)
        {
            var submission = _submissionService.GetByAssigAndStudent(submissionAPIShortModel.AssignmentName, submissionAPIShortModel.StudentUsername);
            //if (submission.Assignment != null || submission.Student != null)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Submission already created!");
            //}

            //else
            if (submissionAPIShortModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var att1 = _submissionAPIShortModel.Map(submissionAPIShortModel);
                var att = _submissionAPIMapper.Map(att1);
                _submissionService.AddSubmission(att);
                return Request.CreateResponse(HttpStatusCode.Created, _submissionAPIMapper.Map(_submissionAPIShortModel.Map(submissionAPIShortModel)));
            }
        }

    }

}
