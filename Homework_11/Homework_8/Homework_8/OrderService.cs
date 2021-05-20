using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Homework_8
{
    public class Order
    {
        public int OrderId { get; set; }   //订单ID
        public DateTime CreateTime { get; set; } //下单时间
        public string BuyerName { get; set; }  //客户姓名
        public string PaymentWay { get; set; } //支付方式
        public int TotalCost { get; set; }  //订单总金额

        public string Address { get; set; } //配送地址


        public List<OrderDetails> Goods { get; set; } //商品明细



        public Order() { Goods = new List<OrderDetails>(); CreateTime = DateTime.Now; }
        
        public Order(int OrderId, string BuyerName, string Address, string PaymentWay, List<OrderDetails> goods)
        {
            this.OrderId = OrderId;
            this.BuyerName = BuyerName;
            this.Address = Address;
            this.PaymentWay = PaymentWay;
            this.Goods = goods;
            this.TotalCost = 0;
            CreateTime = DateTime.Now;
            foreach (OrderDetails item in goods)
            {
                TotalCost += item.GoodsCount * item.GoodsPrice;
            }
        }
        //新增订单明细
        public void AddGoods(OrderDetails orderDetails)
        {
            if (Goods.Contains(orderDetails))
            {
                throw new ApplicationException("This orderdetail already exists!");
            }
            Goods.Add(orderDetails);
            TotalCost += orderDetails.GoodsCount * orderDetails.GoodsPrice;
        }

        //删除订单明细
        public void RemoveGoods(OrderDetails orderDetails)
        {
            Goods.Remove(orderDetails);
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

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderId == order.OrderId &&
                   BuyerName == order.BuyerName &&
                   EqualityComparer<List<OrderDetails>>.Default.Equals(Goods, order.Goods);
        }

        public override int GetHashCode()
        {
            int hashCode = 548202766;
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BuyerName);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderDetails>>.Default.GetHashCode(Goods);
            return hashCode;
        }
    }


    public class OrderDetails
    {
        public string Id { get; set; }
        public string GoodsId { get; set; }
        public Goods GoodsItem { get; set; }
        public string GoodsName { get => GoodsItem != null ? this.GoodsItem.Name : ""; } //商品名
        public int GoodsPrice { get => GoodsItem != null ? this.GoodsItem.Price : 0; }   //商品单价
        public int GoodsCount { get; set; }  //商品数量
        public int TotalPrice
        {
            get => GoodsItem == null ? 0 : GoodsItem.Price * GoodsCount;
        }   //明细总价

        public OrderDetails()
        {
            Id = Guid.NewGuid().ToString();
        }
        public OrderDetails(Goods item, int GoodsCount)
        {
            this.GoodsItem = item;
            this.GoodsCount = GoodsCount;           
        }
        public override string ToString()
        {
            return "商品名称：" + GoodsName + " 商品单价：" + GoodsPrice + " 商品个数：" + GoodsCount + "\n";
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   GoodsName == details.GoodsName;
        }

        public override int GetHashCode()
        {
            return 1864683322 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
        }
    }


    public class Goods
    {
        public string Id { get; set; }
        public string Name { set; get; }
        public int Price { set; get; }
        public Goods()
        {
            Id = Guid.NewGuid().ToString();
        }
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
        public static List<Order> orders
        {
            get
            {
                using(var db=new OrderingContext())
                {
                    return db.Orders.Include("OrderDetails").ToList<Order>();
                }
            }
        }
        public OrderService()
        {
        }

        //根据订单号查询
        public static List<Order> SelectByOrderId(int Id)
        {
            //var query = from n in orders
            //            where n.OrderId ==Id
            //            orderby n.TotalCost
            //            select n;
            //return query.ToList();
            using(var db=new OrderingContext())
            {
                var query = db.Orders.Include("OrderDetails").Where(order => order.OrderId == Id).ToList();
                return query;
            }
        }
        //根据客户名查询
        public static List<Order> SelectByBuyerName(string buyername)
        {
            //var query = from n in orders
            //            where n.BuyerName == buyername
            //            orderby n.TotalCost
            //            select n;
            //return query.ToList();
            using(var db=new OrderingContext())
            {
                var query = db.Orders.Include("OrderDetails").Where(order => order.BuyerName == buyername).ToList();
                return query;
            }
        }
        //根据支付方式查询
        public static List<Order> SelectByPaymentWay(string PaymentWay)
        {
            //var query = from n in orders
            //            where n.PaymentWay == PaymentWay
            //            orderby n.TotalCost
            //            select n;
            //return query.ToList();
            using(var db=new OrderingContext())
            {
                var query = db.Orders.Include("OrderDetails").Where(order => order.PaymentWay == PaymentWay).ToList();
                return query;
            }
        }
            //根据商品名查询
            public static List<Order> SelectByGoodsName(string goodsname)
        {
            //var query = from n in orders
            //            where n.HaveGoods(goodsname)
            //            orderby n.TotalCost
            //            select n;
            //return query.ToList();
            using(var db=new OrderingContext())
            {
                var query = db.Orders.Include("OrderDetails").Where(order => order.Goods.Any(item => item.GoodsItem.Name == goodsname));
                return query.ToList();
            }
        }
        //根据订单金额查询
        public static List<Order> SelectByTotalCost(int TotalCost)
        {
            //var query = from n in orders
            //            where n.TotalCost ==TotalCost
            //            orderby n.TotalCost
            //            select n;
            //return query.ToList();
            using(var db=new OrderingContext())
            {
                var query = db.Orders.Include("OrderDetails").Where(order => order.TotalCost == TotalCost).ToList();
                return query;
            }
        }
        //添加订单操作
        public static void AddOrder(Order order)
        {
            //if (orders.Contains(order))
            //{
            //    throw new ApplicationException($"the order {order.OrderId} already exists!");
            //}
            //orders.Add(order);
            using(var db=new OrderingContext())
            {
                db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        //删除订单操作
        public static void RemoveOrder(int orderId)
        {
            //orders.RemoveAll(o => o.OrderId == orderId);
            using (var db = new OrderingContext())
            {
                var order = db.Orders.Include("OrderDetails").SingleOrDefault(o => o.OrderId == orderId);
                if (order == null) return;
                db.OrderDetails.RemoveRange(order.Goods);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        //修改订单操作
        public static void ChangeOrder(Order order)
        {
            RemoveOrder(order.OrderId);
            orders.Add(order);
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
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, OrderService.orders);
            }
        }
        public static void Import(string filepath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                using (var db = new OrderingContext())
                {
                    List<Order> temp = (List<Order>)xmlSerializer.Deserialize(fs);
                    temp.ForEach(order => {
                        if (db.Orders.SingleOrDefault(o => o.OrderId == order.OrderId) == null)
                        {
                            
                            db.Orders.Add(order);
                        }
                    });
                    db.SaveChanges();
                }
            }
        }
    }
    
    }


