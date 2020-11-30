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
    class LaiXeDAL
    {
        SqlConnection connection = new SqlConnection(DBConnection.DbConn);
        #region Select Data
        public DataTable SelectData()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "select  * from  HAI_LAIXE";
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
        public bool InsertData(LaiXeBLL laiXe)
        {
            try
            {
                string sql = "INSERT INTO  HAI_LAIXE(ID_LAIXE, TEN_LAIXE, SO_DAM, ID_XE, ID_CN)  VALUES (@ID_LAIXE, @TEN_LAIXE, @SO_DAM, @ID_XE, @ID_CN)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_LAIXE", laiXe.ID_LX);
                command.Parameters.AddWithValue("@TEN_LAIXE", laiXe.TEN_LX);
                command.Parameters.AddWithValue("@SO_DAM", laiXe.SO_DAM);
                command.Parameters.AddWithValue("@ID_XE", laiXe.ID_XE);
                command.Parameters.AddWithValue("@ID_CN", laiXe.ID_CN);

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


        public bool UpateData(LaiXeBLL laiXe)
        {
            try
            {
                string sql = "UPDATE HAI_LAIXE SET   TEN_LAIXE= @TEN_LAIXE,SO_DAM=@SO_DAM,ID_XE=@ID_XE,ID_CN=@ID_CN WHERE ID_LAIXE=@ID_LAIXE";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_LAIXE", laiXe.ID_LX);
                command.Parameters.AddWithValue("@TEN_LAIXE", laiXe.TEN_LX);
                command.Parameters.AddWithValue("@SO_DAM", laiXe.SO_DAM);
                command.Parameters.AddWithValue("@ID_XE", laiXe.ID_XE);
                command.Parameters.AddWithValue("@ID_CN", laiXe.ID_CN);

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

        #region Delete
        public bool DeleteData(LaiXeBLL laiXe)
        {
            try
            {
                string sql = "DELETE HAI_LAIXE where ID_LAIXE=@ID_LAIXE";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID_LAIXE", laiXe.ID_LX);
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
