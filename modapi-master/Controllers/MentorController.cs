using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorOnDemand.Data;
using MentorOnDemand.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorOnDemand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MentorController : ControllerBase
    {
        IRepository mentorRepository;
        public MentorController(IRepository mentorRepository)
        {
            this.mentorRepository = mentorRepository;
        }



        [HttpPut("acceptrequest/{id}")]
        public IActionResult PutAcceptRequest(int id)
        {
            mentorRepository.PutAcceptRequest(id);
            return Ok();
        }

        [HttpPut("rejectrequest/{id}")]
        public IActionResult PutRejectrequest(int id)
        {
            mentorRepository.PutRejectrequest(id);
            return Ok();
        }



        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UserProfileDto userProfileDto)
        {
            if (ModelState.IsValid && id == userProfileDto.Id)
            {
                bool result = mentorRepository.UpdateUser(id, userProfileDto);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);

        }
    }
}