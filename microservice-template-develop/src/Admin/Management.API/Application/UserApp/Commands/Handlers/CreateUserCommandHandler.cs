using Management.API.Application.UserApp.Commands.Models;
using Management.API.Helper;
using Management.Domain.Models.GroupAggregate;
using Management.Domain.Models.GroupUserAggregate;
using Management.Domain.Models.OrganizationAggregate;
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
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICommonHelper _commonHelper;
        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="CreateUserCommandHandler"/>
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="groupRepository"></param>
        /// <param name="organizationRepository"></param>
        /// <param name="commonHelper"></param>
        public CreateUserCommandHandler(
            IUserRepository userRepository, 
            ICommonHelper commonHelper,
            IGroupRepository groupRepository, IOrganizationRepository organizationRepository)
        {
            _userRepository = userRepository;
            _commonHelper = commonHelper;
            _groupRepository = groupRepository;
            _organizationRepository = organizationRepository;
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

            //check list group
            var groups = await _groupRepository.GetListAsync(request.GroupIds);
            if (request.GroupIds.Count != groups.Count)
            {
                return new BadRequestResponse<int>($"Dữ liệu k hợp lệ", null);
            }

            //check list organizations
            var organizations = await _organizationRepository.GetListAsync(request.OrganizationIds);
            if (request.OrganizationIds.Count != organizations.Count)
            {
                return new BadRequestResponse<int>($"Dữ liệu k hợp lệ", null);
            }

            //Hash password
            request.Password = _commonHelper.HashSha256(request.Password);


            //Add user
            var user = new User(request.FirstName, request.LastName, request.Email, request.Password, request.BirthDay);
            user.AddGroup(request.GroupIds);
            user.AddOrganization(request.OrganizationIds);
            await _userRepository.AddAsync(user);


            if (!await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
            {
                return new BadRequestResponse<int>("Đã xảy ra lỗi", null);
            }


            return new OkResponse<int>("OK", user.Id);
        }
    }
}
