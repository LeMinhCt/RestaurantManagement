﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Model;
namespace GUI
{
    public partial class frmTableDetail : Form
    {
        OrderFoodBUS orderFoodBUS = new OrderFoodBUS();
        TableBUS tableBUS = new TableBUS();
        Customer customer = new Customer();
        FoodBUS foodBUS = new FoodBUS();
        CustomerBUS customerBUS = new CustomerBUS();
        frmTable form = new frmTable();
        OrderBUS orderBUS = new OrderBUS();
        public int indexRow;
        public frmTableDetail()
        {
            InitializeComponent(); 
            loadOrderItems();
            lblTableIDdata.Text = btnTable.tableName;
            orderBUS.insertOrders(Convert.ToInt32(btnTable.tableName));
            loadStatus();
            loadFoodName();
        }
        public bool SaveCustomers()
        {
            customer.Name = txtNameCustomer.Text;
            customer.PhoneNumber = txtPhoneNumber.Text ;
            customer.Point = calPoint();
            if(customer.Name == "" || customer.PhoneNumber == "")
            {
                return false;
            }
            return true;

        }
        public int calPoint()
        {
            int total = 0;
            int point = 0;
            for (int i = 0; i < dtgvOrderItems.Rows.Count - 1; i++)
            {
                total = total + Convert.ToInt32( dtgvOrderItems.Rows[i].Cells[2].Value.ToString());
            }
            point =Convert.ToInt32( Math.Round((1.0 * total) / 10000));
            
            return point;
        }
        public void loadStatus()
        {
            int status = tableBUS.getStatus(btnTable.tableName);
            if(status == 0)
            {
                cbcStatus.SelectedIndex = cbcStatus.FindStringExact("Trống");
            }
            else if(status == 1)
            {
                cbcStatus.SelectedIndex = cbcStatus.FindStringExact("Đặt bàn");
            }
            else if (status == 2)
            {
                cbcStatus.SelectedIndex = cbcStatus.FindStringExact("Đang dùng");
            }

        }
        public void loadOrderItems()
        {
            this.dtgvOrderItems.DataSource = orderFoodBUS.getOrderItems(Convert.ToInt32(btnTable.tableName));
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread thread = new Thread(OpenFrmLogin);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            new frmCheckout().ShowDialog();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        void OpenFrmLogin(object obj)
        {
            Application.Run(new frmLogin());
        }
        void OpenFrmCheckout(object obj)
        {
            Application.Run(new frmCheckout());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread thread = new Thread(OpenFrmTable);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }
        void OpenFrmTable(object obj)
        {
            frmTable form = new frmTable();
            Application.Run(form);
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread thread = new Thread(OpenFrmTable);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            
        }

        private void pnlSetting_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!SaveCustomers())
            {
                tableBUS.updateStatus(cbcStatus.Text, btnTable.tableName);
                MessageBox.Show("Lưu thành công");
                return;
            }
            if (this.dtgvOrderItems.Rows.Count <= 1)
            {
                MessageBox.Show("Bàn chưa có thức ăn");
                return;
            }
            if (customerBUS.isOldCustomer(customer) == 1)
            {
                customerBUS.updateCustomerPoint(customer);
                tableBUS.updateStatus(cbcStatus.Text, btnTable.tableName);
                MessageBox.Show("Lưu thành công");
            }
            else if(customerBUS.isOldCustomer(customer) == 2)
            {
                MessageBox.Show("Số điện thoại đã tồn tại");
                return;
            }
            else
            {
                customerBUS.insertCustomers(customer);
                tableBUS.updateStatus(cbcStatus.Text, btnTable.tableName);
                MessageBox.Show("Lưu thành công");
            }

            
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvOrderItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvOrderItems.Rows[e.RowIndex];
                try
                {
                    cbcFoodName.Text = row.Cells[0].Value.ToString();
                    nudQuantity.Value = Convert.ToInt32(row.Cells[1].Value);
                }
                catch
                {
                    return;
                }

            }

        }
        public void loadFoodName()
        {
            DataTable data = foodBUS.getFoods();
            for(int i = 0; i < data.Rows.Count; i++)
            {
                cbcFoodName.Items.Add(data.Rows[i]["Tên món"].ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
