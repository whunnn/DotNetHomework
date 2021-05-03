using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Homework_5_1
{
    public class OrderException : ApplicationException
    {
        public OrderException(string message) : base(message) { }
    }
    [Serializable]
    public class Order
    {
        public int OrderId { get; set; }   //订单ID
        public int TotalCost { get; set; }  //订单总金额
        public string BuyerName { get; set; }  //客户姓名
        public string Address { get; set; } //配送地址
        public string PaymentWay { get; set; } //支付方式
        public List<OrderDetails> Goods { get; set; } //商品明细


        //重写Equals()方法
        public override bool Equals(object obj)
        {
            var m = obj as Order;
            if (m == null) return false;
            return OrderId == m.OrderId && BuyerName == m.BuyerName;
        }

        //重写GetHashCode()方法
        public override int GetHashCode()
        {
            return BuyerName.GetHashCode() * OrderId;
        }

        public Order() { }
        public Order(int OrderId, string BuyerName, string Address, string PaymentWay, List<OrderDetails> goods)
        {
            this.OrderId = OrderId;
            this.BuyerName = BuyerName;
            this.Address = Address;
            this.PaymentWay = PaymentWay;
            this.Goods = goods;
            this.TotalCost = 0;
            foreach (OrderDetails item in goods)
            {
                TotalCost += item.GoodsCount * item.GoodsPrice;
            }
        }
        //新增订单明细
        public void AddOrder(OrderDetails orderDetails)
        {
            /*  bool flag = true;
              foreach (OrderDetails n in Goods)
              {
                  if (n == orderDetails) flag = false;
              }
              */
            if (!Goods.Contains(orderDetails))
            {
                Goods.Add(orderDetails);
                TotalCost += orderDetails.GoodsCount * orderDetails.GoodsPrice;
                Console.WriteLine($"为订单{this.OrderId}添加该明细成功");
            }
            else Console.WriteLine($"订单{this.OrderId}已存在该明细");

        }
        //判断此订单是否含有某种商品 
        public bool HaveGoods(string s)
        {
            foreach (OrderDetails n in Goods)
            {
                if (n.GoodsName == s) return true;
            }
            return false;
        }
        //重写ToString()函数
        public override string ToString()
        {
            string s = "订单编号：" + OrderId + " 客户姓名：" + BuyerName + " 送货地址：" + Address + " 支付方式：" + PaymentWay + "\n订单明细如下：\n";
            foreach (OrderDetails item in Goods)
            {
                s += item;
            }
            s += "订单总金额：" + TotalCost + "\n ---------------------------------------------------------------";
            return s;
        }
    }


   public class OrderDetails
    {
        public string GoodsName { get; set; } //商品名
        public int GoodsCount { get; set; }  //商品数量
        public int GoodsPrice { get; set; }   //商品单价

        public OrderDetails() { }
        public OrderDetails(string GoodsName, int GoodsPrice, int GoodsCount)
        {
            this.GoodsName = GoodsName;
            this.GoodsCount = GoodsCount;
            this.GoodsPrice = GoodsPrice;
        }
        //重写Equals()方法
        public override bool Equals(object obj)
        {
            OrderDetails m = obj as OrderDetails;
            if (m == null) return false;
            return GoodsName == m.GoodsName && GoodsPrice == m.GoodsPrice;
        }
        //重写GetHashCode()方法
        public override int GetHashCode()
        {
            return GoodsName.GetHashCode() * GoodsPrice;
        }
        public override string ToString()
        {
            return "商品名称：" + GoodsName + " 商品单价：" + GoodsPrice + " 商品个数：" + GoodsCount + "\n";
        }
    }


    public class Goods
    {
        public string Name { set; get; }
        public int Price { set; get; }
        public Goods(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return Name + ":" + Price;
        }
    }


    public class OrderService
    {
        public static List<Order> orders=new List<Order>();
        public  OrderService()
        {           
        }

        //根据订单号查询
        public static List<Order> SelectByOrderId(int min, int max)
        {
            var query = from n in orders
                        where n.OrderId <= max && n.OrderId >= min
                        orderby n.TotalCost
                        select n;
            return query.ToList();
        }
        //根据客户名查询
        public static List<Order> SelectByBuyerName(string buyername)
        {
            var query = from n in orders
                        where n.BuyerName == buyername
                        orderby n.TotalCost
                        select n;
            return query.ToList();
        }
        //根据商品名查询
        public static List<Order> SelectByGoodsName(string goodsname)
        {
            var query = from n in orders
                        where n.HaveGoods(goodsname)
                        orderby n.TotalCost
                        select n;
            return query.ToList();
        }
        //根据订单金额查询
        public static List<Order> SelectByTotalCost(int min, int max)
        {
            var query = from n in orders
                        where n.TotalCost <= max && n.TotalCost >= min
                        orderby n.TotalCost
                        select n;
            return query.ToList();
        }
        //添加订单操作
        public static void AddOrder(Order order)
        {
            /*
            bool flag = true;
            foreach(Order n in orders)
            {
                if (n == order) flag = false;
            }
            */
            if (!orders.Contains(order))
            {
                orders.Add(order);
                Console.WriteLine($"订单{order.OrderId}已添加");
            }
            else Console.WriteLine("订单已存在");
        }

        //删除订单操作
        public static void DeleteOrder(Order order)
        {
          //  try
           // {
                if(orders.Remove(order))
                Console.WriteLine($"订单{order.OrderId}删除成功");
                else throw new OrderException("不存在该订单");
          //  }
            //catch (OrderException e)
            //{
            //    Console.WriteLine("删除订单失败"+e.Message);
            //}
        }

        //修改订单操作
        public static void ChangeOrder(Order order1, Order order2)
        {
         //   try
          //  {
                int n = orders.IndexOf(order1);
                if(n<0) throw new OrderException("不存在该订单");
                orders[n] = order2;
                Console.WriteLine($"订单{order1.OrderId}修改成功");
           // }
            //catch (OrderException e)
            //{
            //    Console.WriteLine("修改订单失败"+e.Message);
            //}
        }

        //默认按ID排序
        public static void Sort()
        {
            orders.Sort((p1, p2) => p1.OrderId - p2.OrderId);
        }

        //Lambda表达式进行自定义排序
        public static void Sort(Comparison<Order> t)
        {
            orders.Sort(t);
        }

        public static void Export(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (List<Order>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmlSerializer.Serialize(fs,orders);
            }
            Console.WriteLine("\n Serialize as XML");
            Console.WriteLine(File.ReadAllText(filename));
        }
        public static void Import(string filepath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs=new FileStream(filepath, FileMode.Open))
            {
                List<Order> orders2 = (List<Order>)xmlSerializer.Deserialize(fs);
                Console.WriteLine("\nDeserialize form orders.xml");
                foreach(Order order in orders2)
                {
                    Console.WriteLine(order);
                }
            }
        }
    }
    class Program
    {
        //打印订单函数
        public static void Show(List<Order> n)
        {
            foreach (Order ods in n)
            {
                Console.WriteLine(ods);
            }
        }
        static void Main(string[] args)
        {
            //添加商品
            Goods goods1 = new Goods("basketball", 100);
            Goods goods2 = new Goods("football", 150);
            Goods goods3 = new Goods("volleyball", 50);
            Goods goods4 = new Goods("baseball", 30);
            Goods goods5 = new Goods("shoes", 200);
            Goods goods6 = new Goods("T-short", 80);
            //添加明细
            OrderDetails item1 = new OrderDetails(goods1.Name, goods1.Price, 1);
            OrderDetails item2 = new OrderDetails(goods2.Name, goods2.Price, 2);
            OrderDetails item3 = new OrderDetails(goods3.Name, goods3.Price, 3);
            OrderDetails item4 = new OrderDetails(goods4.Name, goods4.Price, 4);
            OrderDetails item5 = new OrderDetails(goods5.Name, goods5.Price, 1);
            OrderDetails item6 = new OrderDetails(goods6.Name, goods6.Price, 2);
            OrderDetails item7 = new OrderDetails(goods4.Name, goods4.Price, 2);
            OrderDetails item8 = new OrderDetails(goods3.Name, goods3.Price, 4);
            //添加订单明细
            List<OrderDetails> items1 = new List<OrderDetails>(2) { item1, item2 };
            List<OrderDetails> items2 = new List<OrderDetails>(3) { item3, item4, item5 };
            List<OrderDetails> items3 = new List<OrderDetails>(2) { item3, item5 };
            List<OrderDetails> items4 = new List<OrderDetails>(2) { item4, item6 };
            List<OrderDetails> items5 = new List<OrderDetails>(1) { item5 };
            List<OrderDetails> items6 = new List<OrderDetails>(4) { item1, item2, item7, item8 };

            //添加订单
            
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

            Console.WriteLine("所有订单如下：");
            Show(OrderService.orders);

            //按照总费用查询
            Console.WriteLine("查询订单花费在200-300的订单：");
            Show(OrderService.SelectByTotalCost(200, 300));
            Console.WriteLine("\n\n");

            //按照客户姓名查询
            Console.WriteLine("查询订单客户名为buyer3的订单：");
            Show(OrderService.SelectByBuyerName("buyer3"));
            Console.WriteLine("\n\n");

            //按照是否含有某种商品查询
            Console.WriteLine("查询订单含有volleyb的订单:");
            Show(OrderService.SelectByGoodsName("volleyball"));
            Console.WriteLine("\n\n");

            //按照订单编号查询
            Console.WriteLine("查询订单编号在2-4的订单:");
            Show(OrderService.SelectByOrderId(2, 4));
            Console.WriteLine("\n\n");

            //删除订单操作
            Console.WriteLine("删除订单3");
            OrderService.DeleteOrder(order3);
            Show(OrderService.orders);
            Console.WriteLine("\n\n");

            //修改订单操作
            Console.WriteLine("修改订单2前：");
            Console.WriteLine(OrderService.orders[1]);
            Console.WriteLine("修改订单2后：");
            OrderService.ChangeOrder(order2, new Order(2, "buyer4", "address4", "Alipay", items2));
            Console.WriteLine(OrderService.orders[1]);
            Console.WriteLine("\n\n");

            //将订单按TotalCost排序
            Console.WriteLine("将订单按照总花费排序:");
            OrderService.Sort((p1, p2) => p1.TotalCost - p2.TotalCost);
            Show(OrderService.orders);

            OrderService.Export("Orders.xml");
            OrderService.Import("Orders.xml");
        }
    }
}

