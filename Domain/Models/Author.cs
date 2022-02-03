using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Author: BaseModel, ICloneable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public List<Comics> Comicses { get; set; }

        public object Clone()
        {
            var author = (Author)MemberwiseClone();
            //foreach (var comics in Comicses)
            //{
            //    author.Comicses.Add((Comics)comics.Clone());
            //}

            return author;
        }
    }
}
