using Management.API.Application.UserApp.Commands.Models;
using Management.Domain.Models.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Application.UserApp.Commands.Handlers
{
    /// <summary>
    /// Lớp xử lý của <see cref="DeleteUsersCommandHandler"/>.
    /// </summary>
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, JsonResponse<int>>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="DeleteUsersCommandHandler"/>
        /// </summary>
        /// <param name="userRepository"></param>
        public DeleteUsersCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<JsonResponse<int>> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Ids)
            {
                var user = await _userRepository.GetUserByIdAsync(item);
                if (user == null)
                {
                    return new BadRequestResponse<int>($"user id {item} k tồn tại", null);
                }
                user.IsDeleted = true;
            }

            if (!await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken))
            {
                return new BadRequestResponse<int>("Đã xảy ra lỗi", null);
            }

            return new OkResponse<int>("OK");
        }
    }
}
