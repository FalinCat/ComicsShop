using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Comics: BaseModel, ICloneable
    {
        public string Name { get; set; }

        public int Pages { get; set; }
        
        //public Author Author { get; set; }

        public int Order { get; set; }

        public bool IsSpecial { get; set; } = false;

        public PublishingHouse PublishingHouse { get; set; }

        public List<Tag> Tags { get; set; }

        public object Clone()
        {
            var comics = (Comics)MemberwiseClone();
            //comics.Author = (Author)Author.Clone();
            //foreach (var tag in this.Tags)
            //{
            //    comics.Tags.Add((Tag)tag.Clone());
            //}
            return comics;
        }
    }
}
