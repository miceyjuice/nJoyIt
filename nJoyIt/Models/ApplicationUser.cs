using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace nJoyIt.Models
{
    public class ApplicationUser : IdentityUser
    {
        [JsonIgnore]
        public IEnumerable<Review> Review { get; set; }
    }
}
