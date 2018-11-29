namespace UI
{
    partial class AddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductTXT = new System.Windows.Forms.TextBox();
            this.PriceTXT = new System.Windows.Forms.TextBox();
            this.AddProductBTN = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Price:";
            // 
            // ProductTXT
            // 
            this.ProductTXT.Location = new System.Drawing.Point(123, 25);
            this.ProductTXT.Name = "ProductTXT";
            this.ProductTXT.Size = new System.Drawing.Size(152, 20);
            this.ProductTXT.TabIndex = 0;
            // 
            // PriceTXT
            // 
            this.PriceTXT.Location = new System.Drawing.Point(123, 60);
            this.PriceTXT.Name = "PriceTXT";
            this.PriceTXT.Size = new System.Drawing.Size(152, 20);
            this.PriceTXT.TabIndex = 1;
            this.PriceTXT.TextChanged += new System.EventHandler(this.PriceTXT_TextChanged);
            // 
            // AddProductBTN
            // 
            this.AddProductBTN.Location = new System.Drawing.Point(123, 127);
            this.AddProductBTN.Name = "AddProductBTN";
            this.AddProductBTN.Size = new System.Drawing.Size(152, 20);
            this.AddProductBTN.TabIndex = 2;
            this.AddProductBTN.Text = "Add New Product";
            this.AddProductBTN.UseVisualStyleBackColor = true;
            this.AddProductBTN.Click += new System.EventHandler(this.AddProductBTN_Click);
            this.AddProductBTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterBTN_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(25, 169);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(50, 13);
            this.lblWarning.TabIndex = 3;
            this.lblWarning.Text = "Warning:";
            this.lblWarning.Visible = false;
            // 
            // AddProduct
            // 
            this.AcceptButton = this.AddProductBTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 194);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.AddProductBTN);
            this.Controls.Add(this.PriceTXT);
            this.Controls.Add(this.ProductTXT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddProduct";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterBTN_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ProductTXT;
        private System.Windows.Forms.TextBox PriceTXT;
        private System.Windows.Forms.Button AddProductBTN;
        private System.Windows.Forms.Label lblWarning;
    }
}