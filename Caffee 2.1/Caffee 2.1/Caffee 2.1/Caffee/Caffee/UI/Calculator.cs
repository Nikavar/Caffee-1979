using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZavackoiButton = System.Windows.Forms.Button;
using Caffee;

namespace UI
{
    public partial class Calculator : Form
    {
        List<OrderItem> List;
        public double ClientAmount;
        public double Changes;
        public double Sum;

        public Calculator(string sum, List<OrderItem> OrderItemList)
        {
            InitializeComponent();
            lblSum.Text = sum.All(char.IsLetter) ? "" : sum;
            sum = new string(sum.Where(x => char.IsDigit(x)).ToArray());
            Sum = Convert.ToDouble(sum);
            List = OrderItemList;
        }

        int count = 0;

        public decimal Total { get; set; } = 0;

        protected void btn_Click(object sender, EventArgs e)
        {
            ZavackoiButton btn = sender as ZavackoiButton;

            if(count == 0)
            {
                if (btn.Text[0].ToString() == ".")
                    return;

                Total *= Convert.ToDecimal(Math.Pow(10, count));
            }

            else
            {
                if (Total == 0 && btn.Text == "0")
                    return;

                //Total *= Convert.ToDecimal(10);


                //if (count == 1 && (btn.Text == "." || btn.Text == ","))
                //    Total = Total / 10;
                
            }

            if(txtAmount.Text.Contains(".") && btn.Text == ".")
            {
                return;
            }

            Total = btn.Text.Contains(".") ? Total *= Convert.ToDecimal(0.1) : Total *= Convert.ToDecimal(10);

            if(btn.Text != ".")
            {
                Total += txtAmount.Text.Contains(".")? Convert.ToDecimal(btn.Text)*Convert.ToDecimal(0.1) : Convert.ToDecimal(btn.Text);
            }
            count++; 
            
            txtAmount.Text = $"{Total.ToString()}";

        }

        public double CalculateChanges(string ClientMoney)
        {
            ClientAmount = String.IsNullOrEmpty(ClientMoney) ? 0 : Convert.ToDouble(txtAmount.Text);

            Changes = ClientAmount - Sum;

            if (ClientAmount < Sum)
                lblChange.ForeColor = Color.Red;

            else
            {
                lblChange.ForeColor = Color.Black;
            }

            return Changes;
        }

        private void button9_Click(object sender, EventArgs e)
        {
           // Total += Convert.ToDouble((sender as Button).Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // Total += Convert.ToInt32(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Total += Convert.ToInt32(e);
        }

        private void RemoveBTN_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text == String.Empty)
                return;

            txtAmount.Text = txtAmount.Text.Substring(0, txtAmount.Text.Length - 1);
            Total = txtAmount.Text != String.Empty ? Convert.ToDecimal(txtAmount.Text) : 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Total += Convert.ToInt32(e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
           //Total += Convert.ToInt32(e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Total += Convert.ToInt32(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Total += Convert.ToInt32(e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Total += Convert.ToInt32(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // Total += Convert.ToInt32(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Total += Convert.ToInt32(e);
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            lblChange.Text = String.IsNullOrEmpty(txtAmount.Text) ? "" : "Change: " + CalculateChanges(txtAmount.Text).ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAmount.Text))
                MessageBox.Show("თანხის ველი ცარიელია", "გაფრთხილება");

            if (Changes < 0)
                MessageBox.Show("კლიენტის თანხა ნაკლებია შეკვეთის თანხასთან შედარებით", "გაფრთხილება");

            DBLite db = new DBLite();
            db.AddOrder(List);
        }
    }
}
