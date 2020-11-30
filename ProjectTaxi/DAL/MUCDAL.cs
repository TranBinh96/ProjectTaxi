using ProjectTaxi.BLL;
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
    class MUCDAL
    {
        SqlConnection connection = new SqlConnection(DBConnection.DbConn);


        #region Select Data
        public DataTable SelectData()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "select  * from  HAI_MUC";
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
        #endregion


        #region InsertData
        public bool InsertData(MucBLL MUC)
        {
            try
            {
                string sql = "insert into  HAI_MUC(ID_MUC,MUC, THUONG)  values (@ID_MUC,@MUC,@THUONG)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_MUC", MUC.ID_MUC);
                command.Parameters.AddWithValue("@MUC", MUC.MUC);
                command.Parameters.AddWithValue("@THUONG", MUC.THUONG);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

        #endregion



        #region UpdateData


        public bool UpateData(MucBLL MUC)
        {
            try
            {
                string sql = "UPDATE HAI_MUC SET  MUC = @MUC,THUONG=@THUONG WHERE ID_MUC=@ID_MUC";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_MUC", MUC.ID_MUC);
                command.Parameters.AddWithValue("@MUC", MUC.MUC);
                command.Parameters.AddWithValue("@THUONG", MUC.THUONG);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
            finally
            {
                connection.Close();
            }


            return true;
        }
        #endregion
    }
}
