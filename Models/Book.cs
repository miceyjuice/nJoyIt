using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nJoyIt.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [DisplayName("Publication year")]
        public uint PublicationYear { get; set; }
        
        [Required]
        [StringLength(800)]
        public string Description { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        [Required]
        [DisplayName("Book image URL")]
        public string BookImageUrl { get; set; }
    }
}
