using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_8
{
    public partial class Mainform : Form
    {
        OrderService OrderService = new OrderService();

        public Mainform()
        {
            InitializeComponent();
            Goods goods1 = new Goods("basketball", 100);
            Goods goods2 = new Goods("football", 150);
            Goods goods3 = new Goods("volleyball", 50);
            Goods goods4 = new Goods("baseball", 30);
            Goods goods5 = new Goods("shoes", 200);
            Goods goods6 = new Goods("T-short", 80);
            OrderDetails item1 = new OrderDetails(goods1, 1);
            OrderDetails item2 = new OrderDetails(goods2, 2);
            OrderDetails item3 = new OrderDetails(goods3, 3);
            Order order1 = new Order(1, "小明", "address1", "WechatPay", new List<OrderDetails> { item1, item3 });
            Order order2 = new Order(2, "小红", "address2", "WechatPay", new List<OrderDetails> { item2 });
            Order order3 = new Order(3, "小刚", "address3", "Alipay", new List<OrderDetails> { item2, item3 });
            OrderService.AddOrder(order1);
            OrderService.AddOrder(order2);
            OrderService.AddOrder(order3);
            orderBindingSource.DataSource = OrderService.orders;

        }

        private void btnQueryOrder_Click(object sender, EventArgs e)
        {
            if (txbQuery.Text != null)
            {
                /*客户姓名
                订单号
                订单总花费
                支付方式
                订单包含商品 */
                switch (cmbQueryWay.SelectedIndex)
                {
                    case 0:
                        orderBindingSource.DataSource = OrderService.SelectByBuyerName(txbQuery.Text);
                        break;
                    case 1:
                        if (int.TryParse(txbQuery.Text, out int id))
                            orderBindingSource.DataSource = OrderService.SelectByOrderId(id);
                        else MessageBox.Show("请输入正确的订单号格式");
                        break;
                    case 2:
                        if (int.TryParse(txbQuery.Text, out int cost))
                            orderBindingSource.DataSource = OrderService.SelectByTotalCost(cost);
                        else MessageBox.Show("请输入正确的总花费格式");
                        break;
                    case 3:
                        orderBindingSource.DataSource = OrderService.SelectByPaymentWay(txbQuery.Text);
                        break;
                    case 4:
                        orderBindingSource.DataSource = OrderService.SelectByGoodsName(txbQuery.Text);
                        break;
                }
            }
            else orderBindingSource.DataSource = OrderService.orders;

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(new Order(), false, ref OrderService);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                OrderService.Sort();
                orderBindingSource.ResetBindings(false);
            }
        }

        private void btnChangeOrder_Click(object sender, EventArgs e)
        {
            Order order = orderBindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            EditForm editForm = new EditForm(order, true, ref OrderService);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                OrderService.Sort();
                orderBindingSource.ResetBindings(false);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            Order order = orderBindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            OrderService.RemoveOrder(order.OrderId);
            OrderService.Sort();
            orderBindingSource.ResetBindings(false);
        }

        private void btnExpert_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                OrderService.Export(fileName);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                OrderService.Import(fileName);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = OrderService.orders;
            orderBindingSource.ResetBindings(false);
        }
    }
}
