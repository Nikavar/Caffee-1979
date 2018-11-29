using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caffee;

namespace UI
{
    public partial class Form1 : Form
    {
        //public event EventHandler<DataGridView> RemoveSelectedProduct;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initializeProductsToUi();
        }

        public void initializeProductsToUi()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in DB.GetAllProducts())
            {
                Button button = new Button(item);

                button.ButtonClick += Button_ButtonClick;
                button.DeleteProduct += Button_DeleteProduct;
                button.UpdateProduct += Button_UpdateProduct;
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void Button_UpdateProduct(object sender, EventArgs e)
        {            
            initializeProductsToUi();
        }

        private void Button_DeleteProduct(object sender, Product e)
        {
            DB.Remove(e);
            initializeProductsToUi();
        }

        Order o = new Order();

        private void Button_ButtonClick(object sender, Product e)
        {
            List<OrderItem> list = o.CompliteSellingList(e);
            SumLBL.Text = $"Sum: " + o.CalculateTotalPrice().ToString() + $" ₾";

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RemoveBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            var SelectedRow = dataGridView1.SelectedRows[0]?.DataBoundItem as OrderItem;

            if (SelectedRow == null)
                return;
            
            o.Remove(SelectedRow);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = o.SellingList;
            SumLBL.Text = $"Sum: " + o.CalculateTotalPrice().ToString() + $" ₾";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(o.SellingList.Count != 0)
            {
                DataGridView OrderView = new DataGridView();
                OrderView = dataGridView1;

                Calculator calc = new Calculator(SumLBL.Text, o.SellingList);
                calc.ShowDialog();
            }

            else
            {
                MessageBox.Show("Your order list is empty", "Warning");
            }
        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            AddProduct AddProduct = new AddProduct();
            var result =AddProduct.ShowDialog();

            if (result == DialogResult.OK) {
                flowLayoutPanel1.Controls.Clear();

                initializeProductsToUi();
            }
            //this.Close();
        }
    }
}
