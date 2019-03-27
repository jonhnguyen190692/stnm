namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sieuthin.Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(50)]
        [DisplayName("Mã sản phẩm")]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [DisplayName("Mô tả sản phẩm")]
        public string Description { get; set; }

        [StringLength(250)]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        [DisplayName("Danh sách hình")]
        public string MoreImages { get; set; }

        [DisplayName("Giá khuyến mãi")]
        public decimal? PromotionPrice { get; set; }

        [DisplayName("Giá sản phẩm")]
        public decimal? Price { get; set; }

        [DisplayName("Đã tính thuế chưa?")]
        public bool? IncludeVAT { get; set; }

        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }

        [DisplayName("Loại sản phẩm")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Chi tiết sản phẩm")]
        public string Detail { get; set; }

        [StringLength(10)]
        [DisplayName("Bảo hành")]
        public string Waranty { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(250)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        [DisplayName("Trạng thái")]
        public bool? Status { get; set; }

        [DisplayName("Sản phẩm hot")]
        public DateTime? TopHot { get; set; }

        [DisplayName("Lượt xem")]
        public int? ViewCount { get; set; }
    }
}
