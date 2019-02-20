using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Data.Builders;
using Wissen.Model;

namespace Wissen.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
            public virtual DbSet<Category> Categories { get; set; }
            public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            new CategoryBuilder(modelBuilder.Entity<Category>());
            new PostBuilder(modelBuilder.Entity<Post>());
        }
    }   
}
