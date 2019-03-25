namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MenuLevel1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuLevel1()
        {
            MenuLevel2 = new HashSet<MenuLevel2>();
        }

        [Key]
        public int IDMenuLevel1 { get; set; }

        [StringLength(255)]
        [DisplayName("Tên hiển thị")]
        public string Name { get; set; }

        [DisplayName("Trạng thái")]
        public bool? Status { get; set; }

        [DisplayName("Thứ tự hiển thị")]
        public int? Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuLevel2> MenuLevel2 { get; set; }
    }
}
