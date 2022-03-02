using AutoMapper;
using TaskManager.Models;
using TaskManager.Repositories.UserRepository;
using TaskManager.ViewModels;

namespace TaskManager.MappingConfigurations.Resolvers
{
    public class GetUserResolver : IValueResolver<TaskCreateViewModel, Models.Task, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserResolver(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Resolve(TaskCreateViewModel source, Models.Task destination, User destMember, ResolutionContext context)
        {
            return _userRepository.GetById(source.CreatorId);
        }
    }
}