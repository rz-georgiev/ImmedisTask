using ImmedisTask.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImmedisTask.Data.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> GetByIdAsync(int? id);

        Task<bool> SaveChangesAsync(Comment employee);

        IEnumerable<Comment> GetByEmployeeId(int employeeId);
    }
}