﻿using Hahn.ApplicatonProcess.December2020.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Repository.Interfaces
{
    public interface IApplicantRepository
    {
        Task<bool> Create(Applicant applicant);

        Task<bool> Update(Applicant applicant);

        Applicant Get(int applicantI);

        IOrderedQueryable<Applicant> GetAll();

        Task<bool> Delete(int Id);
    }
}
