using System.Web.Mvc;

namespace TMF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["yetki"] != null)
            {
                
            }
            return View();
        }

    }
}