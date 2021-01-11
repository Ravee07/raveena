using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_DEMO_MVC.Models;

namespace CRUD_DEMO_MVC.Controllers
{
    public class UsersController : Controller
    {
        private MyDBDemoEntities db = new MyDBDemoEntities();

        // GET: TbUsers
        public async Task<ActionResult> Index()
        {
            return View(await db.TbUsers.ToListAsync());
        }

        // GET: TbUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbUser tbUser = await db.TbUsers.FindAsync(id);
            if (tbUser == null)
            {
                return HttpNotFound();
            }
            return View(tbUser);
        }

        // GET: TbUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TbUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,email,address")] TbUser tbUser)
        {
            if (ModelState.IsValid)
            {
                db.TbUsers.Add(tbUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbUser);
        }

        // GET: TbUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbUser tbUser = await db.TbUsers.FindAsync(id);
            if (tbUser == null)
            {
                return HttpNotFound();
            }
            return View(tbUser);
        }

        // POST: TbUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,email,address")] TbUser tbUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbUser);
        }

        // GET: TbUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbUser tbUser = await db.TbUsers.FindAsync(id);
            if (tbUser == null)
            {
                return HttpNotFound();
            }
            return View(tbUser);
        }

        // POST: TbUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TbUser tbUser = await db.TbUsers.FindAsync(id);
            db.TbUsers.Remove(tbUser);
            await db.SaveChangesAsync();
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
