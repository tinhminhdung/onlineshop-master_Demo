using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class NewsViewModel
    {
        public int inid { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Images { get; set; }
        public DateTime? Create_Date { get; set; }
        public string TangName { get; set; }
        public string CateName { set; get; }
        public string CateID { set; get; }

        [ForeignKey("icid")]
        public virtual Menu Menu { set; get; }

    }
}
