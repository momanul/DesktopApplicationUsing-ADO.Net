using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUDDesktopApplication
{
    public partial class ProductTableData : UserControl
    {
        int productID = 0;
        public ProductTableData()
        {
            InitializeComponent();
            productDataGridView1.AllowUserToAddRows = false;
            productDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productDataGridView1.ReadOnly = true;
            productDataGridView1.RowHeadersVisible = false;
            productDataGridView1.MultiSelect = false;
            productDataGridView1.ForeColor = System.Drawing.Color.Black;
        }
        public void BindDataToDataVieww()
        {
            SqlConnection con = new SqlConnection(GetConnection());
            con.Open();
            SqlDataAdapter dst = new SqlDataAdapter("Select * from Categories;", con);
            DataTable dataSet = new DataTable();
            dst.Fill(dataSet);
            comboBox1.DataSource = dataSet;
            con.Close();
        }
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != ""
                && txtShortDescription.Text != "" && txtLongDescription.Text != "" && txtUnitPrice.Text != "")
            {
                SqlConnection con = new SqlConnection(GetConnection());
                SqlCommand cmd = new SqlCommand("Insert into Products values (@Name," +
                    " @ShortDescription, @LongDescription, @CategoryID, @UnitPrice)", con);
                cmd.Parameters.AddWithValue("Name", txtName.Text);
                cmd.Parameters.AddWithValue("ShortDescription", txtShortDescription.Text);
                cmd.Parameters.AddWithValue("LongDescription", txtLongDescription.Text);
                cmd.Parameters.AddWithValue("CategoryID", comboBox1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("UnitPrice", txtUnitPrice.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                BindDataToDataView();
                ClearAllField();
            }
            else
            {
                MessageBox.Show("Please Fill up All The Field!");
            }
        }
        public string GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;
            return cs;
        }
        public void ClearAllField()
        {
            comboBox1.Text = "";
            txtName.Text = "";
            txtShortDescription.Text = "";
            txtLongDescription.Text = "";
            txtUnitPrice.Text = "";
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllField();
        }
        private void BindDataToDataView()
        {
            SqlConnection con = new SqlConnection(GetConnection());
            con.Open();
            SqlDataAdapter dst = new SqlDataAdapter("Select ProductID, Name, ShortDescription, LongDescription, CategoryID, UnitPrice from Products;", con);
            DataTable dataSet = new DataTable();
            dst.Fill(dataSet);
            productDataGridView1.DataSource = dataSet;
            con.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BindDataToDataView();
            ClearAllField();
            comboBox1.Enabled = true;
        }

        private void DataGridView1_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            productDataGridView1.ClearSelection();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            productID = int.Parse(productDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = productDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtShortDescription.Text = productDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtLongDescription.Text = productDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox1.Text = productDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtUnitPrice.Text = productDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox1.Enabled = false;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (productDataGridView1.SelectedRows.Count != 0 && productID != 0)
            {
                SqlConnection con = new SqlConnection(GetConnection());
                SqlCommand cmd = new SqlCommand("UPDATE Products SET Name = @Name, ShortDescription = @ShortDescription, " +
                    "LongDescription = @LongDescription, UnitPrice = @UnitPrice"
                  + "  Where ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("Name", txtName.Text);
                cmd.Parameters.AddWithValue("ShortDescription", txtShortDescription.Text);
                cmd.Parameters.AddWithValue("LongDescription", txtLongDescription.Text);
                cmd.Parameters.AddWithValue("UnitPrice", txtUnitPrice.Text);
                cmd.Parameters.AddWithValue("ProductID", productID);

                con.Open();
                cmd.ExecuteNonQuery();
                BindDataToDataView();
                ClearAllField();
                comboBox1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please Select a row!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (productDataGridView1.SelectedRows.Count != 0 && productID != 0)
            {
                SqlConnection con = new SqlConnection(GetConnection());
                SqlCommand cmd = new SqlCommand("DELETE Products Where ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("ProductID", productID);

                con.Open();
                cmd.ExecuteNonQuery();
                ClearAllField();
                BindDataToDataView();
                comboBox1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please Select a row!");
            }
        }

        private void FillByToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void ProductDataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            productDataGridView1.ClearSelection();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            BindDataToDataVieww();
        }
    }
}
