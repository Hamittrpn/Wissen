using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wissen.Models
{
    public class DenemeForm
    {
        [Required(ErrorMessage ="{0} alanı gereklidir !")]
        [MaxLength(50, ErrorMessage ="{0} alanı en fazla {1} karakter uzunluğunda olabilir !")]
        [Display(Name ="Ad")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name ="Soyad")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        [Display(Name ="E-posta")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [MaxLength(20)]
        [Display(Name ="Telefon")]
        //[RegularExpression(@" ^ 5(0[5 - 7] | [3 - 5]\d) ?\d{ 3 } ?\d{ 4}$", ErrorMessage = " Telefon numarası biçimi hatalı !")]

        public string Phone { get; set; }
    }
}