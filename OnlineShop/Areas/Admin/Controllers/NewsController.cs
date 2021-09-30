using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;


namespace OnlineShop.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        //public ActionResult Index()
        //{
        //    var dao = new NewsDao();
        //    var model = dao.ListAll();
        //    return View(model);
        //}

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new NewsDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            var News = new NewsDao().ViewDetail(id);
            SetViewBag(News.icid);
            return View(News);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(News data, FormCollection collect)
        {
            if (ModelState.IsValid)
            {

                var dao = new NewsDao();
                var obj = new NewsDao().ViewDetail(data.inid);
                obj.icid = int.Parse(data.icid.ToString());
                obj.Title = data.Title;
                obj.Brief = data.Brief;
                obj.Contents = data.Contents;// collect["txtContent"]; 
                obj.Keywords = "";
                obj.search = "";
                obj.Images = "";
                obj.ImagesSmall = data.Images;
                obj.Equals = true;
                obj.Chekdata = true;
                obj.Create_Date = DateTime.Now;
                obj.Modified_Date = DateTime.Now;
                obj.Views = 0;
                obj.Tags = "";
                obj.lang = "VIE";
                obj.New = data.New;
                obj.CheckBox1 = data.CheckBox1;
                obj.CheckBox2 = data.CheckBox2;
                obj.CheckBox3 = data.CheckBox3;
                obj.CheckBox4 = data.CheckBox4;
                obj.CheckBox5 = data.CheckBox5;
                obj.CheckBox6 = data.CheckBox6;
                obj.Status = data.Status;
                obj.Titleseo = data.Titleseo;
                obj.Meta = data.Meta;
                obj.Keyword = data.Keyword;
                obj.TangName = data.Title;
                var result = dao.Update(obj);
                if (result)
                {
                    ViewBag.ThongBao = "Thêm thành công";
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ViewBag.ThongBao = "Lỗi thêm mới";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(News data, FormCollection collect)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                News obj = new News();
                obj.icid = int.Parse(data.icid.ToString());
                obj.Title = data.Title;
                obj.Brief = data.Brief;
                obj.Contents = data.Contents;// collect["txtContent"]; 
                obj.Keywords = "";
                obj.search = "";
                obj.Images = "";
                obj.ImagesSmall = data.Images;
                obj.Equals = true;
                obj.Chekdata = true;
                obj.Create_Date = DateTime.Now;
                obj.Modified_Date = DateTime.Now;
                obj.Views = 0;
                obj.Tags = "";
                obj.lang = "VIE";
                obj.New = data.New;
                obj.CheckBox1 = data.CheckBox1;
                obj.CheckBox2 = data.CheckBox2;
                obj.CheckBox3 = data.CheckBox3;
                obj.CheckBox4 = data.CheckBox4;
                obj.CheckBox5 = data.CheckBox5;
                obj.CheckBox6 = data.CheckBox6;
                obj.Status = data.Status;
                obj.Titleseo = data.Titleseo;
                obj.Meta = data.Meta;
                obj.Keyword = data.Keyword;
                obj.TangName = data.Title;
                long id = dao.Insert(obj);
                if (id > 0)
                {
                    ViewBag.ThongBao = "Thêm thành công";
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ViewBag.ThongBao = "Lỗi thêm mới";
                }
            }
            SetViewBag();
            return View();
        }
        #region[Delete]
        public ActionResult Delete(int id)
        {
            new NewsDao().Delete(id);
            return RedirectToAction("Index", "News");
        }
        #endregion

        #region[Status]
        public ActionResult Status(int id)
        {
            new NewsDao().ChangeStatus(id);
            return RedirectToAction("Index", "News");
        }
        #endregion

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new NewsDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        public void SetViewBag(long? selectedId = null)
        {
            //var dao = new MenuDao();
            ViewBag.icid = "";// new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
    }
}