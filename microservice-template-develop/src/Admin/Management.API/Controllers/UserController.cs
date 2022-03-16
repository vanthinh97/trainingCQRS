using Management.API.Application.UserApp.Commands.Models;
using MediatR;
using Microservices.Core.API.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserController : CustomController
    {
        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="UserController"/>.
        /// </summary>
        /// <param name="mediator"></param>
        public UserController(IMediator mediator) : base(mediator)
        {
        }


        /// <summary>
        /// API Thêm người dùng
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(JsonResponse<int>), (int)HttpStatusCode.OK)]
        //  [AuthorizeFilter]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(command, cancellationToken);
        }

        /// <summary>
        /// API Update người dùng
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        [ProducesResponseType(typeof(JsonResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(command, cancellationToken);
        }

        /// <summary>
        /// API ChangePW người dùng
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("change-password")]
        [HttpPost]
        [ProducesResponseType(typeof(JsonResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(command, cancellationToken);
        }

        /// <summary>
        /// Delete người dùng
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("delete")]
        [HttpPost]
        [ProducesResponseType(typeof(JsonResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUsersAsync([FromBody] DeleteUsersCommand command, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(command, cancellationToken);
        }
    }
}
