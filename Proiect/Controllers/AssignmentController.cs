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
    [RoutePrefix("api/assignment")]
    public class AssignmentController : ApiController
    {
        private IAssignmentService _assignmentService;
        private IAssignmentAPIMapper _assignmentAPIMapper;
        private IAssignmentAPIShortMapper _assignmentAPIShortModel;

        public AssignmentController(IAssignmentAPIShortMapper assignmentAPIShortModel, IAssignmentService assignmentService, IAssignmentAPIMapper assignmentAPIMapper)
        {
            _assignmentService = assignmentService;
            _assignmentAPIMapper = assignmentAPIMapper;
            _assignmentAPIShortModel = assignmentAPIShortModel;
        }

        [HttpGet]
        [Route("GetByLab/{labNumber}")]
        //[ResponseType(typeof(assignmentModel))]
        public HttpResponseMessage GetByNumber(int labNumber)
        {
            var assignmentModelList = _assignmentService.GetByLabNumber(labNumber);

            if (assignmentModelList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            List<AssignmentAPIModel> assignmentAPIModelList = new List<AssignmentAPIModel>();

            foreach (AssignmentModel assignment in assignmentModelList)
            {
                assignmentAPIModelList.Add(_assignmentAPIMapper.Map(assignment));
            }

            return Request.CreateResponse(HttpStatusCode.Created, assignmentAPIModelList);
        }


        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            var assignmentModelList = _assignmentService.GetAll();

            if (assignmentModelList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            List<AssignmentAPIModel> assignmentAPIModelList = new List<AssignmentAPIModel>();

            foreach (AssignmentModel assignment in assignmentModelList)
            {
                assignmentAPIModelList.Add(_assignmentAPIMapper.Map(assignment));
            }

            return Request.CreateResponse(HttpStatusCode.Created, assignmentAPIModelList);
        }

        [HttpPut]
        [Route("UpdateAssignment/{labNumber}")]
        public HttpResponseMessage Update([FromBody]AssignmentAPIShortModel assignmentAPIShortModel)
        {
            if (assignmentAPIShortModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (_assignmentService.CheckIfAssignmentExists(assignmentAPIShortModel.LabNumber, assignmentAPIShortModel.Name) == true)
            {
                _assignmentService.UpdateAssignment(_assignmentAPIMapper.Map(_assignmentAPIShortModel.Map(assignmentAPIShortModel)));
                return Request.CreateResponse(HttpStatusCode.Created, _assignmentAPIMapper.Map(_assignmentAPIShortModel.Map(assignmentAPIShortModel)));
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Assignment not added yet!");
        }

        [HttpDelete]
        [Route("DeleteAssignment/{labNumber}/{name}")]
        public HttpResponseMessage Delete(int labNumber, string name)
        {
            var assignment = _assignmentService.GetByLabAndName(labNumber, name);

            if (assignment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                _assignmentService.DeleteAssignment(assignment);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPost]
        [Route("AddAssignment")]
        public HttpResponseMessage Create([FromBody] AssignmentAPIShortModel assignmentAPIShortModel)
        {
            var assign = _assignmentService.GetByLabAndName(assignmentAPIShortModel.LabNumber, assignmentAPIShortModel.Name);
            if (assign.Laboratory != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Assignment already created!");
            }

            else
                if (assignmentAPIShortModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var att1 = _assignmentAPIShortModel.Map(assignmentAPIShortModel);
                var att = _assignmentAPIMapper.Map(att1);
                _assignmentService.AddAssignment(att);
                return Request.CreateResponse(HttpStatusCode.Created, _assignmentAPIMapper.Map(_assignmentAPIShortModel.Map(assignmentAPIShortModel)));
            }
        }
    }
}
