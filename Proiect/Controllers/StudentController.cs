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
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        private IStudentService _studentService;
        private IStudentAPIMapper _studentAPIMapper;
        public StudentController(IStudentService studentService, IStudentAPIMapper studentAPIMapper)
        {
            _studentService = studentService;
            _studentAPIMapper = studentAPIMapper;
        }

        [HttpGet]
        [Route("GetBy/{username}")]
        //[ResponseType(typeof(StudentModel))]
        public IHttpActionResult Get(string username)
        {
            var result = _studentAPIMapper.Map(_studentService.GetByUsername(username));

            if (result == null)
            {
                return NotFound();
            }
            
            return Content(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            var studentModelList = _studentService.GetAll();

            if (studentModelList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            List<StudentAPIModel> studentAPIModelList = new List<StudentAPIModel>();

            foreach (StudentModel student in studentModelList)
            {
                studentAPIModelList.Add(_studentAPIMapper.Map(student));
            }

            return Request.CreateResponse(HttpStatusCode.Created, studentAPIModelList);
        }

        [HttpPost]
        [Route("AddStudent")]
        public HttpResponseMessage Create([FromBody] StudentAPIModel studentAPIModel)
        {
            if (_studentService.GetByUsername(_studentAPIMapper.Map(studentAPIModel).Username) != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Username already used!");
            }

            else
                if (studentAPIModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _studentService.AddStudent(_studentAPIMapper.Map(studentAPIModel));
                return Request.CreateResponse(HttpStatusCode.Created, _studentAPIMapper.Map(studentAPIModel));
            }
        }

        [HttpPut]
        [Route("UpdateStudent/{username}")]
        public HttpResponseMessage Update([FromBody]StudentAPIModel studentAPIModel)
        {
            if (studentAPIModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (_studentService.CheckIfStudentExists(studentAPIModel.Username) == true)
            {
                _studentService.UpdateStudent(_studentAPIMapper.Map(studentAPIModel));
                return Request.CreateResponse(HttpStatusCode.Created, _studentAPIMapper.Map(studentAPIModel));
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Student is not enrolled in this class!");
        }

        [HttpDelete]
        [Route("DeleteStudent/{username}")]
        public HttpResponseMessage Delete(string username)
        {
            var student = _studentService.GetByUsername(username);
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                _studentService.DeleteStudent(student);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

    }
}
