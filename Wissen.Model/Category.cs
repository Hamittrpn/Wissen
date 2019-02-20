using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wissen.Model
{
    public class Category:BaseEntity
    {

        public Category()
        {
            Posts = new HashSet<Post>();
        }
        [Display(Name="Ad")]
        [Required]
        public string Name { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
