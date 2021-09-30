using Model.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ViewModel;

namespace Model.Dao
{
    public class NewsDao
    {
        OnlineShopDbContext db = null;
        public static string USER_SESSION = "USER_SESSION";
        public NewsDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(News News)
        {
            db.News.Add(News);
            db.SaveChanges();

            // Ví dụ thêm vào bảng con
            if (News.inid > 0)
            {
                Menu item = new Menu();
                item.Name = News.Title;
                item.Parent_ID = News.icid;
                db.Menus.Add(item);
                db.SaveChanges();
            }
            return News.inid;
        }

        public IEnumerable<News> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<News> model = db.News;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString) || x.Title.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Create_Date).ToPagedList(page, pageSize);
        }
        public IEnumerable<News> ListAllPagingindex(int page, int pageSize)
        {
            IQueryable<News> model = db.News;
            return model.OrderByDescending(x => x.Create_Date).ToPagedList(page, pageSize);
        }
        public IEnumerable<News> ListAllPagingCate(int id, int page, int pageSize)
        {
            //var query = (from p in db.News
            //             join q in db.Menus on p.icid equals q.Parent_ID
            //             select new { 
            //                 ParentName = db.News.Where(c => c.icid == p.icid).FirstOrDefault().Title, 
            //                 Title = p.Title
            //             }).ToList();

            IEnumerable<News> model = db.News;
            return model.OrderByDescending(x => x.Create_Date).ToPagedList(page, pageSize);
        }
        public IEnumerable<NewsViewModel> ListAllPagingCate(long categoryID, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.News.Where(x => x.icid == categoryID).Count();
            var model = (from a in db.News
                         join b in db.Menus
                         on a.icid equals b.ID
                         where a.icid == categoryID && b.capp == "NS"
                         select new
                         {
                             inid = a.inid,
                             Title = a.Title,
                             Brief = a.Brief,
                             Images = a.Images,
                             Create_Date = a.Create_Date,
                             TangName = a.TangName,
                             CateName = b.Name,
                             CateID = b.ID
                         }).AsEnumerable().Select(x => new NewsViewModel()
                         {
                             inid = x.inid,
                             Title = x.Title,
                             Brief = x.Brief,
                             Images = x.Images,
                             Create_Date = x.Create_Date,
                             TangName = x.TangName,
                             CateName = x.CateName,
                             CateID = x.CateID.ToString()
                         });
            model.OrderByDescending(x => x.Create_Date).Skip((page - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        //public IEnumerable<News> ListAllPagingCate(int id, int page, int pageSize)
        //{
        //    string submn = "";
        //    IQueryable<News> model = db.News;
        //    if (!string.IsNullOrEmpty(id.ToString()))
        //    {
        //        //List<News> listpro = new List<News>();
        //        //var dt = db.Menus.Where(x => x.capp == "NS" && x.ID == id);
        //        //foreach (var item in dt)
        //        //{
        //        //    submn = submn + "," + item.ID.ToString();
        //        //}

        //        int pageid = Convert.ToInt32(id);
        //        string strcatlevel = db.Menus.Where(u => u.ID == pageid).FirstOrDefault().Level;
        //        List<News> listpro = new List<News>();
        //        var pagelistid = db.Menus.Where(u => u.Level.Substring(0, strcatlevel.Length) == strcatlevel).ToList();
        //        for (int h = 0; h < pagelistid.Count; h++)
        //        {
        //            int idpagecha = pagelistid[h].ID;
        //            var data = db.News.Where(u => u.icid == int.Parse( && u.Status == 1).ToList();
        //            for (int k = 0; k < data.Count; k++)
        //            {
        //                listpro.Add(data[k]);
        //            }
        //        }
        //        News = listpro;
        //    }
        //    return model.OrderByDescending(x => x.Create_Date).ToPagedList(page, pageSize);
        //}

        public List<News> ListAll()
        {
            return db.News.Where(x => x.Status == true).ToList();
        }
        public bool Update(News entity)
        {
            try
            {
                var obj = db.News.Find(entity.inid);
                obj.Title = entity.Title;
                obj.icid = entity.icid;
                obj.Title = entity.Title;
                obj.Brief = entity.Brief;
                obj.Contents = entity.Contents;
                obj.Keywords = entity.Keywords;
                obj.search = entity.search;
                obj.Images = obj.Images;
                obj.ImagesSmall = obj.ImagesSmall;
                obj.Equals = entity.Equals;
                obj.Chekdata = entity.Chekdata;
                obj.Create_Date = entity.Create_Date;
                obj.Modified_Date = entity.Modified_Date;
                obj.Views = entity.Views;
                obj.Tags = entity.Tags;
                obj.lang = entity.lang;
                obj.New = entity.New;
                obj.CheckBox1 = entity.CheckBox1;
                obj.CheckBox2 = entity.CheckBox2;
                obj.CheckBox3 = entity.CheckBox3;
                obj.CheckBox4 = entity.CheckBox4;
                obj.CheckBox5 = entity.CheckBox5;
                obj.CheckBox6 = entity.CheckBox6;
                obj.Status = entity.Status;
                obj.Titleseo = entity.Titleseo;
                obj.Meta = entity.Meta;
                obj.Keyword = entity.Keyword;
                obj.TangName = entity.TangName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //public IEnumerable<News> ListAllPaging(string searchString, int page, int pageSize)
        //{
        //    IQueryable<News> model = db.News;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.Title.Contains(searchString) || x.Title.Contains(searchString));
        //    }

        //    return model.OrderByDescending(x => x.Create_Date).ToPagedList(page, pageSize);
        //}

        public News GetById(string inid)
        {
            return db.News.SingleOrDefault(x => x.inid == int.Parse(inid));
        }
        public News ViewDetail(int? id)
        {
            return db.News.Find(id);
        }
        public List<News> Viewther(int id)
        {
            return db.News.Where(x => x.Status == true && x.inid != id).Take(5).ToList();
        }

        //public bool ChangeStatus(long id)
        //{
        //    var list = db.News.Find(id);
        //    list.Status = int.Parse(!list.Status);
        //    db.SaveChanges();
        //    return list.Status;
        //}
        public bool Delete(int id)
        {
            try
            {
                var News = db.News.Find(id);
                db.News.Remove(News);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //public ProductNews ViewDetail(long id)
        //{
        //    return db.ProductCategories.Find(id);
        //}

        public bool ChangeStatus(long id)
        {
            //var item = db.News.Find(id);
            //if (item.Status == 1)
            //{
            //    item.Status = 0;
            //}
            //else
            //{
            //    item.Status = 1;
            //}
            //db.SaveChanges();
            return true;
        }
    }
}
