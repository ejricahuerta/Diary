namespace Diary2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Diary2.Models;

    public partial class ModelEntities : DbContext
    {
        public ModelEntities()
            : base("name=ModelEntities")
        {
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
