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
    public class LoginController : BaseController
    {
        private myrepoDBEntities db = new myrepoDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "userId,password")] Users users)
        {
            var aux = db.Users.Find(users.userId);

            if (aux != null)
            {
                if (aux.password == users.password)
                {
                    ViewData["user"] = aux;
                    return RedirectToAction("Create","Documents");
                }

            }
            ModelState.AddModelError("", "ID de usuario o contraseña incorrectos.");
            return View();
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