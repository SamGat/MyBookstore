using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyBookstore.Models
{
    public class TypesModels
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Name")]
        [MaxLength(40, ErrorMessage = "Enough!")]
        [Required(ErrorMessage = "Need this mate!")]
        public string Name { get; set; }
    }
}