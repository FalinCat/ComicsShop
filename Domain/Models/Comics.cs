using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Comics: BaseModel
    {
        public string Name { get; set; }

        public int Pages { get; set; }
        
        public Author Author { get; set; }

        public int Order { get; set; }

        public bool IsSpecial { get; set; } = false;

        public PublishingHouse PublishingHouse { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
