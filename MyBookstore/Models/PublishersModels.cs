using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookstore.Controllers
{
    public class PublishersModels
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Name")]
        [MaxLength(40, ErrorMessage = "Enough!")]
        [Required(ErrorMessage = "Need this mate!")]
        public string Name { get; set; }

    }
}