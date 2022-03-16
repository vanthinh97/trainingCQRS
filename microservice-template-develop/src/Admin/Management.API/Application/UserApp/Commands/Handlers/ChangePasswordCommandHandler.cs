using Management.API.Application.UserApp.Commands.Models;
using Management.API.Helper;
using Management.Domain.Models.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Application.UserApp.Commands.Handlers
{
    /// <summary>
    /// Lớp xử lý của <see cref="ChangePasswordCommandHandler"/>.
    /// </summary>
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, JsonResponse<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommonHelper _commonHelper;

        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="ChangePasswordCommandHandler"/>
        /// </summary>
        /// <param name="userRepository"></param>
        public ChangePasswordCommandHandler(IUserRepository userRepository, ICommonHelper commonHelper)
        {
            _userRepository = userRepository;
            _commonHelper = commonHelper;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<JsonResponse<int>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user == null) return new BadRequestResponse<int>("User k tồn tại", null);

            if (user.Password != _commonHelper.HashSha256(request.OldPassword)) return new BadRequestResponse<int>("PW nhập k đúng", null);

            user.Password = _commonHelper.HashSha256(request.NewPassword);

            if (!await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
            {
                return new BadRequestResponse<int>("Đã xảy ra lỗi", null);
            }

            return new OkResponse<int>("OK", user.Id);
        }
    }
}
