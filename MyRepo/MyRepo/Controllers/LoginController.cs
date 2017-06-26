using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyRepo.Models;

namespace MyRepo.Controllers
{
    public class LoginController : Controller
    {
        private myrepoDBEntities db = new myrepoDBEntities();

        // GET: Users/Create
        public ActionResult Index()
        {
            return View();
        }

        // POST: Users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "userId,userName,email,password,visitCount")] Users users)
        {
            var aux = db.Users.Find(users.userId);

            if (aux != null)
            {
                if (aux.password == users.password)
                {
                    //db.Users.Add(users);
                    //db.SaveChanges();
                    return RedirectToAction("Create","Documents");
                }

            }

            return HttpNotFound();
            //return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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