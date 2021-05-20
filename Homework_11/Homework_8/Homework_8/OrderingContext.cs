using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    class OrderingContext : DbContext
    {
        public OrderingContext() : base("OrdersDatabase") 
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<OrderingContext>());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Goods> Goods { get; set; }
    }
}
