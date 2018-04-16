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
    [RoutePrefix("api/attendance")]
    public class AttendanceController : ApiController
    {
        private IAttendanceService _attendanceService;
        private IAttendanceAPIMapper _attendanceAPIMapper;
        private IAttendanceAPIShortMapper _attendanceAPIShortModel;

        public AttendanceController(IAttendanceAPIShortMapper attendanceAPIShortModel, IAttendanceService attendanceService, IAttendanceAPIMapper attendanceAPIMapper)
        {
            _attendanceService = attendanceService;
            _attendanceAPIMapper = attendanceAPIMapper;
            _attendanceAPIShortModel = attendanceAPIShortModel;
        }

        [HttpGet]
        [Route("GetByLab/{labNumber}")]
        //[ResponseType(typeof(attendanceModel))]
        public HttpResponseMessage GetByNumber(int labNumber)
        {
            var attendanceModelList = _attendanceService.GetByLabNumber(labNumber);

            if (attendanceModelList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            List<AttendanceAPIModel> attendanceAPIModelList = new List<AttendanceAPIModel>();

            foreach (AttendanceModel attendance in attendanceModelList)
            {
                attendanceAPIModelList.Add(_attendanceAPIMapper.Map(attendance));
            }

            return Request.CreateResponse(HttpStatusCode.Created, attendanceAPIModelList);
        }

        [HttpGet]
        [Route("GetByStudent/{username}")]
        //[ResponseType(typeof(attendanceModel))]
        public HttpResponseMessage GetByUsername(string username)
        {
            var attendanceModelList = _attendanceService.GetByStudent(username);

            if (attendanceModelList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            List<AttendanceAPIModel> attendanceAPIModelList = new List<AttendanceAPIModel>();

            foreach (AttendanceModel attendance in attendanceModelList)
            {
                attendanceAPIModelList.Add(_attendanceAPIMapper.Map(attendance));
            }

            return Request.CreateResponse(HttpStatusCode.Created, attendanceAPIModelList);
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            var attendanceModelList = _attendanceService.GetAll();

            if (attendanceModelList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            List<AttendanceAPIModel> attendanceAPIModelList = new List<AttendanceAPIModel>();

            foreach (AttendanceModel attendance in attendanceModelList)
            {
                attendanceAPIModelList.Add(_attendanceAPIMapper.Map(attendance));
            }

            return Request.CreateResponse(HttpStatusCode.Created, attendanceAPIModelList);
        }

        [HttpPut]
        [Route("UpdateAttendance/{labNumber}")]
        public HttpResponseMessage Update([FromBody]AttendanceAPIShortModel attendanceAPIShortModel)
        {
            if (attendanceAPIShortModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var toUpdate = _attendanceService.GetByLabAndStud(attendanceAPIShortModel.LabNumber, attendanceAPIShortModel.Username);
            if (toUpdate.Id != 0)
            {
                _attendanceService.UpdateAttendance(new AttendanceModel { Id = toUpdate.Id, AttendanceStatus = attendanceAPIShortModel.AttendanceStatus == "Present" });
                return Request.CreateResponse(HttpStatusCode.Created, toUpdate.ToString());
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Attendance not added yet!");
        }

        [HttpDelete]
        [Route("DeleteAttendance/{labNumber}/{username}")]
        public HttpResponseMessage Delete(int labNumber, string username)
        {
            var attendance = _attendanceService.GetByLabAndStud(labNumber, username);

            if (attendance == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                _attendanceService.DeleteAttendance(attendance);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPost]
        [Route("AddAttendance")]
        public HttpResponseMessage Create([FromBody] AttendanceAPIShortModel attendanceAPIShortModel)
        {
            var attend = _attendanceService.GetByLabAndStud(attendanceAPIShortModel.LabNumber, attendanceAPIShortModel.Username);
            if (attend.Laboratory != null || attend.Student != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Attendance already created!");
            }

            else
                if (attendanceAPIShortModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var att1 = _attendanceAPIShortModel.Map(attendanceAPIShortModel);
                var att = _attendanceAPIMapper.Map(att1);
                _attendanceService.AddAttendance(att);
                return Request.CreateResponse(HttpStatusCode.Created, _attendanceAPIMapper.Map(_attendanceAPIShortModel.Map(attendanceAPIShortModel)));
            }
        }

    }
}
