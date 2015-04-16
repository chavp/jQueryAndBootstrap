using eVisaWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eVisaWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Overview()
        {
            return View();
        }

        public ActionResult Management(string query = "", int start = 0, int limit = 5, int page = 1)
        {
            var viewList = MvcApplication.UserViewModelsList.Where(u =>
                u.Name.ToUpper().Contains(query.ToUpper())
                ).ToList();

            //foreach (var item in viewList)
            //{
            //    item.Address = item.Address.Replace("<br/>", Environment.NewLine);
            //}

            int totalItems = viewList.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)limit);

            int displayFrom = (page - 1) * limit + 1;
            int displayTo = limit * page;
            if (displayTo > totalItems) displayTo = totalItems;

            var result = new UserManagementViewModels
            {
                UserViewModelsList = viewList.OrderByDescending(x => x.ID).Skip(start).Take(limit).ToList(),
                TotalPages = totalPages,
                Page = page,
                Query = query,
                Start = start,
                Limit = limit,
                Total = totalItems,

                DisplayFrom = displayFrom,
                DisplayTo = displayTo,
            };

            return View(result);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult EditUser(int id)
        {
            var editUser = MvcApplication.UserViewModelsList.Where(u =>
                u.ID == id).FirstOrDefault();

            if (!string.IsNullOrEmpty(editUser.Address))
            {
                editUser.Address = editUser.Address.Replace("<br/>", Environment.NewLine);
            }
            return View(editUser);
        }

        [HttpPost]
        public ActionResult SaveUser(UserViewModels newUser)
        {
            string imgUrl = Url.Content("~/Scripts/assets/img/team/img1-sm.jpg");
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string imagePath = Server.MapPath("~/Content/UserImages");
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }
                string savedFileName = Path.Combine(Server.MapPath("~/Content/UserImages"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file

                imgUrl = @"../../Content/UserImages/" + hpf.FileName;
            }

            var id = MvcApplication.UserViewModelsList.Count() + 1;
            if (!string.IsNullOrEmpty(newUser.Address))
            {
                newUser.Address = newUser.Address.Replace(Environment.NewLine, "<br/>");
            }
            MvcApplication.UserViewModelsList.Add(new UserViewModels
            {
                ID = id,
                Name = newUser.Name,
                Address = newUser.Address,
                Email = newUser.Email,
                ImgUrl = imgUrl,
                JoinedDate = DateTime.Now.ToShortDateString(),
                Status = newUser.Status,
                Website = newUser.Website
            });

            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(UserViewModels updateUser)
        {
            var editUser = MvcApplication.UserViewModelsList.Where(u =>
                u.ID == updateUser.ID).FirstOrDefault();

            if (!string.IsNullOrEmpty(updateUser.Address))
            {
                updateUser.Address = updateUser.Address.Replace(Environment.NewLine, "<br/>");
            }
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                string imagePath = Server.MapPath("~/Content/UserImages");
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }
                string savedFileName = Path.Combine(Server.MapPath("~/Content/UserImages"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file

                editUser.ImgUrl = @"../../Content/UserImages/" + hpf.FileName;
            }

            editUser.Name = updateUser.Name;
            editUser.Address = updateUser.Address;
            editUser.Email = updateUser.Email;
            editUser.Status = updateUser.Status;
            editUser.Website = updateUser.Website;

            return View();
        }

        public JsonResult SearchUser(string query, int start, int limit)
        {
            var viewList = MvcApplication.UserViewModelsList.Where(u =>
                u.Name.ToUpper().Contains(query.ToUpper())
                ).ToList();

            var result = new
            {
                data = viewList.OrderByDescending(u => u.ID),
                total = viewList.Count,
                success = true,
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUser(int id)
        {
            var success = false;
            var msg = string.Empty;

            var delete = MvcApplication.UserViewModelsList.Where( u => u.ID == id ).FirstOrDefault();
            MvcApplication.UserViewModelsList.Remove(delete);

            success = true;
            msg = "Delete User Completed.";

            return Json(new { success = success, message = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}