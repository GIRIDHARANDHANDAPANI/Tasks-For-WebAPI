using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks_For_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDetailsController : ControllerBase
    {
        ICourseDetailsRepository course = null;
        public CourseDetailsController(ICourseDetailsRepository cours)
        {
            course = cours;
        }
        // GET: api/<CourseDetailsController>
        [HttpGet]
        public IEnumerable<CourseDetails> Get()
        {
            return course.SelectALLStudent();
        }

        // GET api/<CourseDetailsController>/5
        [HttpGet("{username}")]
        public CourseDetails Get(string username)
        {
            return course.SelectUserByName(username);
        }

        // POST api/<CourseDetailsController>
        [HttpPost]
        public void Post([FromBody] CourseDetails cours)
        {
            course.RegisterUser(cours);
        }

        // PUT api/<CourseDetailsController>/5
        [HttpPut]
        public void Put( [FromBody] CourseDetails value)
        {
            course.UpdateUser(value);
        }

        // DELETE api/<CourseDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            course.DeleteUser(id);
        }
    }
}
