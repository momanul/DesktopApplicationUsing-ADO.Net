using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CRUDDesktopApplication
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ForeColor = System.Drawing.Color.Black;

        }
        //private void BtnInsert_Click(object sender, EventArgs e)
        //{
        //    if (txtProductID.Text != "" && txtName.Text != ""
        //        && txtLongName.Text != "" && txtLongDescription.Text != ""
        //        && txtCategoryID.Text != "" && txtShortDescription.Text != ""
        //        && txtShortName.Text != "" && txtUnitPrice.Text != "")
        //    {
        //        SqlConnection con = new SqlConnection(GetConnection());
        //        SqlCommand cmd = new SqlCommand("Insert into Products values (@ProductID, @Name," +
        //            " @ShortDescription, @LongDescription, @CategoryID, @UnitPrice)", con);
        //        cmd.Parameters.AddWithValue("ProductID", txtProductID.Text);
        //        cmd.Parameters.AddWithValue("Name", txtName.Text);
        //        cmd.Parameters.AddWithValue("ShortDescription", txtShortDescription.Text);
        //        cmd.Parameters.AddWithValue("LongDescription", txtLongDescription.Text);
        //        cmd.Parameters.AddWithValue("CategoryID", txtCategoryID.Text);
        //        cmd.Parameters.AddWithValue("UnitPrice", txtUnitPrice.Text);

        //        con.Open();
        //        cmd.ExecuteNonQuery();

        //        cmd = new SqlCommand("Insert into Categories values (@CategoryID, @ShortName, @LongName)", con);
        //        cmd.Parameters.AddWithValue("CategoryID", txtCategoryID.Text);
        //        cmd.Parameters.AddWithValue("ShortName", txtShortName.Text);
        //        cmd.Parameters.AddWithValue("LongName", txtLongName.Text);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        ClearAllField();
        //        BindDataToDataView();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please Fill up All The Field!");
        //    }
        //}

        //private void BtnUpdate_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count != 0 && txtProductID.Text != "")
        //    {
        //        SqlConnection con = new SqlConnection(GetConnection());
        //        SqlCommand cmd = new SqlCommand("UPDATE Products SET Name = @Name, ShortDescription = @ShortDescription, " +
        //            "LongDescription = @LongDescription, UnitPrice = @UnitPrice"
        //          + "  Where ProductID = @ProductID", con);
        //        cmd.Parameters.AddWithValue("Name", txtName.Text);
        //        cmd.Parameters.AddWithValue("ShortDescription", txtShortDescription.Text);
        //        cmd.Parameters.AddWithValue("LongDescription", txtLongDescription.Text);
        //        cmd.Parameters.AddWithValue("UnitPrice", txtUnitPrice.Text);
        //        cmd.Parameters.AddWithValue("ProductID", txtProductID.Text);

        //        con.Open();
        //        cmd.ExecuteNonQuery();

        //        cmd = new SqlCommand("UPDATE Categories SET ShortName = @ShortName, LongName = @LongName Where CategoryID = @CategoryID", con);
        //        cmd.Parameters.AddWithValue("CategoryID", txtCategoryID.Text);
        //        cmd.Parameters.AddWithValue("ShortName", txtShortName.Text);
        //        cmd.Parameters.AddWithValue("LongName", txtLongName.Text);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        BindDataToDataView();
        //        ClearAllField();
        //        txtProductID.ReadOnly = false;
        //        txtCategoryID.ReadOnly = false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please Select a row!");
        //    }
        //}

        //private void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count != 0 && txtProductID.Text != "")
        //    {
        //        SqlConnection con = new SqlConnection(GetConnection());
        //        SqlCommand cmd = new SqlCommand("DELETE Products Where ProductID = @ProductID", con);
        //        cmd.Parameters.AddWithValue("ProductID", txtProductID.Text);

        //        con.Open();
        //        cmd.ExecuteNonQuery();

        //        cmd = new SqlCommand("DELETE Categories Where CategoryID = @CategoryID", con);
        //        cmd.Parameters.AddWithValue("CategoryID", txtCategoryID.Text);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        ClearAllField();
        //        BindDataToDataView();
        //        txtProductID.ReadOnly = false;
        //        txtCategoryID.ReadOnly = false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please Select a row!");
        //    }
        //}
        public string GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;
            return cs;
        }
        //public void ClearAllField()
        //{
        //    txtCategoryID.Text = "";
        //    txtLongDescription.Text = "";
        //    txtLongName.Text = "";
        //    txtName.Text = "";
        //    txtProductID.Text = "";
        //    txtShortDescription.Text = "";
        //    txtShortName.Text = "";
        //    txtUnitPrice.Text = "";
        //    txtProductID.ReadOnly = false;
        //    txtCategoryID.ReadOnly = false;
        //}

        //private void BtnClear_Click(object sender, EventArgs e)
        //{
        //    ClearAllField();
        //}
        private void BindDataToDataView()
        {
            SqlConnection con = new SqlConnection(GetConnection());
            con.Open();
            SqlDataAdapter dst = new SqlDataAdapter("select ProductID, Name, ShortDescription, LongDescription, " +
                "UnitPrice, Categories.CategoryID, ShortName, LongName from Products " +
                  "join Categories on Products.CategoryID = Categories.CategoryID", con);
            DataTable dataSet = new DataTable();
            dst.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
            con.Close();
        }

        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    BindDataToDataView();
        //}

        private void DataGridView1_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BindDataToDataView();
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        //private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    txtProductID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        //    txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //    txtShortDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //    txtLongDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        //    txtCategoryID.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        //    txtUnitPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        //    txtShortName.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        //    txtLongName.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        //    txtCategoryID.ReadOnly = true;
        //    txtProductID.ReadOnly = true;
        //}
    }
}
