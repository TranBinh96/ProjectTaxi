using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTaxi.DAL
{
    class ViewDoanhThuDAL
    {
        static SqlConnection connection = new SqlConnection(DBConnection.DbConn);
        public DataTable SelectData()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "select  * from  doanh_thu_tung_ngay";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();

            }


            return table;
        }

    }
}
