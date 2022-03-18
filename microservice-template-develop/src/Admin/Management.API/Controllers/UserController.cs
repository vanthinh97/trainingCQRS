using Management.API.Application.UserApp.Commands.Models;
using Management.API.Application.UserApp.Queries.Models;
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

        /// <summary>
        /// Lấy ra dữ liệu 1 người dùng
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("get-detail")]
        [HttpGet]
        [ProducesResponseType(typeof(JsonResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserDetailAsync([FromQuery] GetUserDetailQuery query, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(query, cancellationToken);
        }

        /// <summary>
        /// Lấy ra dữ liệu n người dùng
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("get-list")]
        [HttpGet]
        [ProducesResponseType(typeof(JsonResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsersAsync([FromQuery] GetUsersQuery query, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(query, cancellationToken);
        }

        /// <summary>
        /// update group nguoi dung
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("update-group")]
        [HttpPut]
        [ProducesResponseType(typeof(JsonResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateGroupAsync([FromBody] UpdateGroupUserCommand command, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(command, cancellationToken);
        }
    }
}
