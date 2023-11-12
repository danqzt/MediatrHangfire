using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire.MediatR;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sales
{
    public class PlaceOrder : IRequest
    {
        public Guid OrderId { get; set; }
    }

    public class PlaceOrderController : Controller
    {
        private readonly IMediator _mediator;

        public PlaceOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/sales/orders/{orderId:Guid}")]
        public IActionResult Action([FromRoute] Guid orderId)
        {
            _mediator.Enqueue("Place Order", new PlaceOrder
            {
                OrderId = orderId
            });

            return NoContent();
        }
    }
}