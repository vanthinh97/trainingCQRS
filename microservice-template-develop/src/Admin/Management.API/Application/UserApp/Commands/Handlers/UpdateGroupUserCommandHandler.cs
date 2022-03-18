using Management.API.Application.UserApp.Commands.Models;
using Management.Domain.Models.GroupUserAggregate;
using Management.Domain.Models.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Application.UserApp.Commands.Handlers
{
    /// <summary>
    /// Lớp xử lý của <see cref="UpdateGroupUserCommandHandler"/>
    /// </summary>
    public class UpdateGroupUserCommandHandler : IRequestHandler<UpdateGroupUserCommand, JsonResponse<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupUserRepository _groupUserRepository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="groupUserRepository"></param>
        public UpdateGroupUserCommandHandler(IUserRepository userRepository, IGroupUserRepository groupUserRepository)
        {
            _userRepository = userRepository;
            _groupUserRepository = groupUserRepository;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<JsonResponse<int>> Handle(UpdateGroupUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user == null) return new BadRequestResponse<int>("User k tồn tại", null);

            // Truy vấn các group của user
            var groupsOfUser = await _groupUserRepository.GetGroupUserByUserIdAsync(user.Id);
            var currentGroupUsers = groupsOfUser.Select(x => x.GroupId).ToList();

            // list group de delete va them moi
            var deleteGroupsOfUser = currentGroupUsers.Except(request.GroupIds);
            var addGroupsOfUser = request.GroupIds.Except(currentGroupUsers);

            if (addGroupsOfUser != null)
            {
                foreach (var item in addGroupsOfUser)
                {
                    await _groupUserRepository.AddAsync(new GroupUser(item, user.Id));
                }
            }

            _groupUserRepository.RemoveListGroup(groupsOfUser.Where(x => deleteGroupsOfUser.Contains(x.GroupId)).ToList());

            if (await _groupUserRepository.UnitOfWork.SaveEntitiesAsync())
            {
                return new BadRequestResponse<int>("Đã xảy ra lỗi", null);
            }

            return new OkResponse<int>("OK");
        }
    }
}
