using ImmedisTask.Data;
using ImmedisTask.Data.Interfaces;
using ImmedisTask.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmedisTask.Services
{
    public class CommentService : ICommentService
    {
        private readonly ImmedisDbContext _dbContext;

        public CommentService(ImmedisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Comment> GetByEmployeeId(int employeeId)
        {
            var comments = _dbContext.Comments
                .Where(x => x.EmployeeId == employeeId)
                .OrderByDescending(x => x.CreatedDateTime);

            return comments;
        }

        public async Task<Comment> GetByIdAsync(int? id)
        {
            var comment = await _dbContext.Comments
                .SingleOrDefaultAsync(x => x.Id == id);

            return comment;
        }

        public async Task<bool> SaveChangesAsync(Comment comment)
        {
            try
            {
                if (comment.Id == 0)
                {
                    await _dbContext.AddAsync(comment);
                }
                else
                {
                    _dbContext.Update(comment);
                }
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}