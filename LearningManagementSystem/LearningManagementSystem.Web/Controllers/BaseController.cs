using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
