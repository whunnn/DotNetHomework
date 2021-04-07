using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_5_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_6_1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        [TestInitialize]
        public void InitialOrder()
        {
            Goods goods1 = new Goods("basketball", 100);
            Goods goods2 = new Goods("football", 150);
            Goods goods3 = new Goods("volleyball", 50);
            Goods goods4 = new Goods("baseball", 30);
            Goods goods5 = new Goods("shoes", 200);
            Goods goods6 = new Goods("T-short", 80);

            OrderDetails item1 = new OrderDetails(goods1.Name, goods1.Price, 1);
            OrderDetails item2 = new OrderDetails(goods2.Name, goods2.Price, 2);
            OrderDetails item3 = new OrderDetails(goods3.Name, goods3.Price, 3);
            OrderDetails item4 = new OrderDetails(goods4.Name, goods4.Price, 4);
            OrderDetails item5 = new OrderDetails(goods5.Name, goods5.Price, 1);
            OrderDetails item6 = new OrderDetails(goods6.Name, goods6.Price, 2);
            OrderDetails item7 = new OrderDetails(goods4.Name, goods4.Price, 2);
            OrderDetails item8 = new OrderDetails(goods3.Name, goods3.Price, 4);

            List<OrderDetails> items1 = new List<OrderDetails>(2) { item1, item2 };
            List<OrderDetails> items2 = new List<OrderDetails>(3) { item3, item4, item5 };
            List<OrderDetails> items3 = new List<OrderDetails>(2) { item3, item5 };
            List<OrderDetails> items4 = new List<OrderDetails>(2) { item4, item5 };
            List<OrderDetails> items5 = new List<OrderDetails>(1) { item6 };
            List<OrderDetails> items6 = new List<OrderDetails>(4) { item1, item2, item7, item8 };

            Order order1 = new Order(1, "buyer1", "address1", "Alipay", items1);
            Order order2 = new Order(2, "buyer1", "address2", "WeChatPay", items2);
            Order order3 = new Order(3, "buyer2", "address2", "WeChatPay", items3);
            Order order4 = new Order(4, "buyer3", "address2", "Alipay", items4);
            Order order5 = new Order(5, "buyer3", "address2", "Alipay", items5);
            Order order6 = new Order(6, "buyer4", "address2", "CreditCard", items6);
            OrderService.AddOrder(order1);
            OrderService.AddOrder(order2);
            OrderService.AddOrder(order3);
            OrderService.AddOrder(order4);
            OrderService.AddOrder(order5);
            OrderService.AddOrder(order6);
        }

        [TestMethod()]
        public void SelectByOrderIdTest()
        {
            Goods goods1 = new Goods("volleyball", 50);
            Goods goods2 = new Goods("shoes", 200);
            OrderDetails item1 = new OrderDetails(goods1.Name, goods2.Price, 3);
            OrderDetails item2 = new OrderDetails(goods1.Name, goods2.Price, 1);
            List<OrderDetails> items = new List<OrderDetails>(2) { item1, item2 };
            List<Order> orderlist = new List<Order>{new Order(3, "buyer2", "address2", "WeChatPay", items)};
            List<Order> actual1 = OrderService.SelectByOrderId(3, 3);
            List<Order> actual2 = OrderService.SelectByOrderId(7, 8);
            Assert.AreEqual(orderlist,actual1);
            Assert.IsNull(actual2);
        }

        [TestMethod()]
        public void SelectByBuyerNameTest()
        {
            Goods goods1 = new Goods("volleyball", 50);
            Goods goods2 = new Goods("shoes", 200);
            OrderDetails item1 = new OrderDetails(goods1.Name, goods2.Price, 3);
            OrderDetails item2 = new OrderDetails(goods1.Name, goods2.Price, 1);
            List<OrderDetails> items = new List<OrderDetails>(2) { item1, item2 };
            List<Order> orderlist = new List<Order> { new Order(3, "buyer2", "address2", "WeChatPay", items) };
            List<Order> actual1 = OrderService.SelectByBuyerName("buyer2");
            List<Order> actual2 = OrderService.SelectByBuyerName("buyer5");
            Assert.AreEqual(orderlist, actual1);
            Assert.IsNull(actual2);
        }

        [TestMethod()]
        public void SelectByGoodsNameTest()
        {
            Goods goods = new Goods("T-short", 80);
            OrderDetails item = new OrderDetails(goods.Name, goods.Price, 2);
            List<OrderDetails> items = new List<OrderDetails>(1) { item };
            List<Order> orderlist = new List<Order> { new Order(5, "buyer3", "address2", "Alipay", items) };
            List<Order> actual1 = OrderService.SelectByGoodsName("T-short");
            List<Order> actual2 = OrderService.SelectByGoodsName("shoes");
            Assert.AreEqual(orderlist, actual1);
            Assert.IsNull(actual2);
        }

        [TestMethod()]
        public void SelectByTotalCostTest()
        {
            Goods goods = new Goods("T-short", 80);
            OrderDetails item = new OrderDetails(goods.Name, goods.Price, 2);
            List<OrderDetails> items = new List<OrderDetails>(1) { item };
            List<Order> orderlist = new List<Order> { new Order(5, "buyer3", "address2", "Alipay", items) };
            List<Order> actual1 = OrderService.SelectByTotalCost(160,160);
            List<Order> actual2 = OrderService.SelectByTotalCost(1000, 2000);
            Assert.AreEqual(orderlist, actual1);
            Assert.IsNull(actual2);
        }


        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void DeleteOrderTest()
        {
            Goods goods = new Goods("T-short", 80);
            OrderDetails item = new OrderDetails(goods.Name, goods.Price, 2);
            List<OrderDetails> items = new List<OrderDetails>(1) { item };
            Order order=new Order(8, "buyer3", "address2", "Alipay",items);
            OrderService.DeleteOrder(order);               
        }

        [TestMethod()]
        public void ChangeOrderTest1()
        {
            List<Order> orders = OrderService.orders;
            Goods goods = new Goods("T-short", 80);
            OrderDetails item = new OrderDetails(goods.Name, goods.Price, 2);
            List<OrderDetails> items = new List<OrderDetails>(1) { item };
            Order order1 = new Order(5, "buyer3", "address2", "Alipay", items);
            Order order2 = new Order(5, "buyer4", "address4", "WeChatPay", items);
            OrderService.ChangeOrder(order1, order2);
            orders[orders.IndexOf(order1)] = order2;
            Assert.AreEqual(orders, OrderService.orders);

        }
        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void ChangeOrderTest2()
        {
            List<Order> orders = OrderService.orders;
            Goods goods = new Goods("T-short", 80);
            OrderDetails item = new OrderDetails(goods.Name, goods.Price, 2);
            List<OrderDetails> items = new List<OrderDetails>(1) { item };
            Order order1 = new Order(5, "buyer3", "address2", "Alipay", items);
            Order order2 = new Order(5, "buyer4", "address4", "WeChatPay", items);
            OrderService.ChangeOrder(order2, order1);

        }

        [TestMethod()]
        public void SortTest()
        {
            Goods goods1 = new Goods("basketball", 100);
            Goods goods2 = new Goods("football", 150);
            Goods goods3 = new Goods("volleyball", 50);
            Goods goods4 = new Goods("baseball", 30);
            Goods goods5 = new Goods("shoes", 200);
            Goods goods6 = new Goods("T-short", 80);

            OrderDetails item1 = new OrderDetails(goods1.Name, goods1.Price, 1);
            OrderDetails item2 = new OrderDetails(goods2.Name, goods2.Price, 2);
            OrderDetails item3 = new OrderDetails(goods3.Name, goods3.Price, 3);
            OrderDetails item4 = new OrderDetails(goods4.Name, goods4.Price, 4);
            OrderDetails item5 = new OrderDetails(goods5.Name, goods5.Price, 1);
            OrderDetails item6 = new OrderDetails(goods6.Name, goods6.Price, 2);
            OrderDetails item7 = new OrderDetails(goods4.Name, goods4.Price, 2);
            OrderDetails item8 = new OrderDetails(goods3.Name, goods3.Price, 4);

            List<OrderDetails> items1 = new List<OrderDetails>(2) { item1, item2 };
            List<OrderDetails> items2 = new List<OrderDetails>(3) { item3, item4, item5 };
            List<OrderDetails> items3 = new List<OrderDetails>(2) { item3, item5 };
            List<OrderDetails> items4 = new List<OrderDetails>(2) { item4, item5 };
            List<OrderDetails> items5 = new List<OrderDetails>(1) { item6 };
            List<OrderDetails> items6 = new List<OrderDetails>(4) { item1, item2, item7, item8 };

            Order order1 = new Order(1, "buyer1", "address1", "Alipay", items1);
            Order order2 = new Order(2, "buyer1", "address2", "WeChatPay", items2);
            Order order3 = new Order(3, "buyer2", "address2", "WeChatPay", items3);
            Order order4 = new Order(4, "buyer3", "address2", "Alipay", items4);
            Order order5 = new Order(5, "buyer3", "address2", "Alipay", items5);
            Order order6 = new Order(6, "buyer4", "address2", "CreditCard", items6);
            OrderService.AddOrder(order1);
            OrderService.AddOrder(order2);
            OrderService.AddOrder(order3);
            OrderService.AddOrder(order4);
            OrderService.AddOrder(order5);
            OrderService.AddOrder(order6);
            List<Order> orderlist = new List<Order> { order5, order4, order3, order1, order2, order6 };
            OrderService.Sort((p1, p2) => p1.TotalCost - p2.TotalCost);
            Assert.AreEqual(orderlist, OrderService.orders);

        }


        [TestMethod()]
        public void ExportTest()
        {
            OrderService.Export();
            Assert.IsTrue(File.Exists("test.xml"));
        }

    }
}