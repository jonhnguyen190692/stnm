namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MenuLevel2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuLevel2()
        {
            MenuLevel3 = new HashSet<MenuLevel3>();
        }

        [Key]
        public int IDMenuLevel2 { get; set; }

        [StringLength(255)]
        [DisplayName("Tên hiển thị")]
        public string Name { get; set; }

        [DisplayName("Trạng thái")]
        public bool? Status { get; set; }

        [DisplayName("Thứ tự hiển thị")]
        public int? Position { get; set; }

        [DisplayName("Menu cha")]
        public int? IDMenuLevel1 { get; set; }

        public virtual MenuLevel1 MenuLevel1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuLevel3> MenuLevel3 { get; set; }
    }
}
