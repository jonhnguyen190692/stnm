namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MenuLevel3
    {
        [Key]
        public int IDMenuLevel3 { get; set; }

        [StringLength(255)]
        [DisplayName("Tên hiển thị")]
        public string Name { get; set; }

        [DisplayName("Trạng thái")]
        public bool? Status { get; set; }

        [DisplayName("Thứ tự hiển thị")]
        public int? Position { get; set; }

        [DisplayName("Menu cha")]
        public int? IDMenuLevel2 { get; set; }

        public virtual MenuLevel2 MenuLevel2 { get; set; }
    }
}
