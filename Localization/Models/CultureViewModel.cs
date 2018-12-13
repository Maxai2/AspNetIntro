using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Localization.Models
{
    public class CultureViewModel
    {
        [Display(Name = "CultureDisplay")]
        public string Culture { get; set; }

        [Display(Name = "CultureUIDisplay")]
        public string UICulture { get; set; }
    }
}
