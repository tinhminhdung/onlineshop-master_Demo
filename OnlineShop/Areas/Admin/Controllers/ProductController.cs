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
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public JsonResult LoadImages(long id)
        {
            ProductDao dao = new ProductDao();
            var product = dao.ViewDetail(id);
            var images = product.MoreImages;
            XElement xImages = XElement.Parse(images);
            List<string> listImagesReturn = new List<string>();

            foreach (XElement element in xImages.Elements())
            {
                listImagesReturn.Add(element.Value);
            }
            return Json(new
            {
                data = listImagesReturn
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveImages(long id, string images)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var listImages = serializer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("Images");

            foreach (var item in listImages)
            {
                var subStringItem = item.Substring(21);
                xElement.Add(new XElement("Image", subStringItem));
            }
            ProductDao dao = new ProductDao();
            try
            {
                dao.UpdateImages(id, xElement.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = new ProductDao().ViewDetail(id);
            SetViewBag(item.CategoryID);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Product item)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(item);
                if (result)
                {
                    SetAlert("Sửa Product thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Product không thành công");
                }
            }
            //return RedirectToAction("Index", "Product");
            //return View("Index");
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product user)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm Product thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Product không thành công");
                }
            }
            // return View("Index");
            //  return RedirectToAction("Index", "Product");
            SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index", "Product");
        }

        //[HttpDelete]
        ////[HasCredential(RoleID = "DELETE_USER")]
        //public ActionResult Delete(int id)
        //{
        //    new ProductDao().Delete(id);
        //    return RedirectToAction("Index", "Product");
        //}

        [HttpPost]
        //[HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}