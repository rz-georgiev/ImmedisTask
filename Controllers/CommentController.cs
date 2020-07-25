using ImmedisTask.Data.Interfaces;
using ImmedisTask.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            var models = comments.Select(x => new CommentViewModel
            {
                Id = x.Id,
                Author = x.Author,
                CommentContent = x.CommentContent.Length > 50
                ? $"{x.CommentContent.Substring(0, 50)}..."
                : x.CommentContent,
                CreatedDateTime = x.CreatedDateTime.ToString("dd.MM.yyyy")
            });

            var indexViewModel = new IndexViewModel { Comments = models };

            return View(indexViewModel);
        }
    }
}