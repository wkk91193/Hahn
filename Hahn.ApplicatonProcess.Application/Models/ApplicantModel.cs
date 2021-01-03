﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Models
{
    public class ApplicantModel
    {
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string Address { get; set; }

        public string CountryOfOrigin { get; set; }

        public string EmailAddress { get; set; }

        public int Age { get; set; }

        public bool Hired { get; set; }
    }
}
