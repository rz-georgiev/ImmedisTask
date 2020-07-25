using ImmedisTask.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImmedisTask.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index(int employeeId)
        {
            var comments = _commentService.GetByEmployeeId(employeeId);
            


            return View();
        }
    }
}