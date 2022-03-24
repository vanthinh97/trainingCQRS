using Management.API.Application.UserApp.Commands.Models;
using Management.Domain.Models.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Application.UserApp.Commands.Handlers
{
    /// <summary>
    /// Lớp xử lý của <see cref="UpdateUserCommandHandler"/>.
    /// </summary>
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, JsonResponse<int>>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="UpdateUserCommandHandler"/>
        /// </summary>
        /// <param name="userRepository"></param>
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handler.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResponse<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                return new BadRequestResponse<int>("K tim thay user", null);
            }

            var checkEmail = await _userRepository.GetByEmailAsync(request.Email);
            if (checkEmail != null)
            {
                return new BadRequestResponse<int>("Email đã tồn tại", null);
            }

            user.Update(request.FirstName, request.LastName, request.Email, request.BirthDay);

            if (!await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
            {
                return new BadRequestResponse<int>("Đã xảy ra lỗi", null);
            }

            return new OkResponse<int>("OK", user.Id);
        }
    }
}
