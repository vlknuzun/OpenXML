using Akademetre.Models.Session;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace Akademetre.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string name, string surname, string adress, string email)
        {
            User user = new User();
            user.Name = name;
            user.Surname = surname;
            user.Adress = adress;
            user.Email = email;

            List<User> list = Session["users"] == null ? new List<User>() : Session["users"] as List<User>;
            list.Add(user);
            Session.Add("users", list);



            return RedirectToAction("Index");
        }
        [HttpPost]
        public FileResult Donwload()
        {
            DataTable dt = new DataTable("Users");
            dt.Columns.AddRange(new DataColumn[4]
            {
                new DataColumn("Name"),
                new DataColumn("Surname"),
                new DataColumn("Adress"),
                new DataColumn("Email")
            });

            
            foreach (var item in (List<User>)Session["users"])
            {
                dt.Rows.Add(item.Name, item.Surname, item.Adress, item.Email);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream=new MemoryStream())
                {
                    wb.SaveAs(stream);
                     return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Users.xlsx");
                }
            }

           
        }




    }
}