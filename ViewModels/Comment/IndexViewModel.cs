using System.Collections.Generic;

namespace ImmedisTask.ViewModels.Comment
{
    public class IndexViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}