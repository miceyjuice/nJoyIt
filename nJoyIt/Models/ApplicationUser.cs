using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace nJoyIt.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Review> Review { get; set; }
    }
}
