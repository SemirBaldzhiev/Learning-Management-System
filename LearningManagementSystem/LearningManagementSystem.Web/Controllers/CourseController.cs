using LearningManagementSystem.Core.Contracts;
using LearningManagementSystem.Core.Models.Course;
using LearningManagementSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Web.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService _courseService)
        {
            courseService = _courseService;
        }

        public async Task<IActionResult> Index()
        {
            var allCourses = await courseService.All();

            return View(allCourses);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCourseViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Add", "Course");
            }

            await courseService.CreateCourse(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
