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

        [Required(ErrorMessage = "This field is required!")]
        [MinLength(3, ErrorMessage = "Title is too short!"), MaxLength(255, ErrorMessage = "Title is too short!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MinLength(3, ErrorMessage = "Author name is too short!"), MaxLength(100, ErrorMessage = "Author name is too long!")]
        public string Author { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MinLength(3, ErrorMessage = "Genre name is too short!"), MaxLength(50, ErrorMessage = "Genre name is too long!")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DisplayName("Publication year")]
        [Range(1000, 2021, ErrorMessage = "Publication year must be between 1000 and 2021!")]
        public uint PublicationYear { get; set; }
        
        [Required(ErrorMessage = "This field is required!")]
        [MinLength(5, ErrorMessage = "Description is too short!")]
        public string Description { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DisplayName("Book image URL")]
        [Url(ErrorMessage = "Wrong URL format!")]
        public string BookImageUrl { get; set; }
    }
}
