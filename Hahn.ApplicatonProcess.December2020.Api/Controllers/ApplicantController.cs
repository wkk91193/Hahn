using FluentValidation.Results;
using Hahn.ApplicatonProcess.December2020.Api.Utilities.Validators;
using Hahn.ApplicatonProcess.December2020.Data.Models;
using Hahn.ApplicatonProcess.December2020.Domain.Repository;
using Hahn.ApplicatonProcess.December2020.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            this._applicantService = applicantService;
        }

        [HttpPost("CreateApplicant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public ActionResult<Applicant> CreateApplicant([FromBody] Applicant applicantModel)
        {
            if (applicantModel.IsValid(out IEnumerable<string> errors))
            {
                var result = _applicantService.Create(applicantModel);

                return CreatedAtAction(
                   "CreateApplicant",
                   new { URL = "api/Applicant/" + result.Id }, result);
            }
            else
            {

                return BadRequest(errors);
            }

        }

        [HttpPut("UpdateApplicant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateApplicant([FromBody] Applicant applicantModel)
        {
            if (applicantModel.IsValid(out IEnumerable<string> errors))
            {
                var result = await _applicantService.Update(applicantModel);

                return Ok(result);
            }
            else
            {
                return BadRequest(errors);
            }
        }


        [HttpGet("GetAllApplicants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllApplicants()
        {
            var result = _applicantService.GetAll();

            return Ok(result);
        }


        [HttpGet("GetApplicantById/{id}")]
        public ActionResult<Applicant> GetApplicantById(int id)
        {

            if (id > 0)
            {
                var result = _applicantService.Get(id);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteApplicantById/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteApplicantById(int id)
        {
            if (id > 0)
            {
                var result = await _applicantService.Delete(id);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
