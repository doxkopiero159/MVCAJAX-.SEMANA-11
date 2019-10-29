using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOMAIN;
using SERVICE;
using MVCAJAX.Models;

namespace MVCAJAX.Controllers
{
    public class ControllerStudent : Controller
    {
        private StudentService service = new StudentService();
        // GET: ControllerStudent
        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             ID = c.studentID,
                             Address = c.studentAddres,
                             Name = c.studentName
                         }).ToList();
            return View(model);
        }
        public ActionResult index() {
            return View();
        }
        public JsonResult getStudent(string id) {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult createStudent(Student std) {
            service.Insertar(std);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

    } 
}