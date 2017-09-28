using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookstore.Models
{
    public class ExperimentModels
    {
        [Key] // Remember to click Ctrl and . (dot)
        public int ID { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Up to 40 characters only.")]
        [Required(ErrorMessage = "Required!!!")]
        public string LN { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "NOOO!")]
        [Required(ErrorMessage = "Required!!!")]
        public string FN { get; set; }

        [Display(Name = "Phone")]
        [MaxLength(12, ErrorMessage = "Really?")]
        [Required(ErrorMessage = "Required!!!")]
        public string Phone { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        [MaxLength(100, ErrorMessage = "Invalid character length.")]
        public string Address { get; set; }
    }
}