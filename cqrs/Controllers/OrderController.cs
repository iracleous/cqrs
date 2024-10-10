using cqrs.Models;
using cqrs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cqrs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController: ControllerBase
{
    private readonly OrderCommandHandler _commandHandler;
    private readonly OrderQueryService _queryService;

    public OrderController(OrderCommandHandler commandHandler, OrderQueryService queryService)
    {
        _commandHandler = commandHandler;
        _queryService = queryService;
    }

    [HttpPost]
    public void AddItemToOrder([FromBody]OrderItem orderItem )
    {
        _commandHandler.HandleAddItemToOrder(orderItem.OrderId, orderItem.ProductName, 
            orderItem.Quantity, orderItem.PricePerUnit);
    }

    [HttpGet("{orderId}")]
    public Order GetOrder(Guid orderId)
    {
        return _queryService.GetOrder(orderId);
    }
}
