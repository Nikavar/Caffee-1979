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
    public partial class AddProduct : Form
    {
        private Product NewProduct;

        public AddProduct()
        {
            InitializeComponent();            
        }

        public AddProduct(Product p):this()
        {
            PriceTXT.Text = p.Price.ToString();
            ProductTXT.Text = p.ProductName;
            AddProductBTN.Text = "Update Product";
            NewProduct = p;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EnterBTN_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddProductBTN_Click(this,e);
            }
        }

        private void AddProductBTN_Click(object sender, EventArgs e)
        {
            double result;

            if(!(double.TryParse(PriceTXT.Text, out result)))
            {
                lblWarning.Text = "Enter a valid Value!";
                lblWarning.Visible = true;
                return;
            }


            if(NewProduct != null)
            {
                NewProduct = new Product { ID = NewProduct.ID, Price = Convert.ToDouble(PriceTXT.Text), ProductName = ProductTXT.Text };
                DB.Update(NewProduct);            }

            else
            {
                NewProduct = new Product();
                NewProduct.ProductName = ProductTXT.Text.Trim();
                NewProduct.Price = Convert.ToDouble(PriceTXT.Text.Trim());

                DBLite db = new DBLite();
                db.Add(NewProduct);
            }           

            this.DialogResult = DialogResult.OK;      
        }

        private void PriceTXT_TextChanged(object sender, EventArgs e)
        {
            lblWarning.Visible = false;
        }
    }
}
