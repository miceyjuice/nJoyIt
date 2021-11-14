using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nJoyIt.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Review")]
        [StringLength(255)]
        public string ReviewContent { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReviewDate { get; set; }
    }
}
