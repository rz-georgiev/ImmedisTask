using System.Collections.Generic;

namespace ImmedisTask.ViewModels.Comment
{
    public class IndexViewModel
    {
        public int EmployeeId { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}