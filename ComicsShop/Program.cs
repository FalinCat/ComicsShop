using BLL.Services.Classes;
using BLL.Services.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace ComicsShop
{
    class Program
    {
        static readonly ITagService tagService;
        static readonly IComicsService comicsService;
        static readonly IAuthorService authorService;

        static Program()
        {
            tagService = new TagService();
            comicsService = new ComicsService();
            authorService = new AuthorService();

        }

        static void Main(string[] args)
        {
            PopulateDb();

            var testAuthor = authorService.GetOneByFilter(x => x.LastName == "Cake"); 
            Console.WriteLine($"Find author - {testAuthor.FirstName} {testAuthor.LastName}");

            testAuthor.FirstName = "Cake"; 
            testAuthor.LastName = "Islie";
            UpdateAuthor(testAuthor); 

            var thisAuthorWithNewName = SearchAuthorByLastName("Islie"); 
            Console.WriteLine($"Find author - {testAuthor.FirstName} {testAuthor.LastName}");

            DeleteAuthor(thisAuthorWithNewName); 


            var testTag = tagService.GetOneByFilter(x => x.Name == "Horror");
            testTag.Name = "Relax";
            UpdateTag(testTag);
            DeleteTag(testTag);


            var testComics = comicsService.GetOneByFilter(x => x.Pages == 28);
            testComics.Name = "Brand new comics";
            UpdateComics(testComics);
            DeleteComics(testComics);


            // Методы для поиска авторов
            var res1 = SearchAuthorsByAge(32);
            var res3 = SearchAuthorByLastName("Nolan");
            var res2 = SearchAuthorsWithLongNames(5);


            // Методы для поиска комиксов
            var res4 = SearchNewComicses(30);
            var res5 = SearchBigComicses(20);
            var res6 = SearchAllMarvelComicses();


            // Методы для поиска тегов
            var res7 = SearchTagsWithNewInName();
            var res8 = SearchTagsEndsWithChar('y');
            var res9 = GetAllTagsCapitalize();
        }



        static void PopulateDb()
        {
            var random = new Random();

            var tag1 = new Tag() { Name = "Horror" };
            var tag2 = new Tag() { Name = "Fantasy" };
            var tag3 = new Tag() { Name = "Amazing" };
            var tag4 = new Tag() { Name = "Magic" };
            var tag5 = new Tag() { Name = "Time travel" };

            var comics1 = new Comics()
            {
                Name = "Lack of fantasy",
                Order = random.Next(1, 25),
                Pages = random.Next(1, 100),
                IsSpecial = random.Next() > (Int32.MaxValue / 2),
                PublishingHouse = Domain.Enums.PublishingHouse.Other,
                Tags = new List<Tag>(new[] { tag1, tag2 })
            };

            var comics2 = new Comics()
            {
                Name = "Superhero isn't real",
                Order = random.Next(1, 25),
                Pages = random.Next(1, 100),
                IsSpecial = random.Next() > (Int32.MaxValue / 2),
                PublishingHouse = Domain.Enums.PublishingHouse.Other,
                Tags = new List<Tag>(new[] { tag2, tag3 })
            };

            var comics3 = new Comics()
            {
                Name = "Superhero is real",
                Order = random.Next(1, 25),
                Pages = random.Next(1, 100),
                IsSpecial = random.Next() > (Int32.MaxValue / 2),
                PublishingHouse = Domain.Enums.PublishingHouse.Other,
                Tags = new List<Tag>(new[] { tag3, tag4 })
            };

            var comics4 = new Comics()
            {
                Name = "Superman vs Batman",
                Order = random.Next(1, 25),
                Pages = random.Next(1, 100),
                IsSpecial = random.Next() > (Int32.MaxValue / 2),
                PublishingHouse = Domain.Enums.PublishingHouse.Other,
                Tags = new List<Tag>(new[] { tag4, tag5 })
            };

            var comics5 = new Comics()
            {
                Name = "Batman and a credit card with no money",
                Order = random.Next(1, 25),
                Pages = random.Next(1, 100),
                IsSpecial = random.Next() > (Int32.MaxValue / 2),
                PublishingHouse = Domain.Enums.PublishingHouse.Other,
                Tags = new List<Tag>(new[] { tag5, tag1 })
            };


            var author1 = new Author()
            {
                FirstName = "Alan",
                LastName = "Wake",
                BirthDate = Utilities.DateTimeRandom.RandomDay(),
                Comicses = new List<Comics>(new[] { comics1 })
            };

            var author2 = new Author()
            {
                FirstName = "Alan",
                LastName = "Cake",
                BirthDate = Utilities.DateTimeRandom.RandomDay(),
                Comicses = new List<Comics>(new[] { comics2 })
            };

            var author3 = new Author()
            {
                FirstName = "Jhon",
                LastName = "Weak",
                BirthDate = Utilities.DateTimeRandom.RandomDay(),
                Comicses = new List<Comics>(new[] { comics3 })
            };

            var author4 = new Author()
            {
                FirstName = "Jhon",
                LastName = "Notsowick",
                BirthDate = Utilities.DateTimeRandom.RandomDay(),
                Comicses = new List<Comics>(new[] { comics4 })
            };

            var author5 = new Author()
            {
                FirstName = "Kristofer",
                LastName = "Nolan",
                BirthDate = Utilities.DateTimeRandom.RandomDay(),
                Comicses = new List<Comics>(new[] { comics5, comics2 })
            };


            authorService.Add(author1);
            authorService.Add(author2);
            authorService.Add(author3);
            authorService.Add(author4);
            authorService.Add(author5);

            //var tag6 = new Tag() { Name = "Horror" };
            //tagService.Add(tag6);

            //var comics6 = new Comics()
            //{
            //    Name = "Superman vs Minions",
            //    Order = random.Next(1, 25),
            //    Pages = random.Next(1, 100),
            //    IsSpecial = random.Next() > (Int32.MaxValue / 2),
            //    PublishingHouse = Domain.Enums.PublishingHouse.Other,
            //    Tags = new List<Tag>(new[] { tag4, tag5 })
            //};


        }

        #region DELETE Actions
        static bool DeleteAuthor(Author author)
        {
            return authorService.Delete(author);
        }
        static bool DeleteComics(Comics comics)
        {
            return comicsService.Delete(comics);
        }
        static bool DeleteTag(Tag tag)
        {
            return tagService.Delete(tag);
        }
        #endregion

        #region UPDATE Actions
        static bool UpdateAuthor(Author author)
        {
            return authorService.Edit(author);
        }

        static bool UpdateComics(Comics comics)
        {
            return comicsService.Edit(comics);
        }

        static bool UpdateTag(Tag tag)
        {
            return tagService.Edit(tag);
        }
        #endregion

        #region SEARCH Actions
        static Author SearchAuthorByLastName(string lastName)
        {
            return authorService.GetOneByFilter(a => a.LastName == lastName);
        }

        static List<Author> SearchAuthorsByAge(int atLeastAge)
        {
            var fromDate = DateTime.Now.AddYears(-atLeastAge);
            return authorService.GetManyByFilter(a => a.BirthDate < fromDate);
        }

        static List<Author> SearchAuthorsWithLongNames(int length)
        {
            return authorService.GetManyByFilter(a => a.LastName.Length >= length);
        }

        // Exception в случае если у автора нет комиксов
        //static List<Author> SearchProductiveAuthors(int comicsCount)
        //{
        //    return authorService.GetManyByFilter(a => a.Comicses.Count > comicsCount);
        //}


        static List<Comics> SearchNewComicses(int ageInYears)
        {
            var fromDate = DateTime.Now.AddYears(-ageInYears);
            return comicsService.GetManyByFilter(x => x.CreationDate > fromDate);
        }

        static List<Comics> SearchBigComicses(int pageCount)
        {
            return comicsService.GetManyByFilter(x => x.Pages > pageCount);
        }

        static List<Comics> SearchAllMarvelComicses()
        {
            return comicsService.GetManyByFilter(x => x.PublishingHouse > Domain.Enums.PublishingHouse.Marvel);
        }


        static List<Tag> SearchTagsWithNewInName()
        {
            return tagService.GetManyByFilter(x => x.Name.Contains("New"));
        }

        static List<Tag> SearchTagsEndsWithChar(char ch)
        {
            return tagService.GetManyByFilter(x => x.Name.EndsWith(ch));
        }
        static List<Tag> GetAllTagsCapitalize()
        {
            var tags = tagService.GetAll();
            foreach (var tag in tags)
            {
                tag.Name = tag.Name.ToUpper();
            }
            //tags.ForEach(x => x.Name.ToUpper());
            return tags;
        }
        #endregion

        static Tag GetSpecialTags(string name)
        {
            return tagService.GetByName(name);
            //return tagService.GetTagByName(name);
        }
    }
}
