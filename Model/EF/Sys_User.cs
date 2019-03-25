namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sieuthin.Sys_User")]
    public partial class Sys_User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserCode { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public bool? Enable { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
