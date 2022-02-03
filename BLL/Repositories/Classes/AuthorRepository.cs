using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Repositories.Classes
{
    public class AuthorRepository : IAuthorRepository
    {
        public Author Add(Author author)
        {
            foreach (Comics comics in author.Comicses)
            {
                if (!FakeDBContext.Comicses.Contains(comics))
                {
                    FakeDBContext.Comicses.Add(comics);
                }

                foreach (Tag tag in comics.Tags)
                {
                    if (!FakeDBContext.Tags.Contains(tag))
                    {
                        FakeDBContext.Tags.Add(tag);
                    }
                }
            }

            FakeDBContext.Authors.Add(author);
            return (Author)author.Clone();
        }

        public bool Delete(Author entity)
        {
            Author authorLink = FakeDBContext.Authors.FirstOrDefault(a => a.Id == entity.Id);
            if (authorLink == null)
                return false;

            return FakeDBContext.Authors.Remove(authorLink);
        }

        public bool Edit(Author author)
        {

            Author authorLink = FakeDBContext.Authors.FirstOrDefault(a => a.Id == author.Id);
            if (authorLink == null)
                return false;

            var index = FakeDBContext.Authors.IndexOf(authorLink);
            FakeDBContext.Authors[index] = author;

            return true;
        }


        public Author FindByName(string name)
        {
            Author searchResult = null;
            searchResult = FakeDBContext.Authors.FirstOrDefault(x => x.LastName == name);
            if (searchResult != null)
            {
                return (Author)searchResult.Clone();
            }
            else
            {
                searchResult = FakeDBContext.Authors.FirstOrDefault(x => x.FirstName == name);
                if (searchResult == null)
                {
                    return null;
                }
            }

            return (Author)searchResult.Clone();
        }

        public List<Author> FindMany(Expression<Func<Author, bool>> filter = null)
        {
            var authorList = new List<Author>();
            if (filter != null)
            {
                var authors = FakeDBContext.Authors.Where(filter.Compile());
                var a = FakeDBContext.Authors.Where(filter.Compile());

                try
                {
                    var ans = authors == null || authors.Any(); // Если тут ошибка, то IEnumerable пустой. Хоть метод Any и не должен выбрасывать экспепшн
                }
                catch (Exception ex) 
                {

                    return authorList;
                }
                
                
                if (authors == null && !authors.Any())
                {
                    return authorList;
                }
                foreach (var author in authors)
                {
                    authorList.Add((Author)author.Clone());
                }
            }

            return authorList;
        }

        public Author FindOne(Expression<Func<Author, bool>> filter = null)
        {
            if (filter != null)
            {
                var author = FakeDBContext.Authors.Where(filter.Compile()).FirstOrDefault();
                if (author != null)
                    return (Author)author.Clone();
            }

            return null;
        }

        public List<Author> GetAll()
        {
            var authorList = new List<Author>();
            foreach (var author in FakeDBContext.Authors)
            {
                authorList.Add((Author)author.Clone());
            }

            return authorList;
        }
    }
}
