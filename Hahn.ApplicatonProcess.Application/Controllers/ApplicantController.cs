using FluentValidation.Results;
using Hahn.ApplicatonProcess.December2020.Web.Models;
using Hahn.ApplicatonProcess.December2020.Web.Utilities.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public ActionResult<ApplicantModel> CreateApplicant([FromBody] ApplicantModel applicantModel)
        {

            try
            {

                ApplicantValidator validator = new ApplicantValidator();

                ValidationResult result = validator.Validate(applicantModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            //pet.Id = _petsInMemoryStore.Any() ?
            //         _petsInMemoryStore.Max(p => p.Id) + 1 : 1;
            //_petsInMemoryStore.Add(pet);

            //return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
        }

        [HttpGet]
        public ActionResult<ApplicantModel> GetApplicant(string id)
        {

            try
            {

               
                return Ok();
            }
            catch (Exception ex)
            {
             
                return BadRequest();
            }
           
        }
    }

}
