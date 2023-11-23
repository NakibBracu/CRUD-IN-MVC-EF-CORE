using CRUD_EF_CORE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;
using System.Data;
using Autofac;

namespace CRUD_EF_CORE.Controllers
{
    public class CRUDController : Controller
    {
        ILifetimeScope _scope;
        ILogger<CRUDController> _logger;
        
        public CRUDController(ILifetimeScope scope, ILogger<CRUDController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateCourse() //http  get form will be loaded by this
        {
            var model = _scope.Resolve<CourseCreateModel>();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateCourse(CourseCreateModel model) //form will be submitted by this
        {
            model.ResolveDependency(_scope);
            //modelState Valid -> then work, otherwise it will be in the same page
            try
                {
                    model.CreateCourse();             

                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);
                    return View(model);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Server error");                 
                    return View(model);
                }
            


            //return RedirectToAction("Index");
            return RedirectToAction();
        }


    }
}
