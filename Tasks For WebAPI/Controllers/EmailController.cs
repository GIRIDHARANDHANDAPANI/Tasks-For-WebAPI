using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Entity;
using BusinessAccessLayer;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks_For_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailRepository _emailrepository;
        private readonly IConfiguration _configuration;
        public EmailController(EmailRepository emailrepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _emailrepository = emailrepository;


        }
        // GET: api/<EmailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmailController>
        [HttpPost]
        public ActionResult<EmailRequest> Post([FromBody] EmailRequest value)
        {
            var fromaddress = _configuration.GetValue<string>("SMTP:FromAddress");
            var password= _configuration.GetValue<string>("SMTP:Password");
            _emailrepository.SendEmail(fromaddress, password, value.ToAddress, value.Subject, value.Body);
            return Ok("Email Sent");
        }

        // PUT api/<EmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
