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
    public partial class CategoriesControl2 : UserControl
    {
        int categoryID = 0;
        public CategoriesControl2()
        {
            InitializeComponent();
            categoryDataGridView1.AllowUserToAddRows = false;
            categoryDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            categoryDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            categoryDataGridView1.ReadOnly = true;
            categoryDataGridView1.RowHeadersVisible = false;
            categoryDataGridView1.MultiSelect = false;
            categoryDataGridView1.ForeColor = System.Drawing.Color.Black;
        }
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (txtL.Text != "" && txtS.Text != "")
            {
                SqlConnection con = new SqlConnection(GetConnection());
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Categories values (@ShortName, @LongName)", con);
                cmd.Parameters.AddWithValue("ShortName", txtS.Text);
                cmd.Parameters.AddWithValue("LongName", txtL.Text);
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
            txtL.Text = "";
            txtS.Text = "";
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAllField();
        }
        private void BindDataToDataView()
        {
            SqlConnection con = new SqlConnection(GetConnection());
            con.Open();
            SqlDataAdapter dst = new SqlDataAdapter("Select * from Categories;", con);
            DataTable dataSet = new DataTable();
            dst.Fill(dataSet);
            categoryDataGridView1.DataSource = dataSet;
            con.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BindDataToDataView();
            ClearAllField();
        }

        private void DataGridView1_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            categoryDataGridView1.ClearSelection();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            categoryID = int.Parse(categoryDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtS.Text = categoryDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtL.Text = categoryDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (categoryDataGridView1.SelectedRows.Count != 0 && categoryID != 0)
            {
                SqlConnection con = new SqlConnection(GetConnection());
                SqlCommand cmd = new SqlCommand("UPDATE Categories SET ShortName = @ShortName, LongName = @LongName Where CategoryID = @CategoryID", con);
                cmd.Parameters.AddWithValue("CategoryID", categoryID);
                cmd.Parameters.AddWithValue("ShortName", txtS.Text);
                cmd.Parameters.AddWithValue("LongName", txtL.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                BindDataToDataView();
                ClearAllField();
            }
            else
            {
                MessageBox.Show("Please Select a row!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (categoryDataGridView1.SelectedRows.Count != 0 && categoryID != 0)
            {
                SqlConnection con = new SqlConnection(GetConnection());
                SqlCommand cmd = new SqlCommand("DELETE Categories Where CategoryID = @CategoryID", con);
                cmd.Parameters.AddWithValue("CategoryID", categoryID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ClearAllField();
                BindDataToDataView();
            }
            else
            {
                MessageBox.Show("Please Select a row!");
            }
        }
        private void CategoryDataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            categoryDataGridView1.ClearSelection();
        }
    }
}
