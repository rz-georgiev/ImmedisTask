using ImmedisTask.Data.Interfaces;
using ImmedisTask.Data.Models;
using ImmedisTask.InputModels;
using ImmedisTask.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Edit(int? employeeId)
        {
            var comment = await _commentService.GetByIdAsync(employeeId);
            if (comment == null)
            {
                return View();
            }
            else
            {
                var inputModel = new CommentInputModel
                {
                    Id = comment.Id,
                    EmployeeId = comment.EmployeeId,
                    Author = comment.Author,
                    CommentContent = comment.CommentContent
                };

                return View(inputModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var comment = await _commentService.GetByIdAsync(model.Id);
            if (comment == null)
            {
                comment = new Comment
                {
                    Author = model.Author,
                    CommentContent = model.CommentContent,
                    EmployeeId = model.EmployeeId,
                    CreatedDateTime = DateTime.Now,
                    IsActive = true
                };
            }
            else
            {
                comment.Author = model.Author;
                comment.CommentContent = model.CommentContent;
                comment.EmployeeId = model.EmployeeId;
                comment.LastUpdatedDateTime = DateTime.Now;
            }

            await _commentService.SaveChangesAsync(comment);
            return Redirect("/Comment/Index");
        }
    }
}