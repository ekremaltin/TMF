using System.Web.Mvc;
using TMF.Models.Context;

namespace TMF.Controllers
{
    public class FindController : Controller
    {
        private TmfContext db = new TmfContext();
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        // POST: Home
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection fc)
        {
            int a = int.Parse(fc["minData"]); //slider min değer
            int b = int.Parse(fc["maxData"]); //max değer
            return View();
        }

        public ActionResult Search()
        {

            return View();
        }

        //public JsonResult getBolge()
        //{
        //    var liste = new SelectList(db., "sirketID", "sirketAdi");
        //    return new JsonResult { Data = liste, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}
    }
}