using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookstore.Models
{
    public class AuthorsModels
    {
        [Key] // Remember to click Ctrl and . (dot)
        public int ID { get; set; }

        [Display(Name ="Last Name")]
        [MaxLength(40, ErrorMessage = "Up to 40 characters only.")]
        [Required(ErrorMessage = "Required!!!")]
        public string LN { get; set; }

        [Display(Name ="First Name")]
        [MaxLength(20, ErrorMessage = "NOOO!")]
        [Required(ErrorMessage = "Required!!!")]
        public string FN { get; set; }

        [Display(Name ="Phone")]
        [MaxLength(12, ErrorMessage = "Really?")]
        [Required(ErrorMessage = "Required!!!")]
        public string Phone { get; set; }

        [Display(Name ="Address")]
        [DataType(DataType.MultilineText)]
        [MaxLength(40, ErrorMessage = "Invalid character length.")]
        public string Address { get; set; }

        [Display(Name ="City")]
        [MaxLength(20, ErrorMessage = "Invalid character length.")]
        public string City { get; set; }

        [Display(Name ="State")]
        [MaxLength(2, ErrorMessage = "Invalid character length.")]
        public string State { get; set; }

        [Display(Name ="Zip Code")]
        [MaxLength(5, ErrorMessage = "Invalid character length.")]
        public string Zip { get; set; }
    }
}