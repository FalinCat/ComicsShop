using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Repositories.Classes
{
    public class ComicsRepository : IComicsRepository
    {
        public Comics Add(Comics comics)
        {
            foreach (Tag tag in comics.Tags)
            {
                if (!FakeDBContext.Tags.Contains(tag))
                {
                    FakeDBContext.Tags.Add(tag);
                }
            }

            FakeDBContext.Comicses.Add(comics);
            return (Comics)comics.Clone();
        }

        public bool Delete(Comics entity)
        {
            var comicsLink = FakeDBContext.Comicses.FirstOrDefault(c => c.Id == entity.Id);
            if (comicsLink == null)
            {
                return false;
            }
            return FakeDBContext.Comicses.Remove(comicsLink);
        }

        public bool Edit(Comics comics)
        {
            var comicsLink = FakeDBContext.Comicses.FirstOrDefault(c => c.Id == comics.Id);
            if (comicsLink == null)
                return false;
            var index = FakeDBContext.Comicses.IndexOf(comicsLink);
            FakeDBContext.Comicses[index] = comics;

            return true;
        }

        public Comics FindByName(string name)
        {
            var searchResult = FakeDBContext.Comicses.FirstOrDefault(x => x.Name == name);
            if (searchResult == null) 
                return null;
            return (Comics)searchResult.Clone();
        }

        public List<Comics> FindMany(Expression<Func<Comics, bool>> filter = null)
        {
            var comicsList = new List<Comics>();
            if (filter != null)
            {
                foreach (var comics in FakeDBContext.Comicses.Where(filter.Compile()))
                {
                    comicsList.Add((Comics)comics.Clone());
                }
            }

            return comicsList;
        }

        public Comics FindOne(Expression<Func<Comics, bool>> filter = null)
        {
            if (filter != null)
            {
                var comics = FakeDBContext.Comicses.Where(filter.Compile()).FirstOrDefault();
                if (comics != null)
                    return (Comics)comics.Clone();
            }

            return null;
        }

        public List<Comics> GetAll()
        {
            var comicsList = new List<Comics>();
            foreach (var comics in FakeDBContext.Comicses)
            {
                comicsList.Add((Comics)comics.Clone());
            }

            return comicsList;
        }
    }
}
