using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorOnDemand.Data;
using MentorOnDemand.Dto;
using MentorOnDemand.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorOnDemand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        IRepository adminRepository;
        public AdminController(IRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }
        // GET: api/Admin
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Admin/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost("skill")]
        public IActionResult Post([FromBody] Skill skill)
        {
            if (ModelState.IsValid)
            {
                bool result = adminRepository.AddSkill(skill);
                return Created("AddSkill", skill);
            }
            return BadRequest(ModelState);
        }


        [HttpPost("training")]
        public IActionResult PostTraining([FromBody] TrainingDtls training)
        {
            if (ModelState.IsValid)
            {
                bool result = adminRepository.AddTraining(training);
                return Created("AddTraining", training);
            }
            return BadRequest(ModelState);
        }


        [HttpPost("payment")]
        public IActionResult PostPayment([FromBody] PaymentDtls payment)
        {
            if (ModelState.IsValid)
            {
                bool result = adminRepository.AddPayment(payment);
                return Created("AddPayment", payment);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("getSkills")] 
        public IActionResult GetSkills()
        {
            return Ok(adminRepository.GetSkills());
        }
        [HttpGet("getTrainings")] 
        public IActionResult GetTrainings()
        {
            return Ok(adminRepository.GetTrainings());
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(adminRepository.GetUsers());
        }

        [HttpGet("GetPayments")]
        public IActionResult GetPayments()
        {
            return Ok(adminRepository.GetPayments());
        }

        [HttpGet("GetTrainingById/{id}")]
        public IActionResult GetTrainingById(int id)
        {
            return Ok(adminRepository.GetTrainingById(id));
        }

        [HttpGet("GetPaymentById/{id}")]
        public IActionResult GetPaymentById(int id)
        {
            return Ok(adminRepository.GetPaymentById(id));
        }


        [HttpGet("GetSkill/{id:int}", Name = "GetSkill")]
        public IActionResult Get(int id)
        {
            var skill = adminRepository.GetSkill(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var User = adminRepository.GetUser(id);
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }

        [HttpGet("searchdata")]
        public IActionResult GetSearchData(string trainertechnology)
        {
            if (trainertechnology != null)
            {
                var result = adminRepository.GetSearchData(trainertechnology);
                return Ok(result);
            }
            else
            {
                return Ok("Error Fetching Data");
            }
        }

        [HttpDelete("DeleteSkill/{id}", Name = "DeleteSkill")]
        public IActionResult Delete(int id)
        {
            var skill = adminRepository.GetSkill(id);
            if (skill == null)
            {
                return NotFound();
            }
            bool result = adminRepository.DeleteSkill(skill);
            if (result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("blockunblock/{id}")]
        public IActionResult GetBlockUnblock(string id)
        {
            var result = adminRepository.BlockUser(id);
            if (result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UserProfileDto userProfileDto)
        {
            if (ModelState.IsValid && id == userProfileDto.Id)
            {
                bool result = adminRepository.UpdateUser(id,userProfileDto);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);

        }

        [HttpPut("updatePaymentAndCommisionById/{id}")]
        public IActionResult PutupdatePaymentAndCommisionById(string id, [FromBody] PaymentDto payment)
        {
               adminRepository.PutupdatePaymentAndCommisionById(id, payment);
            return Ok();
        }

        [HttpPut("updateTrainingProgressById")]
        public IActionResult PutupdateTrainingProgressById(int id, int progressValue)
        {
            adminRepository.PutupdateTrainingProgressById(id, progressValue);
            return Ok();
        }


        [HttpPut("updateTrainingRatingById")]
        public IActionResult PutupdateTrainingRatingById(int id, int rating)
        {
            adminRepository.PutupdateTrainingRatingById(id,rating);
            return Ok();
        }

        [HttpPut("acceptrequest/{id}")]
        public IActionResult PutAcceptRequest(int id)
        {
            adminRepository.PutAcceptRequest(id);
            return Ok();
        }

        [HttpPut("rejectrequest/{id}")]
        public IActionResult PutRejectrequest(int id)
        {
            adminRepository.PutRejectrequest(id);
            return Ok();
        }

        [HttpPut("updateTrainingStatusById/{id}")]
        public IActionResult PutupdateTrainingStatusById(int id)
        {
            adminRepository.PutupdateTrainingStatusById(id);
            return Ok();
        }

        [HttpPut("updateTrainingAndPaymentStatusbyId/{id}")]
        public IActionResult PutupdateTrainingAndPaymentStatusbyId(int id)
        {
            adminRepository.PutupdateTrainingAndPaymentStatusbyId(id);
            return Ok();
        }



        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] UserProfileDto user)
        //{
        //    if (ModelState.IsValid && id == user.Id)
        //    {
        //        bool result = adminRepository.UpdateActor(user);
        //        if (result)
        //        {
        //            return Ok();
        //        }
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //    return BadRequest(ModelState);
        //}

        // POST: api/Admin
        //[HttpPost]
        //public IActionResult Post([FromBody] CourseDto courseDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool result = adminRepository.AddCourse(courseDto);
        //        return Created("AddCourse", courseDto);
        //    }
        //    return BadRequest(ModelState);
        //}

        // PUT: api/Admin/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}
