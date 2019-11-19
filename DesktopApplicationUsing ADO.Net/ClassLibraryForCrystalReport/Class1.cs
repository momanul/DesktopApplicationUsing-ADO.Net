using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForCrystalReport
{
    public class Class1
    {
        public DataSet BindData()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            DataSet table = new DataSet();
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter(@"Select ProductID, Name, ShortName, LongName, ShortDescription, 
                                   LongDescription, Products.CategoryID, UnitPrice from Products
                                   full join Categories on Categories.CategoryID = Products.CategoryID; ", con);
            cmd.Fill(table, "ProductCategory");
            return table;
        }
    }
}
