using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GearVN
{
    class ConnectDB
    {
        string str_con = "Data Source=NGUYENTHANHDAT\\SQLEXPRESS;Initial Catalog=GearVN;User ID=sa;Password=123456";
        SqlConnection conn = null;

        public ConnectDB()
        {
            conn = new SqlConnection(str_con);
        }

        public DataSet getData(string query, string tb_table, List<SqlParameter> data)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (data != null)
                {
                    da.SelectCommand.Parameters.AddRange(data.ToArray());
                }
                da.Fill(ds, tb_table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return ds;
        }
        public void execute(string query, List<SqlParameter> data)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (data != null)
                {
                    cmd.Parameters.AddRange(data.ToArray());
                }
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
