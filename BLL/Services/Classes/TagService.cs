using BLL.Services.Interfaces;
using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL.Services.Classes
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;

        public TagService()
        {
            tagRepository = new TagRepository();
        }

        public Tag Add(Tag entity)
        {
            return tagRepository.Add(entity); 
        }

        public bool Delete(Tag entity)
        {
            return tagRepository.Delete(entity);
        }

        public bool Edit(Tag entity)
        {
            return tagRepository.Edit(entity);
        }

        public List<Tag> GetAll()
        {
            return tagRepository.GetAll();
        }

        public Tag GetByName(string name)
        {
            return tagRepository.FindByName(name);
        }

        public List<Tag> GetManyByFilter(Expression<Func<Tag, bool>> filter = null)
        {
            return tagRepository.FindMany(filter);
        }

        public Tag GetOneByFilter(Expression<Func<Tag, bool>> filter = null)
        {
            return tagRepository.FindOne(filter);
        }
    }
}
