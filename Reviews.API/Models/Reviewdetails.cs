using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.API.Models
{
    public class Reviewdetails
    {
        public int ReviewdetailsId { get; set; }
        public string UserName { get; set; } 
        public string ProductName { get; set; } 
        public string Value { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
    }
}
