namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        public int? Parent_ID { get; set; }

        [StringLength(2)]
        public string capp { get; set; }

        public int? Type { get; set; }

        [StringLength(3)]
        public string Lang { get; set; }

        [StringLength(1000)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Url_Name { get; set; }

        [StringLength(1000)]
        public string Link { get; set; }

        [StringLength(1000)]
        public string Styleshow { get; set; }

        public byte? Equals { get; set; }

        [StringLength(500)]
        public string Images { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public DateTime? Create_Date { get; set; }

        public int? Views { get; set; }

        public int? ShowID { get; set; }

        public int? Orders { get; set; }

        [StringLength(500)]
        public string Level { get; set; }

        public byte? News { get; set; }

        public byte? page_Home { get; set; }

        public byte? Status { get; set; }

        [Column(TypeName = "ntext")]
        public string Titleseo { get; set; }

        [Column(TypeName = "ntext")]
        public string Meta { get; set; }

        [Column(TypeName = "ntext")]
        public string Keyword { get; set; }

        public byte? Check_01 { get; set; }

        public byte? Check_02 { get; set; }

        public byte? Check_03 { get; set; }

        public byte? Check_04 { get; set; }

        public byte? Check_05 { get; set; }

        [Column(TypeName = "ntext")]
        public string Noidung1 { get; set; }

        [Column(TypeName = "ntext")]
        public string Noidung2 { get; set; }

        [Column(TypeName = "ntext")]
        public string Noidung3 { get; set; }

        [Column(TypeName = "ntext")]
        public string Noidung4 { get; set; }

        [Column(TypeName = "ntext")]
        public string Noidung5 { get; set; }

        public int? Module { get; set; }

        [StringLength(1000)]
        public string TangName { get; set; }
    }
}
