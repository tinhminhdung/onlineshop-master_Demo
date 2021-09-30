using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        /// <summary>
        /// Get list product by category
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public List<ProductViewModel> ListByCategoryId(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.ID
                         where a.CategoryID == categoryID
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.Name == keyword).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        /// List feature product
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }

        public void UpdateImages(long productId, string images)
        {
            var product = db.Products.Find(productId);
            product.MoreImages = images;
            db.SaveChanges();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var item = db.Products.Find(id);
            item.Status = !item.Status;
            db.SaveChanges();
            return item.Status;
        }
        public bool Delete(int id)
        {
            var item = db.Products.Find(id);
            db.Products.Remove(item);
            db.SaveChanges();
            return true;
        }
        public long Insert(Product entity)
        {
            Product item = new Product();
            item.Name = entity.Name;
            item.Code = entity.Code;
            item.MetaTitle = entity.MetaTitle;
            item.Description = entity.Description;
            item.Image = entity.Image;
            item.MoreImages = entity.MoreImages;
            item.Price = entity.Price;
            item.PromotionPrice = entity.PromotionPrice;
            item.IncludedVAT = entity.IncludedVAT;
            item.Quantity = entity.Quantity;
            item.CategoryID = entity.CategoryID;
            item.Detail = entity.Detail;
            item.Warranty = entity.Warranty;
            item.CreatedDate = DateTime.Now;// entity.CreatedDate;
            item.CreatedBy = entity.CreatedBy;
            item.ModifiedDate = DateTime.Now;// entity.ModifiedDate;
            item.ModifiedBy = entity.ModifiedBy;
            item.MetaKeywords = entity.MetaKeywords;
            item.MetaDescriptions = entity.MetaDescriptions;
            item.Status = entity.Status;
            item.TopHot = entity.TopHot;
            item.ViewCount = entity.ViewCount;
            db.Products.Add(item);
            db.SaveChanges();
            return item.ID;
        }
        public bool Update(Product entity)
        {
            try
            {
                var item = db.Products.Find(entity.ID);
                item.Name = entity.Name;
                item.Code = entity.Code;
                item.MetaTitle = entity.MetaTitle;
                item.Description = entity.Description;
                item.Image = entity.MoreImages;
                item.MoreImages = entity.MoreImages;
                item.Price = entity.Price;
                item.PromotionPrice = entity.PromotionPrice;
                item.IncludedVAT = entity.IncludedVAT;
                item.Quantity = entity.Quantity;
                item.CategoryID = entity.CategoryID;
                item.Detail = entity.Detail;
                item.Warranty = entity.Warranty;
                item.CreatedDate = DateTime.Now;// entity.CreatedDate;
                item.CreatedBy = entity.CreatedBy;
                item.ModifiedDate = DateTime.Now;// entity.ModifiedDate;
                item.ModifiedBy = entity.ModifiedBy;
                item.MetaKeywords = entity.MetaKeywords;
                item.MetaDescriptions = entity.MetaDescriptions;
                item.Status = entity.Status;
                item.TopHot = entity.TopHot;
                item.ViewCount = entity.ViewCount;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
    }
}
