using LearningManagementSystem.Core.Contracts;
using LearningManagementSystem.Core.Models.Announcement;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Web.Controllers
{
    public class AnnouncementController : BaseController
    {
        private readonly IAnnouncementService service;

        public AnnouncementController(IAnnouncementService _service)
        {
            service = _service;
        }

        public IActionResult All()
        {
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAnnouncementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.Create(model);

            return RedirectToAction(nameof(All));
;       }
    }
}
