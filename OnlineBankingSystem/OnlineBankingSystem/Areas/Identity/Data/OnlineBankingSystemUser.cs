﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OnlineBankingSystem.Areas.Identity.Data;

// Add profile data for application users by adding properties to the OnlineBankingSystemUser class
public class OnlineBankingSystemUser : IdentityUser
{
    [Required]
    public string Name { get; set; }
}

