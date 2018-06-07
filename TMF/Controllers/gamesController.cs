using System.Data;
using System.Linq;
using System.Web.Mvc;
using TMF.Models.Context;

namespace TMF.Controllers
{
    public class gamesController : Controller
    {
        private TmfContext db = new TmfContext();
        
        public JsonResult getGames()
        {
            var liste = new SelectList(db.game, "id", "name");
            return new JsonResult { Data = liste, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult getRankCs()
        {
            var liste = new SelectList(db.compAtt.Where(a => a.id <= 104 && a.id >86), "id", "value");
            return new JsonResult { Data = liste, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult getRankLol()
        {
            var liste = new SelectList(db.compAtt.Where(a => a.id <= 27 && a.id > 0), "id", "value");
            return new JsonResult { Data = liste, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
