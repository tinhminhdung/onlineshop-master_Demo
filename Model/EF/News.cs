namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("News")]
    public partial class News
    {
        [Key]
        public int inid { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Nhóm")]
        public int icid { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề")]
        [StringLength(1000)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Brief { get; set; }

        [Column(TypeName = "ntext")]
        public string Contents { get; set; }

        [Column(TypeName = "ntext")]
        public string Keywords { get; set; }

        [Column(TypeName = "ntext")]
        public string search { get; set; }

        [Column(TypeName = "ntext")]
        public string Images { get; set; }

        [Column(TypeName = "ntext")]
        public string ImagesSmall { get; set; }

        public bool Equals { get; set; }

        public bool Chekdata { get; set; }

        public DateTime? Create_Date { get; set; }

        public DateTime? Modified_Date { get; set; }

        public int? Views { get; set; }

        [Column(TypeName = "ntext")]
        public string Tags { get; set; }

        [StringLength(50)]
        public string lang { get; set; }

        public bool New { get; set; }

        public bool CheckBox1 { get; set; }

        public bool CheckBox2 { get; set; }

        public bool CheckBox3 { get; set; }

        public bool CheckBox4 { get; set; }

        public bool CheckBox5 { get; set; }

        public bool CheckBox6 { get; set; }

        public bool Status { get; set; }

        [Column(TypeName = "ntext")]
        public string Titleseo { get; set; }

        [Column(TypeName = "ntext")]
        public string Meta { get; set; }

        [Column(TypeName = "ntext")]
        public string Keyword { get; set; }

        [StringLength(1000)]
        public string TangName { get; set; }

        [ForeignKey("icid")]
        public virtual Menu Menu { set; get; }
    }
}
