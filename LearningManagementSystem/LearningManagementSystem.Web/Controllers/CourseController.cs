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
                return View(model);
            }

            await courseService.CreateCourse(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();  
            }

            var courseDetailsModel = await courseService.Details(id);

            return View(courseDetailsModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var model = await courseService.GetCourseById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CourseViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isEdited = await courseService.Edit(model);

            if (!isEdited)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            bool isDeleted = await courseService.Delete(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
