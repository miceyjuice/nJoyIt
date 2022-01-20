using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Models;

namespace nJoyIt.ViewModels
{
    public class BookDetailsViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Review> Review { get; set; } 
    }
}
