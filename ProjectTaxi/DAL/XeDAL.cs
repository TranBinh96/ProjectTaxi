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

        static SqlConnection connection = new SqlConnection(DBConnection.DbConn);

        public List<XeBLL> GetxeBLLs()
        {
            List<XeBLL> list = new List<XeBLL>();

            string queryString =
                    "select  * from  HAI_XE;";

            {
                SqlCommand command = new SqlCommand( queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        XeBLL XE = new XeBLL();
                        XE.ID_XE = reader[0].ToString();
                        XE.SO_XE = reader[2].ToString();

                        list.Add(XE);
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
                string sql = "INSERT INTO HAI_XE(ID_XE, LOAI_XE, SO_XE, SO_LAI, MUC_DAT, ID_MUC) VALUES (@ID_XE, @LOAI_XE, @SO_XE, @SO_LAI, @MUC_DAT, @ID_MUC)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_XE", Xe.ID_XE);
                command.Parameters.AddWithValue("@LOAI_XE", Xe.LOAI_XE);
                command.Parameters.AddWithValue("@SO_XE", Xe.SO_XE);
                command.Parameters.AddWithValue("@SO_LAI", Xe.SO_LAI);
                command.Parameters.AddWithValue("@MUC_DAT", Xe.MUC_DAT);
                command.Parameters.AddWithValue("@ID_MUC", Xe.ID_MUC);

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
                string sql = "UPDATE HAI_XE SET  LOAI_XE = @LOAI_XE,SO_XE=@SO_XE,MUC_DAT=@MUC_DAT,ID_MUC=@ID_MUC WHERE ID_XE=@ID_XE";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_XE", Xe.ID_XE);
                command.Parameters.AddWithValue("@LOAI_XE", Xe.LOAI_XE);
                command.Parameters.AddWithValue("@SO_XE", Xe.SO_XE);
                command.Parameters.AddWithValue("@MUC_DAT", Xe.MUC_DAT);
                command.Parameters.AddWithValue("@ID_MUC", Xe.ID_MUC);
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
