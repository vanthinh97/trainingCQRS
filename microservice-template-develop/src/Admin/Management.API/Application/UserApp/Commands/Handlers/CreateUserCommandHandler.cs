using Management.API.Application.UserApp.Commands.Models;
using Management.API.Helper;
using Management.Domain.Models.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        private readonly ICommonHelper _commonHelper;
        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="CreateUserCommandHandler"/>
        /// </summary>
        /// <param name="userRepository"></param>
        /// /// <param name="commonHelper"></param>
        public CreateUserCommandHandler(IUserRepository userRepository, ICommonHelper commonHelper)
        {
            _userRepository = userRepository;
            _commonHelper = commonHelper;
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

            request.Password = _commonHelper.HashSha256(request.Password);
            var user = new User(request.FirstName, request.LastName, request.Email, request.Password, request.BirthDay);
            await _userRepository.AddAsync(user);
            if (!await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
            {
                return new BadRequestResponse<int>("Đã xảy ra lỗi", null);
            }
            return new OkResponse<int>("OK", user.Id);
        }
    }
}
