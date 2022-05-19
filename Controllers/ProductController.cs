using Entity_crud_2.Models;
using Entity_crud_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity_crud_2.Controllers
{
    public class ProductController : Controller
    {
        ProductDbContext DbContext = new ProductDbContext();
        
        public ActionResult Index()
        {
            var products = (from p in DbContext.Products
                            join
                            c in DbContext.Categories
                            on p.Category.Id equals c.Id
                            select new ProductListViewModel()
                            {
                                Id=p.Id,
                                Title=p.Title,
                                Price=p.Price,
                                Quantity=p.Quantity,
                                Descr=p.Descr,
                                Category=c.Name
                            });
          

            return View(products);
        }
        public ActionResult Create()
        {
            var cats = DbContext.Categories.ToList();
           ViewBag.cats = cats;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel product)
        {
            var cat = DbContext.Categories.SingleOrDefault(e=>e.Id==product.Category);
            var objProduct = new Product()
            {
                Title=product.Title,
                Quantity=product.Quantity,
                Descr=product.Descr,
                Price=product.Price,
                Category=cat
            };
            DbContext.Products.Add(objProduct);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {

            var pro = DbContext.Products.SingleOrDefault(e => e.Id == id);
            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            DbContext.Entry(p).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {

            var product = DbContext.Products.SingleOrDefault(e1 => e1.Id == id);
            DbContext.Products.Remove(product);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
