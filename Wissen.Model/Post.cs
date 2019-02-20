using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wissen.Model
{
    public class Post:BaseEntity
    {
        [Required]
        [Display(Name ="Başlık")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
