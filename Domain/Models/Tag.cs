using System;

namespace Domain.Models
{
    public class Tag: BaseModel, ICloneable
    {
        public string Name { get; set; }

        public object Clone()
        {
            return (Tag)MemberwiseClone();
        }
    }
}
