using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS.Models
{
    public class MaterialValidate
    {
        [Required(ErrorMessage = "Material ID")]
        [MaxLength(10, ErrorMessage = "Out of 10 characters")]
        public string MaterialID { get; set; }

        [Required(ErrorMessage = "Material Name")]
        [MaxLength(20, ErrorMessage = "Out of 20 characters")]
        public string MaterialtName { get; set; }

        public int MaterialQuantity { get; set; }

        [Required(ErrorMessage = "Material Unit")]
        [MaxLength(50, ErrorMessage = "Out of 50 characters")]
        public string MaterialUnit { get; set; }
    }
}