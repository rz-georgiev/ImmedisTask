using System;

namespace ImmedisTask.Data.Models
{
    public class BaseModel
    {
        public DateTime CreatedDateTime { get; set; }

        public DateTime? LastUpdatedDateTime { get; set; }

        public bool IsActive { get; set; }
    }
}