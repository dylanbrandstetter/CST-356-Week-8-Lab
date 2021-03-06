﻿using CST356_Week_5_Lab.Data.Entities;
using CST356_Week_5_Lab.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST356_Week_5_Lab.Data.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime NextCheckup { get; set; }

        public string VetName { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}