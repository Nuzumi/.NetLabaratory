using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLaboratory.Model
{
    public class NetContext : DbContext
    {
        public static string connString = "Data Source=LAPTOP-9BBKLGE9\\MILENA;Initial Catalog=NetLab;Integrated Security=True; App=EntityFramework";
         public NetContext()
         : base(connString)
         {
         }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
        }


        public virtual IDbSet<Article> Articles { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
    }
}
