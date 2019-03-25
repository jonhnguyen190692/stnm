namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<MenuLevel1> MenuLevel1 { get; set; }
        public virtual DbSet<MenuLevel2> MenuLevel2 { get; set; }
        public virtual DbSet<MenuLevel3> MenuLevel3 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
