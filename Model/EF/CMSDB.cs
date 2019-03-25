namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CMSDB : DbContext
    {
        public CMSDB()
            : base("name=CMSDB")
        {
        }

        public virtual DbSet<Sys_User> Sys_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sys_User>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<Sys_User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);
        }
    }
}
