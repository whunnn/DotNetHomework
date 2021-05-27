
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderApi
{
    //订单类
    public class Order : IComparable
    {
        //定义订单号、顾客、订单总额
        [Key]
        public int OrderId { get; set; }
        public String customer { get; set; }
        public int totalCost { get; set; }
        //多个订单明细
        public List<OrderDetails> orderDetails { get; set; }
        public Order()
        {
            orderDetails = new List<OrderDetails>();
        }
        //重写排序，默认订单号排序
        public int CompareTo(object obj)
        {
            Order a = obj as Order;
            return this.OrderId.CompareTo(a.OrderId);
        }

        //重写equal方法
        public override bool Equals(object obj)
        {
            Order o = obj as Order;
            return o.OrderId == this.OrderId;
        }
        //重写tostring方法
        public override string ToString()
        {
            return OrderId + "   " + customer + "   " + totalCost + "   ";
        }
    }


    //订单明细类
    public class OrderDetails
    {
        //定义商品名、商品数量、商品单价
        public int OrderDetailsId { get; set; }
        public String name { get; set; }
        public int num { get; set; }
        public int price { get; set; }
        public int total { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }


        //重写equals方法
        public override bool Equals(object obj)
        {
            OrderDetails od = obj as OrderDetails;
            return od.num == num && od.price == price;
        }
        //重写tostring方法
        public override string ToString()
        {
            return name + "   " + num + "   " + price + "   " + num * price + "   ";
        }
    }

    //订单服务类
    [Serializable]
    public class OrderService
    {
        private OrderContext context;
        public OrderService(OrderContext context)
        {
            this.context = context;
        } 

        public bool addOrder(Order order)
        {
            if(context.Orders.Where(o=>o.OrderId==order.OrderId).Any())
            {
                return false;
            }

            context.Orders.Add(order);
            context.Entry(order).State = EntityState.Added;
            context.SaveChanges();
            return true;
            
        }
        public void removeOrder(int id)
        {
            
            var currentOrder =  context.Orders.Include("OrderDetails").Where(o => o.OrderId == id).FirstOrDefault();
            context.Orders.Remove(currentOrder);
            context.SaveChanges();
            
        }
        public void editOrder(Order order)
        {
            
            var currentOrder =  context.Orders.Include("OrderDetails").Where(o => o.OrderId == order.OrderId).FirstOrDefault();
            currentOrder.customer = order.customer;
            currentOrder.orderDetails = order.orderDetails;
            currentOrder.totalCost = order.totalCost;
            context.Entry(currentOrder).State = EntityState.Modified;
            context.SaveChanges();
            
        }
        public List<Order> queryAllOrders()
        {
            return context.Orders.Include("OrderDetails").ToList();           
        }

        //查询订单        
        public Order SearchByOrderId(int OrderId)
        {

            return context.Orders.Include("OrderDetails").
                             Where(o => o.OrderId == OrderId).FirstOrDefault();

           
        }
    }




}
