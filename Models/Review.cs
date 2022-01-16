using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace nJoyIt.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DisplayName("Review")]
        [MinLength(10, ErrorMessage = "Your review is too short!"), MaxLength(300, ErrorMessage = "Your review is too long!")]
        public string ReviewContent { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public Book Book { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReviewDate { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}
