using Microsoft.AspNetCore.Mvc;

namespace CRUD_EF_CORE.Controllers
{
    public class CRUDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
    }
}
