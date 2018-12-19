using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class User : IdentityUser
    {
        public int Gender { get; set; }
    }

    public enum GenderEnum
    {
        Male = 1,
        Female = 2,
        Undefined = 3
    }
}
