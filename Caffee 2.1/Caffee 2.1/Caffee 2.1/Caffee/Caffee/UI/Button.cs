using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caffee;

namespace UI
{
    public partial class Button : UserControl
    {
        public event EventHandler<Product> ButtonClick;
        public event EventHandler<Product> DeleteProduct;
        public event EventHandler UpdateProduct;

        public Product MyProduct { get; set; }

        public Button()
        {
            InitializeComponent();
        }

        public Button(Product p):this()
        {
            button1.Text = p.ProductName;
            label.Text = p.Price.ToString() + "₾";
            MyProduct = p;
        }

        private void Button_Load(object sender, EventArgs e)
        {
            //button1.Text = product.ProductName;
            //label.Text = product.Price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this, MyProduct);
        }

        private void contextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void context(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DB.Remove(MyProduct);
            DeleteProduct?.Invoke(this,MyProduct);
        }

        private void Button1_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProduct p = new AddProduct(MyProduct);
            p.ShowDialog();
            UpdateProduct?.Invoke(this, EventArgs.Empty);
            //button1.BackColor = Color.Aqua;

        }
    }
}
