using System;

namespace Domain.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreationDate { get; set; }
    }
}
