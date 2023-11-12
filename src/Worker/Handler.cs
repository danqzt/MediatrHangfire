using MediatR;
using Sales;
using System;
using System.Threading;
using System.Threading.Tasks;

public class PlaceOrderHandler : IRequestHandler<PlaceOrder>
{
    public Task<Unit> Handle(PlaceOrder request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}