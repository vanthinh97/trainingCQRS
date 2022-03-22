using Management.API.Application.Account.Commands.Models;
using Management.API.Helper;
using Management.Domain.Models.AccountAggregate;
using MediatR;
using Microservices.Core.API.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Application.Account.Commands.Handlers
{
    /// <summary>
    /// Lớp xử lý của <see cref="LoginCommandHandler"/>.
    /// </summary>
    public class LoginCommandHandler : IRequestHandler<LoginCommand, JsonResponse<UserLoginDto>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICommonHelper _commonHelper;

        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="LoginCommandHandler"/>
        /// </summary>
        /// <param name="accountRepository"></param>
        /// <param name="commonHelper"></param>
        public LoginCommandHandler(IAccountRepository accountRepository, ICommonHelper commonHelper)
        {
            _accountRepository = accountRepository;
            _commonHelper = commonHelper;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<JsonResponse<UserLoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _accountRepository.GetByEmailAsync(request.Email);
            if (user == null) return new BadRequestResponse<UserLoginDto>("User k tồn tại", null);

            if (user.Password != _commonHelper.HashSha256(request.Password)) return new BadRequestResponse<UserLoginDto>("PW nhập k đúng", null);

            return new OkResponse<UserLoginDto>("OK", new UserLoginDto
            {
                Username = user.FirstName,
                Token = _commonHelper.CreateToken(request.Email),
            });
        }
    }
}
