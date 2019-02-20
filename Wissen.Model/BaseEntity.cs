using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wissen.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Display(Name ="Oluşturan")]
        public string CreatedBy { get; set; }
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Güncelleyen")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Güncellenme Tarihi")]
        public DateTime UpdatedAt { get; set; }
    }
}
