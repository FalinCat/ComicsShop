using BLL.Services.Interfaces;
using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL.Services.Classes
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService()
        {
            authorRepository = new AuthorRepository();
        }

        public Author Add(Author entity)
        {
            return authorRepository.Add(entity);
        }

        public bool Delete(Author entity)
        {
            return authorRepository.Delete(entity);
        }

        public bool Edit(Author entity)
        {
            return authorRepository.Edit(entity);
        }

        public List<Author> GetAll()
        {
            return authorRepository.GetAll();
        }

        public Author GetByName(string name)
        {
            return authorRepository.FindByName(name);
        }

        public List<Author> GetManyByFilter(Expression<Func<Author, bool>> filter = null)
        {
            return authorRepository.FindMany(filter);
        }

        public Author GetOneByFilter(Expression<Func<Author, bool>> filter = null)
        {
            return authorRepository.FindOne(filter);
        }
    }
}
