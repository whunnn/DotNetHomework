using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDB;
        public OrderController(OrderContext context)
        {
            this.orderDB = context;
        }
       

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return new OrderService(orderDB).queryAllOrders();
        }


        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var result = new OrderService(orderDB).SearchByOrderId(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                new OrderService(orderDB).removeOrder(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpPost]
        public bool Add(Order order)
        {
            return new OrderService(orderDB).addOrder(order);
        }
    }
}
