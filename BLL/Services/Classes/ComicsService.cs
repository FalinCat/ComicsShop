using BLL.Services.Interfaces;
using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL.Services.Classes
{
    public class ComicsService : IComicsService
    {
        private readonly IComicsRepository comicsRepository;

        public ComicsService()
        {
            comicsRepository = new ComicsRepository();
        }

        public Comics Add(Comics entity)
        {
            return comicsRepository.Add(entity);
        }

        public bool Delete(Comics entity)
        {
            return comicsRepository.Delete(entity);
        }

        public bool Edit(Comics entity)
        {
            return comicsRepository.Edit(entity);
        }

        public List<Comics> GetAll()
        {
            return comicsRepository.GetAll();
        }

        public Comics GetByName(string name)
        {
            return comicsRepository.FindByName(name);
        }

        public List<Comics> GetManyByFilter(Expression<Func<Comics, bool>> filter = null)
        {
            return comicsRepository.FindMany(filter);
        }

        public Comics GetOneByFilter(Expression<Func<Comics, bool>> filter = null)
        {
            return comicsRepository.FindOne(filter);
        }
    }
}
