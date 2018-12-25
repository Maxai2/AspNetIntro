using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class AccountToken
    {
        public int AccountId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
    }
}
