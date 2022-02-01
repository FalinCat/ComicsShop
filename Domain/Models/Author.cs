using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Author: BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public List<Comics> Comicses { get; set; }
    }
}
