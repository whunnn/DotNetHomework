namespace Homework_8
{
    partial class Mainform
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChangeOrder = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cmbQueryWay = new System.Windows.Forms.ComboBox();
            this.btnExpert = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnQueryOrder = new System.Windows.Forms.Button();
            this.txbQuery = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.dgvOrderdetails = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.orderDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyerNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentWayDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCostDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.goodsNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderdetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnChangeOrder);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.cmbQueryWay);
            this.panel1.Controls.Add(this.btnExpert);
            this.panel1.Controls.Add(this.btnDeleteOrder);
            this.panel1.Controls.Add(this.btnAddOrder);
            this.panel1.Controls.Add(this.btnQueryOrder);
            this.panel1.Controls.Add(this.txbQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 126);
            this.panel1.TabIndex = 3;
            // 
            // btnChangeOrder
            // 
            this.btnChangeOrder.Location = new System.Drawing.Point(192, 76);
            this.btnChangeOrder.Name = "btnChangeOrder";
            this.btnChangeOrder.Size = new System.Drawing.Size(161, 40);
            this.btnChangeOrder.TabIndex = 7;
            this.btnChangeOrder.Text = "修改订单";
            this.btnChangeOrder.UseVisualStyleBackColor = true;
            this.btnChangeOrder.Click += new System.EventHandler(this.btnChangeOrder_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(737, 76);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(161, 40);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "导入订单";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cmbQueryWay
            // 
            this.cmbQueryWay.AllowDrop = true;
            this.cmbQueryWay.FormattingEnabled = true;
            this.cmbQueryWay.Items.AddRange(new object[] {
            "客户姓名",
            "订单号",
            "订单总花费",
            "支付方式",
            "订单包含商品"});
            this.cmbQueryWay.Location = new System.Drawing.Point(15, 26);
            this.cmbQueryWay.Name = "cmbQueryWay";
            this.cmbQueryWay.Size = new System.Drawing.Size(136, 23);
            this.cmbQueryWay.TabIndex = 5;
            // 
            // btnExpert
            // 
            this.btnExpert.Location = new System.Drawing.Point(553, 76);
            this.btnExpert.Name = "btnExpert";
            this.btnExpert.Size = new System.Drawing.Size(161, 40);
            this.btnExpert.TabIndex = 4;
            this.btnExpert.Text = "导出订单";
            this.btnExpert.UseVisualStyleBackColor = true;
            this.btnExpert.Click += new System.EventHandler(this.btnExpert_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(370, 76);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(161, 40);
            this.btnDeleteOrder.TabIndex = 3;
            this.btnDeleteOrder.Text = "删除订单";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(15, 76);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(161, 40);
            this.btnAddOrder.TabIndex = 2;
            this.btnAddOrder.Text = "添加订单";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnQueryOrder
            // 
            this.btnQueryOrder.Location = new System.Drawing.Point(370, 26);
            this.btnQueryOrder.Name = "btnQueryOrder";
            this.btnQueryOrder.Size = new System.Drawing.Size(129, 28);
            this.btnQueryOrder.TabIndex = 1;
            this.btnQueryOrder.Text = "查询订单";
            this.btnQueryOrder.UseVisualStyleBackColor = true;
            this.btnQueryOrder.Click += new System.EventHandler(this.btnQueryOrder_Click);
            // 
            // txbQuery
            // 
            this.txbQuery.Location = new System.Drawing.Point(157, 26);
            this.txbQuery.Name = "txbQuery";
            this.txbQuery.Size = new System.Drawing.Size(196, 25);
            this.txbQuery.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 126);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvOrder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvOrderdetails);
            this.splitContainer1.Size = new System.Drawing.Size(1259, 347);
            this.splitContainer1.SplitterDistance = 778;
            this.splitContainer1.TabIndex = 9;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AutoGenerateColumns = false;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdDataGridViewTextBoxColumn1,
            this.createTimeDataGridViewTextBoxColumn1,
            this.buyerNameDataGridViewTextBoxColumn1,
            this.paymentWayDataGridViewTextBoxColumn1,
            this.totalCostDataGridViewTextBoxColumn1,
            this.addressDataGridViewTextBoxColumn1});
            this.dgvOrder.DataSource = this.orderBindingSource;
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.RowTemplate.Height = 27;
            this.dgvOrder.Size = new System.Drawing.Size(778, 347);
            this.dgvOrder.TabIndex = 0;
            // 
            // dgvOrderdetails
            // 
            this.dgvOrderdetails.AllowUserToAddRows = false;
            this.dgvOrderdetails.AutoGenerateColumns = false;
            this.dgvOrderdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderdetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goodsNameDataGridViewTextBoxColumn,
            this.goodsPriceDataGridViewTextBoxColumn,
            this.goodsCountDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn});
            this.dgvOrderdetails.DataSource = this.orderDetailsBindingSource;
            this.dgvOrderdetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderdetails.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderdetails.Name = "dgvOrderdetails";
            this.dgvOrderdetails.RowHeadersWidth = 51;
            this.dgvOrderdetails.RowTemplate.Height = 27;
            this.dgvOrderdetails.Size = new System.Drawing.Size(477, 347);
            this.dgvOrderdetails.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // orderDetailsBindingSource
            // 
            this.orderDetailsBindingSource.DataMember = "Goods";
            this.orderDetailsBindingSource.DataSource = this.orderBindingSource;
            // 
            // orderIdDataGridViewTextBoxColumn1
            // 
            this.orderIdDataGridViewTextBoxColumn1.DataPropertyName = "OrderId";
            this.orderIdDataGridViewTextBoxColumn1.HeaderText = "订单号";
            this.orderIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.orderIdDataGridViewTextBoxColumn1.Name = "orderIdDataGridViewTextBoxColumn1";
            this.orderIdDataGridViewTextBoxColumn1.Width = 125;
            // 
            // createTimeDataGridViewTextBoxColumn1
            // 
            this.createTimeDataGridViewTextBoxColumn1.DataPropertyName = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn1.HeaderText = "下单时间";
            this.createTimeDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.createTimeDataGridViewTextBoxColumn1.Name = "createTimeDataGridViewTextBoxColumn1";
            this.createTimeDataGridViewTextBoxColumn1.Width = 125;
            // 
            // buyerNameDataGridViewTextBoxColumn1
            // 
            this.buyerNameDataGridViewTextBoxColumn1.DataPropertyName = "BuyerName";
            this.buyerNameDataGridViewTextBoxColumn1.HeaderText = "客户姓名";
            this.buyerNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.buyerNameDataGridViewTextBoxColumn1.Name = "buyerNameDataGridViewTextBoxColumn1";
            this.buyerNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // paymentWayDataGridViewTextBoxColumn1
            // 
            this.paymentWayDataGridViewTextBoxColumn1.DataPropertyName = "PaymentWay";
            this.paymentWayDataGridViewTextBoxColumn1.HeaderText = "支付方式";
            this.paymentWayDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.paymentWayDataGridViewTextBoxColumn1.Name = "paymentWayDataGridViewTextBoxColumn1";
            this.paymentWayDataGridViewTextBoxColumn1.Width = 125;
            // 
            // totalCostDataGridViewTextBoxColumn1
            // 
            this.totalCostDataGridViewTextBoxColumn1.DataPropertyName = "TotalCost";
            this.totalCostDataGridViewTextBoxColumn1.HeaderText = "总花费";
            this.totalCostDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.totalCostDataGridViewTextBoxColumn1.Name = "totalCostDataGridViewTextBoxColumn1";
            this.totalCostDataGridViewTextBoxColumn1.Width = 125;
            // 
            // addressDataGridViewTextBoxColumn1
            // 
            this.addressDataGridViewTextBoxColumn1.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn1.HeaderText = "收货地址";
            this.addressDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn1.Name = "addressDataGridViewTextBoxColumn1";
            this.addressDataGridViewTextBoxColumn1.Width = 125;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(Homework_8.Order);
            // 
            // goodsNameDataGridViewTextBoxColumn
            // 
            this.goodsNameDataGridViewTextBoxColumn.DataPropertyName = "GoodsName";
            this.goodsNameDataGridViewTextBoxColumn.HeaderText = "商品";
            this.goodsNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.goodsNameDataGridViewTextBoxColumn.Name = "goodsNameDataGridViewTextBoxColumn";
            this.goodsNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.goodsNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // goodsPriceDataGridViewTextBoxColumn
            // 
            this.goodsPriceDataGridViewTextBoxColumn.DataPropertyName = "GoodsPrice";
            this.goodsPriceDataGridViewTextBoxColumn.HeaderText = "单价";
            this.goodsPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.goodsPriceDataGridViewTextBoxColumn.Name = "goodsPriceDataGridViewTextBoxColumn";
            this.goodsPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.goodsPriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // goodsCountDataGridViewTextBoxColumn
            // 
            this.goodsCountDataGridViewTextBoxColumn.DataPropertyName = "GoodsCount";
            this.goodsCountDataGridViewTextBoxColumn.HeaderText = "数量";
            this.goodsCountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.goodsCountDataGridViewTextBoxColumn.Name = "goodsCountDataGridViewTextBoxColumn";
            this.goodsCountDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "总价";
            this.totalPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            this.totalPriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(514, 26);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 28);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 473);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "Mainform";
            this.Text = "订单管理系统";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderdetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnQueryOrder;
        private System.Windows.Forms.TextBox txbQuery;
        private System.Windows.Forms.Button btnExpert;
        private System.Windows.Forms.ComboBox cmbQueryWay;
        private System.Windows.Forms.BindingSource orderDetailsBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.DataGridView dgvOrderdetails;
        private System.Windows.Forms.Button btnChangeOrder;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyerNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentWayDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCostDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBack;
    }
}

