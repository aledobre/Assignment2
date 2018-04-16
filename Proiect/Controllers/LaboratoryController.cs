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
    [RoutePrefix("api/laboratories")]
    public class LaboratoryController : ApiController
    {
        private ILaboratoryService _laboratoryService;
        private ILaboratoryAPIMapper _laboratoryAPIMapper;

        public LaboratoryController(ILaboratoryService laboratoryService, ILaboratoryAPIMapper laboratoryAPIMapper)
        {
            _laboratoryService = laboratoryService;
            _laboratoryAPIMapper = laboratoryAPIMapper;
        }

        [HttpGet]
        [Route("GetBy/{labNumber}")]
        //[ResponseType(typeof(LaboratoryModel))]
        public IHttpActionResult GetByNumber(int labNumber)
        {
            var result = _laboratoryAPIMapper.Map(_laboratoryService.GetByLabNumber(labNumber));

            if (result == null)
            {
                return NotFound();
            }

            return Content(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("GetKeyword/{keyword}")]
        //[ResponseType(typeof(LaboratoryModel))]
        public IHttpActionResult GetByKeyword(string keyword)
        {
            var labList = _laboratoryService.GetByKeyword(keyword);

            if (labList.ToList().Count() == 0)
            {
                return NotFound();
            }

            List<LaboratoryAPIModel> result = new List<LaboratoryAPIModel>();

            labList.ToList().ForEach(l => result.Add(_laboratoryAPIMapper.Map(l)));

            return Content(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            var laboratoryModelList = _laboratoryService.GetAll();

            if (laboratoryModelList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            List<LaboratoryAPIModel> laboratoryAPIModelList = new List<LaboratoryAPIModel>();

            foreach (LaboratoryModel Laboratory in laboratoryModelList)
            {
                laboratoryAPIModelList.Add(_laboratoryAPIMapper.Map(Laboratory));
            }

            return Request.CreateResponse(HttpStatusCode.Created, laboratoryAPIModelList);
        }

        [HttpPost]
        [Route("AddLaboratory")]
        public HttpResponseMessage Create([FromBody] LaboratoryAPIModel laboratoryAPIModel)
        {
            if (_laboratoryService.GetByLabNumber(_laboratoryAPIMapper.Map(laboratoryAPIModel).LabNumber) != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Laboratory already created!");
            }

            else
                if (laboratoryAPIModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _laboratoryService.AddLaboratory(_laboratoryAPIMapper.Map(laboratoryAPIModel));
                return Request.CreateResponse(HttpStatusCode.Created, _laboratoryAPIMapper.Map(laboratoryAPIModel));
            }
        }

        [HttpPut]
        [Route("UpdateLaboratory/{labNumber}")]
        public HttpResponseMessage Update([FromBody]LaboratoryAPIModel laboratoryAPIModel)
        {
            if (laboratoryAPIModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (_laboratoryService.CheckIfLaboratoryExists(laboratoryAPIModel.LabNumber) == true)
            {
                _laboratoryService.UpdateLaboratory(_laboratoryAPIMapper.Map(laboratoryAPIModel));
                return Request.CreateResponse(HttpStatusCode.Created, _laboratoryAPIMapper.Map(laboratoryAPIModel));
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Laboratory not added yet!");
        }

        [HttpDelete]
        [Route("DeleteLaboratory/{labNumber}")]
        public HttpResponseMessage Delete(int labNumber)
        {
            var laboratory = _laboratoryService.GetByLabNumber(labNumber);
            if (laboratory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                _laboratoryService.DeleteLaboratory(laboratory);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

    }
}
