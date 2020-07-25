using System.ComponentModel.DataAnnotations;

namespace ImmedisTask.Data.Models
{
    public class Comment : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string CommentContent { get; set; }
    }
}