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
    public partial class DetailForm : Form
    {
        public OrderDetails orderDetails;
        public DetailForm(OrderDetails orderDetails)
        {
            InitializeComponent();
            this.orderDetails = orderDetails;
            bdsDetails.DataSource = orderDetails;
            cmbGoods.DataSource = new List<Goods>{
                 new Goods("basketball", 100),
                 new Goods("football", 150),
                 new Goods("volleyball", 50),
                 new Goods("baseball", 30),
                 new Goods("shoes", 200),
                 new Goods("T-short", 80)
            };
            cmbGoods.DisplayMember = "Name";
            cmbGoods.DataBindings.Add("SelectedItem",this.orderDetails,"GoodsItem");
            cmbGoods.SelectedIndex = 0;
            numbCount.DataBindings.Add("Value", this.orderDetails, "GoodsCount");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
