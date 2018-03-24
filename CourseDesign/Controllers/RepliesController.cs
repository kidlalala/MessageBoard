using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseDesign.Models;

namespace CourseDesign.Controllers
{
    public class RepliesController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: Replies
        public ActionResult Index()
        {
            Message msg = (Message)Session["msg"];
            ViewBag.MSGTopic = msg.Topic;
            ViewBag.MSGContent = msg.Content;
            return View(db.Replies.ToList());
        }

        // GET: Replies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // GET: Replies/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Create(int id)
        {
            Message msg = db.Messages.Find(id);
            Session["msg"] = msg;
            return View();
        }

        // POST: Replies/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReplyID,ReplyContent,ReplyTime,ReplyUserName,MSG_ID")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                User user = (User)Session["user"];
                Message msg = (Message)Session["msg"];
                reply.ReplyTime = DateTime.Now;
                reply.ReplyUserName = user.Name;
                reply.MSG_ID = msg.MSG_ID;
                db.Replies.Add(reply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reply);
        }

        // GET: Replies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // POST: Replies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReplyID,ReplyContent,ReplyTime,ReplyUserName,MSG_ID")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reply);
        }

        // GET: Replies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reply reply = db.Replies.Find(id);
            db.Replies.Remove(reply);
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
