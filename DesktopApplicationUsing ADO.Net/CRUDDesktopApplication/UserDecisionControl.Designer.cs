namespace CRUDDesktopApplication
{
    partial class UserDecisionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.productTableData1 = new CRUDDesktopApplication.ProductTableData();
            this.categoriesControl21 = new CRUDDesktopApplication.CategoriesControl2();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "CRUD Operation on Product Table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(394, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "CRUD Operation on Categories Table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.productTableData1);
            this.panel1.Location = new System.Drawing.Point(22, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 389);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(-10, -22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 373);
            this.panel2.TabIndex = 3;
            // 
            // productTableData1
            // 
            this.productTableData1.Location = new System.Drawing.Point(-10, -37);
            this.productTableData1.Name = "productTableData1";
            this.productTableData1.Size = new System.Drawing.Size(894, 413);
            this.productTableData1.TabIndex = 2;
            // 
            // categoriesControl21
            // 
            this.categoriesControl21.Location = new System.Drawing.Point(0, 0);
            this.categoriesControl21.Name = "categoriesControl21";
            this.categoriesControl21.Size = new System.Drawing.Size(893, 408);
            this.categoriesControl21.TabIndex = 2;
            // 
            // UserDecisionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.categoriesControl21);
            this.Name = "UserDecisionControl";
            this.Size = new System.Drawing.Size(893, 411);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private ProductTableData productTableData1;
        private System.Windows.Forms.Panel panel2;
        private CategoriesControl2 categoriesControl21;
    }
}
