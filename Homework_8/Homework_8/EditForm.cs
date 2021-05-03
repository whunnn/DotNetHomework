using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_8
{
    public partial class EditForm : Form
    {
        private OrderService orderService;
        private bool ifEdit;
        private Order currentOrder;
        public EditForm(Order order,bool ifEdit,ref OrderService orderService)
        {
            InitializeComponent();
            this.orderService = orderService;
            this.ifEdit = ifEdit;
            this.currentOrder = order;
            bdsOrders.DataSource = currentOrder;
            lblCreateTime.DataBindings.Add("Text", this.currentOrder, "CreateTime");
            txbOrderId.DataBindings.Add("Text", this.currentOrder, "OrderId");
            txbBuyerName.DataBindings.Add("Text", this.currentOrder, "BuyerName");
            txbAddress.DataBindings.Add("Text", this.currentOrder, "Address");
            txbPaymentWay.DataBindings.Add("Text", this.currentOrder, "PaymentWay");
            if (ifEdit) txbOrderId.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DetailForm detailForm = new DetailForm(new OrderDetails());
                if (detailForm.ShowDialog() == DialogResult.OK)
                {                   
                    currentOrder.AddGoods(detailForm.orderDetails);
                    bdsOrderDetails.ResetBindings(false);
                }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OrderDetails detail = bdsOrderDetails.Current as OrderDetails;
            if (detail == null)
            {
                MessageBox.Show("请选择一个明细项进行修改");
                return;
            }
            DetailForm detailForm = new DetailForm(detail);
            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                currentOrder.Goods.Remove(detail);
                currentOrder.Goods.Add(detailForm.orderDetails);
                bdsOrderDetails.ResetBindings(false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OrderDetails detail = bdsOrderDetails.Current as OrderDetails;
            if (detail == null)
            {
                MessageBox.Show("请选择一个明细项进行删除");
                return;
            }
            currentOrder.Goods.Remove(detail);
            bdsOrderDetails.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ifEdit){
                    OrderService.ChangeOrder(currentOrder);
                }
                else{
                    OrderService.AddOrder(currentOrder);
                }
                this.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}
