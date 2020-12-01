using DevExpress.XtraEditors;
using ProjectTaxi.BLL;
using ProjectTaxi.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTaxi
{
    public partial class frmMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void barButtonItemLaiXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void barButtonItemXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void barButtonItemDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }


        ChiNhanhDAL chiNhanhDAL = new ChiNhanhDAL();
        ChiNhanhBLL chiNhanhBLL = new ChiNhanhBLL();
        MucBLL mucBLL = new MucBLL();
        MUCDAL mucDAL = new MUCDAL();
        LaiXeDAL LaiXeDAL = new LaiXeDAL();
        LaiXeBLL LaiXeBLL = new LaiXeBLL();
        XeDAL XeDAL = new XeDAL();
        XeBLL xeBLL = new XeBLL();
        DoanhThuBLL doanhThuBLL = new DoanhThuBLL();
        DoanhThuDAL doanhThuDAL = new DoanhThuDAL();

        List<ChiNhanhBLL> list_CN = new List<ChiNhanhBLL>();
        List<XeBLL> list_Xe = new List<XeBLL>();

        public void Load_Data_1()
        {
            list_CN = chiNhanhDAL.GetChiNhanhBLLs();
            cmbChiNhanh_LX.DataSource = list_CN;
            cmbChiNhanh_LX.DisplayMember = "TENCN";
            cmbChiNhanh_LX.ValueMember = "ID_CN";
            cmbChiNhanh_LX.SelectedIndex = -1;

            list_Xe = XeDAL.GetxeBLLs();
            cmbMaXe_LX.DataSource = list_Xe;
            cmbMaXe_LX.DisplayMember = "SO_XE";
            cmbMaXe_LX.ValueMember = "ID_XE";
            cmbMaXe_LX.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridControl_ChiNhanh.DataSource = chiNhanhDAL.SelectData();
            gridMuc.DataSource = mucDAL.SelectData();
            gridLaiXe.DataSource = LaiXeDAL.SelectData();
            gridXe.DataSource = XeDAL.SelectData();
            gridDoanhThu.DataSource = doanhThuDAL.SelectData();
            Load_Data_1();

        }
        #region Chi Nhanh

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_DiaChi_CN.Text != "" && txt_Name_CN.Text != "")
            {
                chiNhanhBLL.ID_CN = txtID_CN.Text;
                chiNhanhBLL.TENCN = txt_Name_CN.Text;
                chiNhanhBLL.DIACHI = txt_DiaChi_CN.Text;
                if (chiNhanhDAL.InsertData(chiNhanhBLL))
                {
                    MessageBox.Show("Thêm Chi Nhánh Thành Công");
                    gridControl_ChiNhanh.DataSource = chiNhanhDAL.SelectData();                
                    Clean();


                }
            }
            else
            {
                MessageBox.Show("Thêm Chi Nhánh Thất Bại");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clean();
        }

        public void Clean()
        {
            txtID_CN.Text = "";
            txt_DiaChi_CN.Text = "";
            txt_Name_CN.Text = "";
            txt_ID_Muc_M.Text = "";
            txt_Muc_M.Text = "";
            txt_Thuong_M.Text = "";
            txtMaLaiXe.Text = "";
            txt_TenLX.Text = "";
            txtSoDam.Text = "";
            cmbChiNhanh_LX.Text = "";
            cmbMaXe_LX.Text = "";
            txtMaXe_X.Text = "";
            txtLoaiXe_X.Text = "";
            txt_SoXe_X.Text = "";
            txt_SoLai_X.Text = "";
            txt_MucDat_X.Text = "";
            txt_ID_Muc_M.Text = "";
            txtMaDoanhThu_DT.Text = "";
            txt_LaiXe_DT.Text = "";
            txt_Muc_DT.Text = "";
            txt_ChiNhanh_DT.Text = "";
            txtTienNop_DT.Text = "";
            txtNgayNop_DT.Value = DateTime.Now;
            txt_TienThuong_DT.Text = "";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_DiaChi_CN.Text != "" && txt_Name_CN.Text != "" && txtID_CN.Text != "")
            {
                chiNhanhBLL.ID_CN = txtID_CN.Text;
                chiNhanhBLL.TENCN = txt_Name_CN.Text;
                chiNhanhBLL.DIACHI = txt_DiaChi_CN.Text;
                if (chiNhanhDAL.UpateData(chiNhanhBLL))
                {
                    MessageBox.Show("Cập Nhật Chi Nhánh Thành Công");
                    gridControl_ChiNhanh.DataSource = chiNhanhDAL.SelectData();
                    Load_Data_1();
                    Clean();
                }
                else
                {
                    MessageBox.Show("Cập Nhật Chi Nhánh Thất Bại");
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Tên Chi Nhánh Và Địa Chỉ");
            }
        }

        private void gridControl_ChiNhanh_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridChiNhanh.GetDataRow(gridChiNhanh.GetSelectedRows()[0]);
            if (row == null || row[0].ToString() == "")
                return;
            txtID_CN.Text = row[0].ToString();
            txt_Name_CN.Text = row[1].ToString();
            txt_DiaChi_CN.Text = row[2].ToString();

        }
       
        #endregion

        #region Muc
        private void btnSave_M_Click(object sender, EventArgs e)
        {
            if (txt_Muc_M.Text != "" && txt_Thuong_M.Text != "")
            {
                mucBLL.ID_MUC = txt_ID_Muc_M.Text;
                mucBLL.MUC = float.Parse(txt_Muc_M.Text);
                mucBLL.THUONG = float.Parse(txt_Thuong_M.Text);
                if (mucDAL.InsertData(mucBLL))
                {
                    MessageBox.Show("Thêm Mức Thành Công");
                    gridMuc.DataSource = mucDAL.SelectData();
                    Clean();


                }
            }
            else
            {
                MessageBox.Show("Thêm Mức Thất Bại");
            }
        }

        private void btn_Update_M_Click(object sender, EventArgs e)
        {
            if (txt_Muc_M.Text != "" && txt_Thuong_M.Text != "")
            {
                mucBLL.ID_MUC = txt_ID_Muc_M.Text;
                mucBLL.MUC = float.Parse(txt_Muc_M.Text);
                mucBLL.THUONG = float.Parse(txt_Thuong_M.Text);
                if (mucDAL.UpateData(mucBLL))
                {
                    MessageBox.Show("Cập Nhâth Mức Thành Công");
                    gridMuc.DataSource = mucDAL.SelectData();
                    Clean();


                }
            }
            else
            {
                MessageBox.Show("Cập Nhật Mức Thất Bại");
            }
        }

        private void gridMuc_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridViewMuc.GetDataRow(gridViewMuc.GetSelectedRows()[0]);
            if (row == null || row[0].ToString() == "")
                return;


            txt_ID_Muc_M.Text = row[0].ToString();
            txt_Muc_M.Text = row[1].ToString();
            txt_Thuong_M.Text = row[2].ToString();
        }

        private void btnCancel_M_Click(object sender, EventArgs e)
        {
            Clean();
        }

        #endregion

        private void btn_Delete_CN_Click(object sender, EventArgs e)
        {
            if (txtID_CN.Text != "")
            {
                chiNhanhBLL.ID_CN = txtID_CN.Text;
                chiNhanhBLL.TENCN = txt_Name_CN.Text;
                chiNhanhBLL.DIACHI = txt_DiaChi_CN.Text;
                string name = txt_Name_CN.Text;
                DialogResult dlr = MessageBox.Show("Bạn muốn Xóa "+name+ "  ?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (chiNhanhDAL.DeleteData(chiNhanhBLL))
                    {
                        MessageBox.Show("Xóa Chi Nhánh Thành Công");
                        gridControl_ChiNhanh.DataSource = chiNhanhDAL.SelectData();
                        Load_Data_1();
                        Clean();
                    }
                }       
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Mã Chính Nhánh");
            }
        }
        #region
        private void btnSave_LX_Click(object sender, EventArgs e)
        {
            if (txtMaLaiXe.Text != "")
            {
                LaiXeBLL.ID_LX = txtMaLaiXe.Text;
                LaiXeBLL.TEN_LX = txt_TenLX.Text;
                LaiXeBLL.SO_DAM = txtSoDam.Text;
                LaiXeBLL.ID_XE = cmbMaXe_LX.Text;
                LaiXeBLL.ID_CN = cmbChiNhanh_LX.Text;
                if (LaiXeDAL.InsertData(LaiXeBLL))
                {
                    MessageBox.Show("Thêm Lái Xe Thành Công");
                    gridLaiXe.DataSource = LaiXeDAL.SelectData();
                    Clean();
                }
            }
            else
            {
                MessageBox.Show("Thêm Lái Xe Thất Bại");
            }
        }


        #endregion

        private void btn_Update_LX_Click(object sender, EventArgs e)
        {
            if (txtMaLaiXe.Text != "" && ggd.Text != "")
            {
                LaiXeBLL.ID_LX = txtMaLaiXe.Text;
                LaiXeBLL.TEN_LX = txt_TenLX.Text;
                LaiXeBLL.SO_DAM = txtSoDam.Text;
                LaiXeBLL.ID_XE = cmbMaXe_LX.Text;
                LaiXeBLL.ID_CN = cmbChiNhanh_LX.Text;
                if (LaiXeDAL.UpateData(LaiXeBLL))
                {
                    MessageBox.Show("Cập Nhật Xe Thành Công");
                    gridLaiXe.DataSource = LaiXeDAL.SelectData();
                    Clean();
                }
            }
            else
            {
                MessageBox.Show("Cập Nhật Lái Xe Thất Bại");
            }
        }

        private void btn_Delete_LX_Click(object sender, EventArgs e)
        {
            if (txtMaLaiXe.Text != "" )
            {
                LaiXeBLL.ID_LX = txtMaLaiXe.Text;
                string name = txt_TenLX.Text;
                DialogResult dlr = MessageBox.Show("Bạn muốn Xóa " + name + "  ?",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (LaiXeDAL.DeleteData(LaiXeBLL))
                    {
                        MessageBox.Show("Xóa Xe Thành Công");
                        gridLaiXe.DataSource = LaiXeDAL.SelectData();
                        Clean();
                    }else
                        MessageBox.Show("Cập Nhật Lái Xe Thất Bại");
                }                   
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Mã Lái Xe");
            }
        }

        private void gridLaiXe_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridViewLaiXe.GetDataRow(gridViewLaiXe.GetSelectedRows()[0]);
            if (row == null || row[0].ToString() == "")
                return;

            txtMaLaiXe.Text = row[0].ToString();
            txt_TenLX.Text = row[1].ToString();
            txtSoDam.Text = row[2].ToString();
            cmbMaXe_LX.Text = row[3].ToString();
            cmbChiNhanh_LX.Text = row[4].ToString();
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void txtSave_X_Click(object sender, EventArgs e)
        {
            if (txtMaXe_X.Text != "")
            {
                    xeBLL.ID_XE = txtMaXe_X.Text;
                    xeBLL.LOAI_XE = txtLoaiXe_X.Text;
                    xeBLL.SO_XE = txt_SoXe_X.Text;
                    xeBLL.SO_LAI = txt_SoLai_X.Text;
                    xeBLL.MUC_DAT = txt_MucDat_X.Text;
                    xeBLL.ID_MUC = txt_SoLai_X.Text;
                    if (XeDAL.InsertData(xeBLL))
                    {
                        MessageBox.Show("Thêm Xe Thành Công");
                        gridXe.DataSource = XeDAL.SelectData();
                        Clean();
                    }
                
                else
                {
                    MessageBox.Show("Thêm  Xe Thất Bại");
                }
            }
            else
            {
                MessageBox.Show("Vui Long Nhập Mã Xe");
            }
        }

        private void txtUpdate_X_Click(object sender, EventArgs e)
        {
            if (txtMaXe_X.Text != "")
            {
                xeBLL.ID_XE = txtMaXe_X.Text;
                xeBLL.LOAI_XE = txtLoaiXe_X.Text;
                xeBLL.SO_XE = txt_SoXe_X.Text;
                xeBLL.SO_LAI = txt_SoLai_X.Text;
                xeBLL.MUC_DAT = txt_MucDat_X.Text;
                xeBLL.ID_MUC = txt_SoLai_X.Text;
                if (XeDAL.UpateData(xeBLL))
                {
                    MessageBox.Show("Câp Nhật Xe Thành Công");
                    gridXe.DataSource = XeDAL.SelectData();
                    Clean();
                }
                else
                {
                    MessageBox.Show("Cập Nhât Xe Thất Bại");
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Mã Xe");
            }
        }

        private void btnDelete_X_Click(object sender, EventArgs e)
        {
            if (txtMaXe_X.Text != "")
            {
                xeBLL.ID_XE = txtMaXe_X.Text;
                string name = txt_SoXe_X.Text;
                DialogResult dlr = MessageBox.Show("Bạn muốn Xóa " + name + "  ?",
              "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (XeDAL.DeleteData(xeBLL))
                    {
                        MessageBox.Show("Xóa Xe Thành Công");
                        gridXe.DataSource = XeDAL.SelectData();
                        Clean();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Xe Thất Bại");
                    }
                }                 
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Mã Xe");
            }
        }

        private void gridXe_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridViewXe.GetDataRow(gridViewXe.GetSelectedRows()[0]);
            if (row == null || row[0].ToString() == "")
                return;

            txtMaXe_X.Text = row[0].ToString();
            txtLoaiXe_X.Text = row[1].ToString();
            txt_SoXe_X.Text = row[2].ToString();
            txt_SoLai_X.Text = row[3].ToString();
            txt_MucDat_X.Text = row[4].ToString();
            txt_MaMuc_X.Text = row[5].ToString();
        }

        private void txt_Cancal_Xe_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnSave_DT_Click(object sender, EventArgs e)
        {
            if (txtMaDoanhThu_DT.Text != "")
            {
                doanhThuBLL.MA_DOANH_THU = txtMaDoanhThu_DT.Text;
                doanhThuBLL.ID_LAI_XE = txt_LaiXe_DT.Text;
                doanhThuBLL.ID_MUC = txt_Muc_DT.Text;
                doanhThuBLL.ID_CHI_NHANH = txt_ChiNhanh_DT.Text;
                doanhThuBLL.TIEN_NOP = float.Parse(txtTienNop_DT.Text);
                doanhThuBLL.NGAY_NOP = txtNgayNop_DT.Value;
                doanhThuBLL.TIEN_THUONG = float.Parse(txt_TienThuong_DT.Text);
                if (doanhThuDAL.InsertData(doanhThuBLL))
                {
                    MessageBox.Show("Thêm Doanh Thu Thành Công");
                    gridDoanhThu.DataSource = doanhThuDAL.SelectData();
                    Clean();
                }

                else
                {
                    MessageBox.Show("Thêm  Doanh Thu Thất Bại");
                } 
            }
            else
            {
                MessageBox.Show("Vui Long Nhập Mã Doanh thu");
            }
        }

        private void btn_Update_DT_Click(object sender, EventArgs e)
        {
            if (txtMaDoanhThu_DT.Text != "")
            {
                doanhThuBLL.MA_DOANH_THU = txtMaDoanhThu_DT.Text;
                doanhThuBLL.ID_LAI_XE = txt_LaiXe_DT.Text;
                doanhThuBLL.ID_MUC = txt_Muc_DT.Text;
                doanhThuBLL.ID_CHI_NHANH = txt_ChiNhanh_DT.Text;
                doanhThuBLL.TIEN_NOP = float.Parse(txtTienNop_DT.Text);
                doanhThuBLL.NGAY_NOP = txtNgayNop_DT.Value;
                doanhThuBLL.TIEN_THUONG = float.Parse(txt_TienThuong_DT.Text);
                if (doanhThuDAL.UpateData(doanhThuBLL))
                {
                    MessageBox.Show("Cập Nhật Doanh Thu Thành Công");
                    gridDoanhThu.DataSource = doanhThuDAL.SelectData();
                    Clean();
                }

                else
                {
                    MessageBox.Show("Cập Nhật  Doanh Thu Thất Bại");
                }


            }
            else
            {
                MessageBox.Show("Vui Long Nhập Mã Doanh thu");
            }
        }

        private void gridDoanhThu_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridViewDoanhThu.GetDataRow(gridViewDoanhThu.GetSelectedRows()[0]);
            if (row == null || row[0].ToString() == "")
                return;

            txtMaDoanhThu_DT.Text = row[0].ToString();
            txt_LaiXe_DT.Text = row[1].ToString();
            txt_Muc_DT.Text = row[2].ToString();
            txt_ChiNhanh_DT.Text = row[3].ToString();
            txtTienNop_DT.Text = row[4].ToString();
            txtNgayNop_DT.Text = row[5].ToString();
            txt_TienThuong_DT.Text = row[6].ToString();
        }

        private void btn_Xoa_DT_Click(object sender, EventArgs e)
        {
            if (txtMaDoanhThu_DT.Text != "")
            {
                doanhThuBLL.MA_DOANH_THU = txtMaDoanhThu_DT.Text;
                string name = txtMaDoanhThu_DT.Text;
                DialogResult dlr = MessageBox.Show("Bạn muốn Xóa " + name + "  ?",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (doanhThuDAL.DeleteData(doanhThuBLL))
                    {
                        MessageBox.Show("Xóa Doanh Thu Thành Công");
                        gridDoanhThu.DataSource = doanhThuDAL.SelectData();
                        Clean();
                    }

                    else
                    {
                        MessageBox.Show("Xóa  Doanh Thu Thất Bại");
                    }
                }              
            }
            else
            {
                MessageBox.Show("Vui Long Nhập Mã Doanh thu");
            }
        }

        private void btnCancel_DT_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }


        private void cmbChiNhanh_LX_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
           
        }
    }
}