using Domain.Enums;
using Domain.Models;
using System.Collections.Generic;
using Utilities;

namespace Domain
{
    public static class FakeDBContext
    {
        static FakeDBContext()
        {
            Comicses.ForEach(x => x.CreationDate = DateTimeRandom.RandomDay());
            Tags.ForEach(x => x.CreationDate = DateTimeRandom.RandomDay());
            Authors.ForEach(x => { x.CreationDate = DateTimeRandom.RandomDay(); x.BirthDate = DateTimeRandom.RandomDay(); });
        }

        public static List<Comics> Comicses = new List<Comics>
        {
            new Comics{ Name = "Spider-man", Order = 1, Pages = 28, IsSpecial = true, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Spider-man", Order = 2, Pages = 26, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Spider-man", Order = 3, Pages = 29, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Spider-man", Order = 4, Pages = 22, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Spider-man", Order = 5, Pages = 21, IsSpecial = true, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Daredevil", Order = 1, Pages = 12, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Daredevil", Order = 2, Pages = 20, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Daredevil", Order = 3, Pages = 45, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Daredevil", Order = 4, Pages = 34, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Daredevil", Order = 0, Pages = 44, IsSpecial = true, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Batman", Order = 12, Pages = 36, PublishingHouse = PublishingHouse.DC},
            new Comics{ Name = "Batman", Order = 13, Pages = 23, PublishingHouse = PublishingHouse.DC},
            new Comics{ Name = "Batman", Order = 1, Pages = 78, IsSpecial = true, PublishingHouse = PublishingHouse.DC},
            new Comics{ Name = "Batman", Order = 3, Pages = 12, PublishingHouse = PublishingHouse.DC},
            new Comics{ Name = "Batman", Order = 4, Pages = 12, PublishingHouse = PublishingHouse.DC},
            new Comics{ Name = "Sentry", Order = 5, Pages = 12, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Sentry", Order = 7, Pages = 67, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Sentry", Order = 2, Pages = 25, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Sentry", Order = 4, Pages = 13, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Sentry", Order = 22, Pages = 89, PublishingHouse = PublishingHouse.Marvel},
            new Comics{ Name = "Justice League", Order = 1, Pages = 93, IsSpecial = true, PublishingHouse = PublishingHouse.DC},
        };

        public static List<Author> Authors = new List<Author>
        {
            new Author { FirstName = "Frank", LastName = "Miller"},
            new Author { FirstName = "Mark", LastName = "Waid" },
            new Author { FirstName = "Jack", LastName = "Kirby"}
        };

        public static List<Tag> Tags = new List<Tag>
        {
            new Tag{ Name = "Spider"},
            new Tag{ Name = "Marvel"},
            new Tag{ Name = "War"},
            new Tag{ Name = "God"},
            new Tag{ Name = "Fantastic"},
            new Tag{ Name = "Amazing"},
            new Tag{ Name = "Joker"},
            new Tag{ Name = "Man"},
            new Tag{ Name = "NewYork"},
            new Tag{ Name = "DC"},
            new Tag{ Name = "Moon"},
            new Tag{ Name = "Captain"},
            new Tag{ Name = "MJ"},
            new Tag{ Name = "ClarkKent"},
            new Tag{ Name = "Superman"},
            new Tag{ Name = "Robin"},
            new Tag{ Name = "Flash"}
        };
    }
}
