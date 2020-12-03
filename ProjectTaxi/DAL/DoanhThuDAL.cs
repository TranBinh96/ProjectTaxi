﻿using ProjectTaxi.BLL;
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
    class DoanhThuDAL
    {
        SqlConnection connection = new SqlConnection(DBConnection.DbConn);

        public DoanhThuBLL GetDoanhThu()
        {
            DoanhThuBLL doanhThu = new DoanhThuBLL();

            string queryString =
                    "SELECT * FROM HAI_DOANHTHU WHERE ID_DOANH_THU = (SELECT MAX(ID_DOANH_THU) FROM HAI_DOANHTHU)";


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
                        doanhThu.MA_DOANH_THU = reader[0].ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return doanhThu;
        }


        #region Select Data
        public DataTable SelectData()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "select  * from  HAI_DOANHTHU";
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
        public bool InsertData(DoanhThuBLL doanhThu)
        {
            try
            {
                string sql = "INSERT INTO HAI_DOANHTHU(ID_DOANH_THU, ID_LAIXE, TIEN_NOP, NGAY_NOP, TIEN_THUONG) VALUES (@ID_DOANH_THU, @ID_LAIXE, @TIEN_NOP,@NGAY_NOP, @TIEN_THUONG) ";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_DOANH_THU", doanhThu.MA_DOANH_THU);
                command.Parameters.AddWithValue("@ID_LAIXE", doanhThu.ID_LAI_XE);
                command.Parameters.AddWithValue("@TIEN_NOP", doanhThu.TIEN_NOP);
                command.Parameters.AddWithValue("@NGAY_NOP", doanhThu.NGAY_NOP);
                command.Parameters.AddWithValue("@TIEN_THUONG", doanhThu.TIEN_THUONG);

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


        public bool UpateData(DoanhThuBLL doanhThu)
        {
            try
            {

                string sql = "UPDATE HAI_DOANHTHU SET  ID_LAIXE=@ID_LAIXE,TIEN_NOP=@TIEN_NOP,NGAY_NOP=@NGAY_NOP,TIEN_THUONG=@TIEN_THUONG WHERE ID_DOANH_THU=@ID_DOANH_THU";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_LAIXE", doanhThu.ID_LAI_XE);
                command.Parameters.AddWithValue("@TIEN_NOP", doanhThu.TIEN_NOP);
                command.Parameters.AddWithValue("@ID_DOANH_THU", doanhThu.MA_DOANH_THU);
                command.Parameters.AddWithValue("@NGAY_NOP", doanhThu.NGAY_NOP);
                command.Parameters.AddWithValue("@TIEN_THUONG", doanhThu.TIEN_THUONG);
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
        public bool DeleteData(DoanhThuBLL doanhThu)
        {
            try
            {
                string sql = "DELETE HAI_DOANHTHU where ID_DOANH_THU=@ID_DOANH_THU";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID_DOANH_THU", doanhThu.MA_DOANH_THU);
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
