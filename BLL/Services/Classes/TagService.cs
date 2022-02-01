using BLL.Managers.Interfaces;
using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using Domain.Models;

namespace BLL.Services.Classes
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;

        public TagService()
        {
            tagRepository = new TagRepository();
        }

        public Tag GetTagByName(string name)
        {
            return tagRepository.FindByName(name);
        }
    }
}
