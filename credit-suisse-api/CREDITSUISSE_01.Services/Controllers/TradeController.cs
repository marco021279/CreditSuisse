using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CREDITSUISSE_01.Services.Shared;
using CREDITSUISSE_02.Application.Trade.Dtos;
using CREDITSUISSE_02.Application.Trade.Interfaces;
using CREDITSUISSE_04.Core.Bus;
using CREDITSUISSE_04.Core.Notifications;

namespace CREDITSUISSE_01.Services.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class TradeController : ApiController
    {
        private readonly ITradeService _service;

        public TradeController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, ITradeService service) : base(notifications, mediator)
        {
            _service = service;
        }

        [HttpGet("get-all-categorized")]
        [MapToApiVersion("1")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TradeDto>))]
        [ProducesResponseType(400, Type = typeof(string[]))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllCategorized();
            return Response(result);
        }
    }
}
