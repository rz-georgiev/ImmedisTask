using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImmedisTask.InputModels
{
    public class CommentInputModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required]
        [DisplayName("Content")]
        public string CommentContent { get; set; }

    }
}