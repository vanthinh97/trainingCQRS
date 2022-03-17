using Management.API.Application.UserApp.Commands.Models;
using Management.API.Helper;
using Management.Domain.Models.GroupAggregate;
using Management.Domain.Models.GroupUserAggregate;
using Management.Domain.Models.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Application.UserApp.Commands.Handlers
{
    /// <summary>
    /// Lớp xử lý của <see cref="CreateUserCommandHandler"/>.
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, JsonResponse<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupUserRepository _groupUserRepository;
        private readonly ICommonHelper _commonHelper;
        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="CreateUserCommandHandler"/>
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="groupUserRepository"></param>
        /// <param name="groupRepository"></param>
        /// <param name="commonHelper"></param>
        public CreateUserCommandHandler(IUserRepository userRepository, ICommonHelper commonHelper, IGroupUserRepository groupUserRepository, IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _commonHelper = commonHelper;
            _groupUserRepository = groupUserRepository;
            _groupRepository = groupRepository;
        }

        /// <summary>
        /// Handler.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResponse<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var checkEmail = await _userRepository.GetByEmailAsync(request.Email);
            if (checkEmail != null)
            {
                return new BadRequestResponse<int>("Email đã tồn tại", null);
            }

            //Hash password
            request.Password = _commonHelper.HashSha256(request.Password);

            //Add user
            var user = new User(request.FirstName, request.LastName, request.Email, request.Password, request.BirthDay);
            await _userRepository.AddAsync(user);

            if (!await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
            {
                return new BadRequestResponse<int>("Đã xảy ra lỗi", null);
            }

            //check list group
            var groups = await _groupRepository.GetListAsync(request.GroupIds);
            if (request.GroupIds.Count != groups.Count)
            {
                return new BadRequestResponse<int>($"Dữ liệu k hợp lệ", null);
            }

            //add to group user
            foreach (var groupId in request.GroupIds)
            {
                var groupUser = new GroupUser(groupId, user.Id);
                await _groupUserRepository.AddAsync(groupUser);
            }

            await _groupUserRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new OkResponse<int>("OK", user.Id);
        }
    }
}
