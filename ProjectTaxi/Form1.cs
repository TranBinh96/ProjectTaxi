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
        ViewDoanhThuDAL ViewDoanhThu = new ViewDoanhThuDAL();

        List<ChiNhanhBLL> list_CN = new List<ChiNhanhBLL>();
        List<XeBLL> list_Xe = new List<XeBLL>();
        List<MucBLL> list_Muc = new List<MucBLL>();
        List<LaiXeBLL> list_LX = new List<LaiXeBLL>();




        private String Auto_ID_CN()
        {
            ChiNhanhBLL chiNhanh = chiNhanhDAL.GetChiNhanh();
            string m = chiNhanh.ID_CN; 

            try
            {
                int n = Convert.ToInt32(m.Substring(2)) + 1;
                if (n <= 9)
                    m = "CN" + n;
                else
                    if (n <= 99)
                    m = "CN" + n;
                else
                    m = "CN" + n;
            }
            catch
            {
                m = "CN1";
            }
            return m;
        }

        private String Auto_ID_DT()
        {
            DoanhThuBLL doanh = doanhThuDAL.GetDoanhThu();
            string m = doanh.MA_DOANH_THU;
            try
            {
                int n = Convert.ToInt32(m.Substring(2)) + 1;
                if (n <= 9)
                    m = "DT00" + n;
                else
                    if (n <= 99)
                    m = "DT0" + n;
                else
                    m = "DT" + n;
            }
            catch
            {
                m = "DT001";
            }
            return m;
        }

        private String Auto_ID_XE()
        {
            XeBLL xe = XeDAL.GetXe();
            string m = xe.ID_XE;
            try
            {
                int n = Convert.ToInt32(m.Substring(2)) + 1;
                if (n <= 9)
                    m = "X00" + n;
                else
                    if (n <= 99)
                    m = "X0" + n;
                else
                    m = "X" + n;
            }
            catch
            {
                m = "X001";
            }
            return m;
        }
        private String Auto_ID_LX()
        {
            LaiXeBLL lx = LaiXeDAL.GetLaiXe();
            string m = lx.ID_LX;
            try
            {
                int n = Convert.ToInt32(m.Substring(2)) + 1;
                if (n <= 9)
                    m = "CN1000" + n;
                else
                    if (n <= 99)
                    m = "CN100" + n;
                else
                    m = "CN10" + n;
            }
            catch
            {
                m = "CN10001";
            }
            return m; 
        }

        private String Auto_ID_MUC()
        {
            MucBLL muc = mucDAL.GetDat();
            string m = muc.ID_MUC;
            try
            {
                int n = Convert.ToInt32(m.Substring(2)) + 1;
                if (n <= 9)
                    m = "M00" + n;
                else
                    if (n <= 99)
                    m = "M0" + n;
                else
                    m = "M" + n;
            }
            catch
            {
                m = "M001";
            }
            return m;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            gridControl_ChiNhanh.DataSource = chiNhanhDAL.SelectData();
            gridMuc.DataSource = mucDAL.SelectData();
            gridLaiXe.DataSource = LaiXeDAL.SelectData();
            gridXe.DataSource = XeDAL.SelectData();
            gridDoanhThu.DataSource = doanhThuDAL.SelectData();
            gridDoanhThuTungNgay.DataSource = ViewDoanhThu.SelectData();
        }
        #region Chi Nhanh

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_DiaChi_CN.Text != "" && txt_Name_CN.Text != "")
            {
                chiNhanhBLL.ID_CN = Auto_ID_CN();
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
            txt_ID_Muc_M.Text = "";
            txtMaDoanhThu_DT.Text = "";
            cmb_Laixe_DT.Text = "";
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
                mucBLL.ID_MUC = Auto_ID_MUC();
                mucBLL.MUC = txt_Muc_M.Text;
                mucBLL.THUONG = txt_Thuong_M.Text;

                mucBLL.MUC_2 = txt_Muc2_M.Text;
                mucBLL.THUONG_2 = txt_Thuong2_M.Text;

                mucBLL.MUC_3 = txt_Muc3_M.Text;
                mucBLL.THUONG_3 = txt_Thuong3_M.Text;

                mucBLL.ID_XE = cmbXe_M.SelectedValue.ToString();

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
                mucBLL.ID_MUC = Auto_ID_MUC();
                mucBLL.MUC = txt_Muc_M.Text;
                mucBLL.THUONG = txt_Thuong_M.Text;

                mucBLL.MUC_2 = txt_Muc2_M.Text;
                mucBLL.THUONG_2 = txt_Thuong2_M.Text;

                mucBLL.MUC_3 = txt_Muc3_M.Text;
                mucBLL.THUONG_3 = txt_Thuong3_M.Text;
                if (mucDAL.UpateData(mucBLL))
                {
                    MessageBox.Show("Cập Nhât Mức Thành Công");
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
            cmbXe_M.Text = row[3].ToString();

            txt_Muc2_M.Text = row[4].ToString();
            txt_Thuong2_M.Text = row[5].ToString();

            txt_Muc3_M.Text = row[6].ToString();
            txt_Thuong3_M.Text = row[7].ToString();
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
            if (txt_TenLX.Text != "")
            {
                LaiXeBLL.ID_LX = Auto_ID_LX();
                LaiXeBLL.TEN_LX = txt_TenLX.Text;
                LaiXeBLL.SO_DAM = txtSoDam.Text;
                LaiXeBLL.ID_XE = cmbMaXe_LX.SelectedValue.ToString();
                LaiXeBLL.ID_CN = cmbChiNhanh_LX.SelectedValue.ToString();
                if (LaiXeDAL.InsertData(LaiXeBLL))
                {
                    MessageBox.Show("Thêm Xe Thành Công");
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
            if (txtMaLaiXe.Text != "")
            {
                LaiXeBLL.ID_LX = txtMaLaiXe.Text;
                LaiXeBLL.TEN_LX = txt_TenLX.Text;
                LaiXeBLL.SO_DAM = txtSoDam.Text;
                LaiXeBLL.ID_XE = cmbMaXe_LX.SelectedValue.ToString();
                LaiXeBLL.ID_CN = cmbChiNhanh_LX.SelectedValue.ToString();
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
            if (txtLoaiXe_X.Text != "")
            {
                    xeBLL.ID_XE = Auto_ID_XE();
                    xeBLL.LOAI_XE = txtLoaiXe_X.Text;
                    xeBLL.SO_XE = txt_SoXe_X.Text;
                    xeBLL.SO_LAI = txt_SoLai_X.Text;
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
        }

        private void txt_Cancal_Xe_Click(object sender, EventArgs e)
        {
            Clean();
        }

      

        public float tienthuong()
        {
            float tienthuong = 0;
            List<String> loaiXes = doanhThuDAL.getLoaixes(doanhThuBLL.ID_LAI_XE);

            //lấy Dữ Liệu Về
            List<DoanhThuBLL> doanhThuBLLs = doanhThuDAL.getDoanhThuBLLs();
            foreach (String doanhThu in loaiXes)
            {
                MessageBox.Show(doanhThu);
            }


            return tienthuong;
        }

        



        private void btnSave_DT_Click(object sender, EventArgs e)
        {

            if (txtTienNop_DT.Text != "")
            {
                doanhThuBLL.MA_DOANH_THU = Auto_ID_DT();
                doanhThuBLL.ID_LAI_XE = cmb_Laixe_DT.SelectedValue.ToString();
                doanhThuBLL.TIEN_NOP = txtTienNop_DT.Text;
                doanhThuBLL.NGAY_NOP = txtNgayNop_DT.Value;
                doanhThuBLL.TIEN_THUONG = txt_TienThuong_DT.Text;




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
                doanhThuBLL.MA_DOANH_THU = Auto_ID_DT();
                doanhThuBLL.ID_LAI_XE = cmb_Laixe_DT.SelectedValue.ToString();
                doanhThuBLL.TIEN_NOP = txtTienNop_DT.Text;
                doanhThuBLL.NGAY_NOP = txtNgayNop_DT.Value;
                doanhThuBLL.TIEN_THUONG = txt_TienThuong_DT.Text;
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
            cmb_Laixe_DT.Text = row[1].ToString();
            txtTienNop_DT.Text = row[2].ToString();
            txtNgayNop_DT.Text = row[3].ToString();
            txt_TienThuong_DT.Text = row[4].ToString();
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
            tienthuong();
            //Clean();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }


             private void cmbMaXe_LX_Click(object sender, EventArgs e)
        {

            list_Xe = XeDAL.GetxeBLLs();
            cmbMaXe_LX.DataSource = list_Xe;
            cmbMaXe_LX.DisplayMember = "SO_XE";
            cmbMaXe_LX.ValueMember = "ID_XE";
            cmbMaXe_LX.SelectedIndex = -1;
        }


       

        private void cmbChiNhanh_LX_Click(object sender, EventArgs e)
        {
            list_CN = chiNhanhDAL.GetChiNhanhBLLs();
            cmbChiNhanh_LX.DataSource = list_CN;
            cmbChiNhanh_LX.DisplayMember = "DIACHI";
            cmbChiNhanh_LX.ValueMember = "ID_CN";
            cmbChiNhanh_LX.SelectedIndex = -1;
        }

        private void cmb_Laixe_DT_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb_Laixe_DT_Click(object sender, EventArgs e)
        {
            list_LX = LaiXeDAL.GetLaiXeBLLs();
            cmb_Laixe_DT.DataSource = list_LX;
            cmb_Laixe_DT.DisplayMember = "TEN_LX";
            cmb_Laixe_DT.ValueMember = "ID_LX";
            cmb_Laixe_DT.SelectedIndex = -1;
        }

      

      

        private void btnDelete_CN_Click(object sender, EventArgs e)
        {
            if (txt_Muc_M.Text != "" && txt_Thuong_M.Text != "")
            {
                mucBLL.ID_MUC = txt_ID_Muc_M.Text;
                mucBLL.MUC = txt_Muc_M.Text;
                mucBLL.THUONG = txt_Thuong_M.Text;
                if (mucDAL.DeleteData(mucBLL))
                {
                    MessageBox.Show("Xóa Mức Thành Công");
                    gridMuc.DataSource = mucDAL.SelectData();
                    Clean();
                }
            }
            else
            {
                MessageBox.Show("Xóa Mức Thất Bại");
            }
        }

        private void cmbXe_M_Click(object sender, EventArgs e)
        {
            list_Xe = XeDAL.GetxeBLLs();
            cmbXe_M.DataSource = list_Xe;
            cmbXe_M.DisplayMember = "LOAI_XE";
            cmbXe_M.ValueMember = "ID_XE";
            cmbXe_M.SelectedIndex = -1;
        }
    }
}