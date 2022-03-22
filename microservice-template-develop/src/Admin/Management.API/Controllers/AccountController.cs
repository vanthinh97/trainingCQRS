using Management.API.Application.Account.Commands.Models;
using Management.Domain.Models.AccountAggregate;
using MediatR;
using Microservices.Core.API.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountController : CustomController
    {
        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="AccountController"/>.
        /// </summary>
        /// <param name="mediator"></param>
        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(typeof(JsonResponse<UserLoginDto>), (int)HttpStatusCode.OK)]
        //  [AuthorizeFilter]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(command, cancellationToken);
        }
    }
}
