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
    class ChiNhanhDAL
    {
        static SqlConnection connection = new SqlConnection(DBConnection.DbConn);

        public ChiNhanhBLL GetChiNhanh()
        {
            ChiNhanhBLL nhanhBLL = new ChiNhanhBLL();

            string queryString =
                    "SELECT * FROM HAI_CHINHANH WHERE ID_CN = (SELECT MAX(ID_CN) FROM HAI_CHINHANH)";


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
                        nhanhBLL.ID_CN = reader[0].ToString();
                       
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return nhanhBLL;
        }


        public List<ChiNhanhBLL> GetChiNhanhBLLs()
        {
            List<ChiNhanhBLL> list = new List<ChiNhanhBLL>();

            string queryString =
                    "select  * from  HAI_CHINHANH;";


            try
            {
                SqlConnection connection1 = new SqlConnection(DBConnection.DbConn);
                SqlCommand command = new SqlCommand(
               queryString, connection1);
                connection1.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiNhanhBLL chiNhanh = new ChiNhanhBLL();
                        chiNhanh.ID_CN = reader[0].ToString();
                        chiNhanh.TENCN = reader[1].ToString();
                        chiNhanh.DIACHI = reader[2].ToString();
                        list.Add(chiNhanh);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            return list;
        }

        #region Select Data
        public DataTable SelectData()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "select  * from  HAI_CHINHANH";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(table);
            }
            catch(Exception ex)
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
        public bool InsertData(ChiNhanhBLL chiNhanh)
        {
            try
            {
                string sql = "insert into  HAI_CHINHANH(ID_CN,TENCN, DIACHI)  values (@ID_CN,@TENCN,@DIACHI)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_CN", chiNhanh.ID_CN);
                command.Parameters.AddWithValue("@TENCN", chiNhanh.TENCN);
                command.Parameters.AddWithValue("@DIACHI", chiNhanh.DIACHI);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)             
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

    
        public bool UpateData(ChiNhanhBLL chiNhanh)
        {
            try
            {
                string sql = "UPDATE HAI_CHINHANH SET  TENCN = @TENCN,DIACHI=@DIACHI WHERE ID_CN=@ID_CN";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_CN", chiNhanh.ID_CN);
                command.Parameters.AddWithValue("@TENCN", chiNhanh.TENCN);
                command.Parameters.AddWithValue("@DIACHI", chiNhanh.DIACHI);
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
        public bool DeleteData(ChiNhanhBLL chiNhanh)
        {
            try
            {
                string sql = "DELETE HAI_CHINHANH where ID_CN=@ID_CN";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_CN", chiNhanh.ID_CN);
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
