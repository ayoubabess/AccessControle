using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDOperationCodeF.DAL;
using CRUDOperationCodeF.Models;
using System.Drawing;
using PagedList;


namespace CRUDOperationCodeF.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        private EmployeeContext db = new EmployeeContext();
        private const int DefaultPageSize = 10;
        private IList<Article> allArticle = new List<Article>();
        private List<Category> allcategories;

        // GET: Articles
        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            Image img = null;
            allcategories = db.Categories.ToList();
            allArticle = db.Articles.ToList();
            foreach (var a in allArticle)
                img = a.byteArrayToImage(a.image);
            int currentPageIndex = page.HasValue ? page.Value : 1;
            ViewBag.allcategories = allcategories;
            return View(allArticle.ToPagedList(currentPageIndex, DefaultPageSize));
        }
        [AllowAnonymous]
        public ActionResult ViewByCategory(string categoryName, int? page)
        {

            Image img = null;
            allArticle = db.Articles.ToList();
            allcategories = db.Categories.ToList();
            foreach (var a in allArticle)
                img = a.byteArrayToImage(a.image);
            int currentPageIndex = page.HasValue ? page.Value : 1;

            var category = db.Categories.First(c => c.name.Equals(categoryName));
            var productsByCategory = allArticle.Where(p => p.CategoryID.Equals(category.CategoryID)).ToPagedList(currentPageIndex,
                                                                                                                DefaultPageSize);
            /*ViewBag.CategoryName = new SelectList(this.allCategories, categoryName);*/
            ViewBag.allcategories = allcategories;
            return View( productsByCategory);
        }
        // GET: Articles

        /*  public ActionResult Index()
          {
              Image img = null; 
              var art = db.Articles.ToList();
              foreach (var a in art)
                  img = a.byteArrayToImage(a.image);

              return View(db.Articles.ToList());
          }*/

        // GET: Articles/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Article article, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    article.image = new byte[file.ContentLength];
                    file.InputStream.Read(article.image, 0, file.ContentLength);

                    db.Articles.Add(article);
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Article Article, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Article.image = null;
                //if (file.ContentLength > 0)
                if (file!=null)
                {
                    Article.image = new byte[file.ContentLength];
                    file.InputStream.Read(Article.image, 0, file.ContentLength);
                }
                
              
                db.Entry(Article).State = EntityState.Modified;
               if(file==null) db.Entry(Article).Property("image").IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
