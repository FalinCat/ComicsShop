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
        public Tag Add(Tag tag)
        {
            FakeDBContext.Tags.Add(tag);
            return (Tag)tag.Clone();
        }

        public bool Delete(Tag entity)
        {
            var tagLink = FakeDBContext.Tags.FirstOrDefault(t => t.Id == entity.Id);
            if (tagLink == null)
            {
                return false;
            }
            return FakeDBContext.Tags.Remove(tagLink);
        }

        public bool Edit(Tag tag)
        {
            var tagLink = FakeDBContext.Tags.FirstOrDefault(t => t.Id == tag.Id);
            if (tagLink != null)
            {
                var index = FakeDBContext.Tags.IndexOf(tagLink);
                FakeDBContext.Tags[index] = tag;

                return true;
            }

            return false;
        }


        public Tag FindByName(string name)
        {
            var tagLink = FakeDBContext.Tags.FirstOrDefault(x => x.Name == name);
            if (tagLink == null)
            {
                return null;
            }
            return (Tag)tagLink.Clone();
        }


        public List<Tag> FindMany(Expression<Func<Tag, bool>> filter = null)
        {
            var tagList = new List<Tag>();
            if (filter != null)
            {
                foreach (var tag in FakeDBContext.Tags.Where(filter.Compile()))
                {
                    tagList.Add((Tag)tag.Clone());
                }
            }

            return tagList;
        }

        
        public Tag FindOne(Expression<Func<Tag, bool>> filter = null)
        {
            if (filter != null)
            {
                var tag = FakeDBContext.Tags.Where(filter.Compile()).FirstOrDefault();
                if (tag != null)
                    return (Tag)tag.Clone();
            }

            return null;
        }

        
        public List<Tag> GetAll()
        {
            var tagList = new List<Tag>();
            foreach (var tag in FakeDBContext.Tags)
            {
                tagList.Add((Tag)tag.Clone());
            }

            return tagList;
        }
    }
}
