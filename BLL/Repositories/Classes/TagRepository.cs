using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Repositories.Classes
{
    public class TagRepository : ITagRepository
    {
        public void Add(Tag entity)
        {
            FakeDBContext.Tags.Add(entity);
        }

        // ToDo
        public void Edit(Tag entity)
        {
            throw new NotImplementedException();
        }

        // ToDo
        public Tag FindByName(string name)
        {
            return FakeDBContext.Tags.FirstOrDefault(x=>x.Name == name);
        }

        // ToDo
        public List<Tag> FindMany(Expression<Func<Tag, bool>> filter = null)
        {
            if ( filter!= null )
            {
                return FakeDBContext.Tags.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Tags;
        }

        // ToDo
        public Tag FindOne(Expression<Func<Tag, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        // ToDo
        public List<Tag> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
