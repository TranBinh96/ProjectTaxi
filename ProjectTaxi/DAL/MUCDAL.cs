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

        public MucBLL GetDat()
        {
            MucBLL muc = new MucBLL();

            string queryString =
                    "SELECT * FROM HAI_MUC WHERE ID_MUC = (SELECT MAX(ID_MUC) FROM HAI_MUC)";
            try
            {
                SqlConnection connection2 = new SqlConnection(DBConnection.DbConn);
                SqlCommand command = new SqlCommand(
               queryString, connection2);
                connection2.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        muc.ID_MUC = reader[0].ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return muc;
        }



        public List<MucBLL> GetMUCBLLs()
        {
            List<MucBLL> list = new List<MucBLL>();
            SqlConnection connection1 = new SqlConnection(DBConnection.DbConn);

            string queryString =
                    "select  * from  HAI_MUC";

            {
                SqlCommand command = new SqlCommand(
                    queryString, connection1);
                connection1.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MucBLL MUC = new MucBLL();
                        MUC.ID_MUC= reader[0].ToString();
                        MUC.MUC= reader[1].ToString();
                        MUC.THUONG= reader[2].ToString();                      
                        list.Add(MUC);
                    }
                }
            }

            return list;
        }


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
                string sql = "insert into  HAI_MUC(ID_MUC, M1, THUONG_1, ID_XE, M2, THUONG_2, M3, THUONG_3)  values (@ID_MUC, @M1, @THUONG_1, @ID_XE, @M2, @THUONG_2, @M3, @THUONG_3)";


                SqlCommand command = new SqlCommand(sql, connection);


                command.Parameters.AddWithValue("@ID_MUC", MUC.ID_MUC);
                command.Parameters.AddWithValue("@M1", MUC.MUC);
                command.Parameters.AddWithValue("@THUONG_1", MUC.THUONG);
                command.Parameters.AddWithValue("@M2", MUC.MUC_2);
                command.Parameters.AddWithValue("@ID_XE", MUC.ID_XE);
                command.Parameters.AddWithValue("@THUONG_2", MUC.THUONG_2);
                command.Parameters.AddWithValue("@M3", MUC.MUC_3);
                command.Parameters.AddWithValue("@THUONG_3", MUC.THUONG_3);



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
                string sql = "UPDATE HAI_MUC SET  ID_MUC=@ID_MUC, M1=@M1, THUONG_1=@THUONG_1, ID_XE=@ID_XE, M2=@M2, THUONG_2=@THUONG_2, M3=@M3, THUONG_3=@THUONG_3 WHERE ID_MUC=@ID_MUC";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID_MUC", MUC.ID_MUC);
                command.Parameters.AddWithValue("@M1", MUC.MUC);
                command.Parameters.AddWithValue("@THUONG_1", MUC.THUONG);
                command.Parameters.AddWithValue("@M2", MUC.MUC_2);
                command.Parameters.AddWithValue("@THUONG_2", MUC.THUONG_2);
                command.Parameters.AddWithValue("@M3", MUC.MUC_3);
                command.Parameters.AddWithValue("@THUONG_3", MUC.THUONG_3);
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

        public bool DeleteData(MucBLL MUC)
        {
            try
            {
                string sql = "DELETE HAI_MUC  WHERE ID_MUC=@ID_MUC";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_MUC", MUC.ID_MUC);
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
