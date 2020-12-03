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
    class XeDAL
    {

        SqlConnection connection = new SqlConnection(DBConnection.DbConn);

        public XeBLL GetXe()
        {
            XeBLL xe = new XeBLL();

            string queryString =
                    "SELECT * FROM HAI_XE WHERE ID_XE = (SELECT MAX(ID_XE) FROM HAI_XE)";
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
                        xe.ID_XE = reader[0].ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return xe;
        }



        public List<XeBLL> GetxeBLLs()
        {
            List<XeBLL> list = new List<XeBLL>();

            string queryString =
                    "select  * from  HAI_XE;";

           try {
                SqlConnection connection1 = new SqlConnection(DBConnection.DbConn);
                SqlCommand command = new SqlCommand( queryString, connection1);
                connection1.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        XeBLL XE = new XeBLL();
                        XE.ID_XE = reader[0].ToString();
                        XE.LOAI_XE = reader[1].ToString();
                        XE.SO_XE = reader[2].ToString();

                        list.Add(XE);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Hệ Thống Lỗi");
            }          
                
            return list;
        }

            

            #region Select Data
            public DataTable SelectData()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "select  * from  HAI_XE";
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
        public bool InsertData(XeBLL Xe)
        {
            try
            {
                string sql = "INSERT INTO HAI_XE(ID_XE, LOAI_XE, SO_XE, SO_LAI) VALUES (@ID_XE, @LOAI_XE, @SO_XE, @SO_LAI)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_XE", Xe.ID_XE);
                command.Parameters.AddWithValue("@LOAI_XE", Xe.LOAI_XE);
                command.Parameters.AddWithValue("@SO_XE", Xe.SO_XE);
                command.Parameters.AddWithValue("@SO_LAI", Xe.SO_LAI);

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


        public bool UpateData(XeBLL Xe)
        {
            try
            {
                string sql = "UPDATE HAI_XE SET  LOAI_XE = @LOAI_XE,SO_XE=@SO_XE WHERE ID_XE=@ID_XE";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_XE", Xe.ID_XE);
                command.Parameters.AddWithValue("@LOAI_XE", Xe.LOAI_XE);
                command.Parameters.AddWithValue("@SO_XE", Xe.SO_XE);
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

        #region Delete
        public bool DeleteData(XeBLL xe)
        {
            try
            {
                string sql = "DELETE HAI_XE where ID_XE=@ID_XE";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_XE",xe.ID_XE);
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
        #endregion
    }
}
