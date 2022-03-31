using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Web.Controllers
{
    public class AnnouncementController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
