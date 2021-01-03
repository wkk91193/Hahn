using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Utilities.Validators
{
    public class ApplicantValidator : AbstractValidator<ApplicantModel>
    {
        public ApplicantValidator()
        {
            RuleFor(applicant => applicant.Name).NotEmpty();
            RuleFor(applicant => applicant.FamilyName).NotEmpty();
            RuleFor(applicant => applicant.Address).NotEmpty();
            RuleFor(applicant => applicant.EmailAddress).NotEmpty();
            RuleFor(applicant => applicant.Age).NotEmpty();
            RuleFor(applicant => applicant.Hired).NotEmpty();

            RuleFor(applicant => applicant.Name).MinimumLength(5);
            RuleFor(applicant => applicant.FamilyName).MinimumLength(5);
            RuleFor(applicant => applicant.Address).MinimumLength(10);

            RuleFor(applicant => applicant.EmailAddress).EmailAddress();
            RuleFor(applicant => applicant.Age).InclusiveBetween(20, 60);
      
            RuleFor(applicant => applicant.Hired).Must(x => x == false || x == true);
        }
    }

}
