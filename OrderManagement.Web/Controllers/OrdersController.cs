using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Services;
using OrderManagement.Web.Models;

namespace OrderManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> Get()
        {
            return  _mapper.Map<IEnumerable<OrderDto>>(await _orderService.GetOrdersList());
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var order = await _orderService.GetOrderById(id);
            //order.OrderDate = order.OrderDate.Date;
            if (order == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderDto>(await _orderService.GetOrderById(id)));
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post(OrderDto order)
        {
            await _orderService.CreateOrder(_mapper.Map<Order>(order));

            return CreatedAtAction("Post", new { id = order.Id }, order);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrderDto order)
        {
            if (id != order.Id)
            {
                return BadRequest("Not a valid order id");
            }
             
            await _orderService.UpdateOrder(_mapper.Map<Order>(order));
             
            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid order id");

            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderService.DeleteOrder(order);

            return NoContent();
        }

        
        [HttpPut]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            if (!ids.Any())
                return BadRequest();

            await _orderService.DeleteAllOrder(ids);

            return NoContent();
        }
    }
}
