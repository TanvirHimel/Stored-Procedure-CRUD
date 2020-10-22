using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPCRUD.Models;
using System.Data.SqlClient;

namespace SPCRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var db = new PlayerCRUDEntities();
            var data = db.AllPlayerList();
            return View(data.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var db = new PlayerCRUDEntities();
            SqlParameter param1 = new SqlParameter("@PlayerId", id);
            var data = db.Database.SqlQuery<Player>("exec GetPlayerById @PlayerId", param1).SingleOrDefault();
            return View(data);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Player collection)
        {
            try
            {
                // TODO: Add insert logic here
                SqlParameter param1 = new SqlParameter("@FirstName", collection.FirstName);
                SqlParameter param2 = new SqlParameter("@LastName", collection.LastName);
                SqlParameter param3 = new SqlParameter("Email", collection.Email);
                var db = new PlayerCRUDEntities();
                var data = db.Database.ExecuteSqlCommand("InsertPlayer @FirstName, @LastName, @Email", param1, param2, param3);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new PlayerCRUDEntities();
            SqlParameter param1 = new SqlParameter("@PlayerId", id);
            var data = db.Database.SqlQuery<Player>("exec GetPlayerById @PlayerId", param1).SingleOrDefault();
            return View(data);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Player obj)
        {
            try
            {
                // TODO: Add update logic here
                var db = new PlayerCRUDEntities();
                SqlParameter param1 = new SqlParameter("@FirstName", obj.FirstName);
                SqlParameter param2 = new SqlParameter("@LastName", obj.LastName);
                SqlParameter param3 = new SqlParameter("@Email", obj.Email);
                SqlParameter param4 = new SqlParameter("@PlayerId", id);
                var data = db.Database.ExecuteSqlCommand("UpdatePlayer @PlayerId @FirstName, @LastName, @Email",param4, param1, param2, param3);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new PlayerCRUDEntities();
            SqlParameter param1 = new SqlParameter("@PlayerId", id);
            var data = db.Database.SqlQuery<Player>("exec GetPlayerById @PlayerId", param1).SingleOrDefault();
            return View(data);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var db = new PlayerCRUDEntities();
                SqlParameter param1 = new SqlParameter("@PlayerId", id);
                db.Database.ExecuteSqlCommand("DeletePlayer @PlayerId", param1);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
