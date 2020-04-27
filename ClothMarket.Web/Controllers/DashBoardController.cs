using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothMarket.Web.Controllers
{
    [Authorize(Roles = "Administrator, Moderator")]
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}