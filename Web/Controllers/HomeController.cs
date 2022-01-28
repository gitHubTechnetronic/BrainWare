using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {            
            this.ViewBag.Title = "Home Page";
            return View();
        }

        
        //[Route("/Error/{statusCode}")]
        public ActionResult Error() // int statusCode
        {
            /*
            if (statusCode == StatusCodes.Status404NotFound)
            {
                return View("~/Views/Error/NotFound.cshtml");
            }
            else
            {
                return View("~/Views/Error/GeneralError.cshtml");
            }
            */

            //return View("~/Views/Error/Error.cshtml");
            return View();
        }

    }
}
