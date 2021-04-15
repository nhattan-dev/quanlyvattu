using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using QLVT_DATHANG.Controllers;
using QLVT_DATHANG.Views;
using DevExpress.XtraReports.UI;
using QLVT_DATHANG.Report;

namespace QLVT_DATHANG
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        internal static string _datasource;
        internal static string _datasourceRoot;
        internal static string _database = "QLVT_DH";
        internal static string _password;
        internal static string _username;
        internal static string _user;
        internal static string _quyen;
        internal static string _hoten;
        internal static string _CN = "";
        internal static string _ChiNhanh = "";
        internal static string _ChiNhanhroot = "";
        internal static string _userHTKN = "HTKN";
        internal static string _passwordHTKN = "123456";
        internal static string _usernameroot = "";
        internal static string _passwordroot = "";
        public frmMain()
        {
            InitializeComponent();
            skins();
            disEndMenuLogin(true);
            MaximizeBox = false;
        }

        internal static List<byte> typePages = new List<byte>();
        public void PhanQuyen(string Quyen, bool e)
        {
            if (Quyen.Equals("CHINHANH") || Quyen.Equals("CONGTY"))
            {
                btnRegister.Enabled = e;

            }
            else if (Quyen.Equals("USER"))
            {
                btnRegister.Enabled = !e;
            }
        }

        internal void HienThiThongTinUser()
        {
            DataSet info = Controllers.NhanVienCtrl.GetInfo(_username);
            _hoten = info.Tables[0].Rows[0]["HOTEN"].ToString();
            _quyen = info.Tables[0].Rows[0]["TENNHOM"].ToString();
            _user = info.Tables[0].Rows[0]["USERNAME"].ToString();

            bsiTen.Caption = "Tên : " + _hoten;
            bsiNhom.Caption = "Nhóm : " + _quyen;
            bsiMaNV.Caption = "Mã NV : " + _user;

        }

        public void ResetInfo()
        {
            bsiTen.Caption = "Tên : ...";
            bsiNhom.Caption = "Nhóm : ...";
            bsiMaNV.Caption = "Mã NV : ...";
            cbbCN.Enabled = false;
        }
        public void ThemTabPages(UserControl uct, byte typeControl, string tenTab)
        {
            for (int i = 0; i < tabHienThi.TabPages.Count; i++)
            {
                if (tabHienThi.TabPages[i].Contains(uct) == true)
                {
                    tabHienThi.SelectedTab = tabHienThi.TabPages[i];
                    return;
                }
            }
            TabPage tab = new TabPage();
            typePages.Add(typeControl);
            tab.Name = uct.Name;
            tab.Size = tabHienThi.Size;
            tab.Text = tenTab;
            tabHienThi.TabPages.Add(tab);
            tabHienThi.SelectedTab = tab;
            uct.Dock = DockStyle.Fill;
            tab.Controls.Add(uct);
            uct.Focus();
            //show tabPages
            tabHienThi.Visible = true;
        }

        public void DongTabHienTai()
        {
            tabHienThi.TabPages.Remove(tabHienThi.SelectedTab);
            if (tabHienThi.TabPages.Count <= 0)
            {
                tabHienThi.Visible = false;
            }
        }

        public void DongTatCaTab()
        {
            while (tabHienThi.TabPages.Count > 0)
            {
                DongTabHienTai();
            }
        }

        public void disEndMenuLogin(bool e)
        {
            btnDangXuat.Enabled = !e;
            btnDoiMK.Enabled = !e;
            btnDDH.Enabled = !e;
            btnKho.Enabled = !e;
            btnNhap.Enabled = !e;
            btnNhanVien.Enabled = !e;
            btnVattu.Enabled = !e;
            btnRegister.Enabled = !e;
            btnLogin.Enabled = e;
            btnPhieuXuat.Enabled = !e;
            btnRpt_DonDatHang.Enabled = !e;
            btnRpt_HoatDong.Enabled = !e;
            btnRpt_NhanVien.Enabled = !e;
            btnRpt_NhapXuat.Enabled = !e;
            btnRpt_SoluongTrigiaPN.Enabled = !e;
            btnRpt_SoluongTrigiaPX.Enabled = !e;
            btnRpt_VatTu.Enabled = !e;
        }

        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Office 2007 Green";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDangNhap login = null;
        Check_Login:
            if (login == null || login.IsDisposed)
            {
                login = new frmDangNhap();
            }
            if (login.ShowDialog() == DialogResult.OK)
            {
                if (login.txtUser.Text.Trim(' ') == "")
                {
                    XtraMessageBox.Show("Hãy nhập tài khoản !");
                    goto Check_Login;
                }
                if (login.txtPass.Text.Trim(' ') == "")
                {
                    XtraMessageBox.Show("Hãy nhập mật khẩu !");
                    goto Check_Login;
                }

                //get info
                _datasource = login.cbbCN.SelectedValue.ToString();
                _username = login.txtUser.Text;
                _password = login.txtPass.Text;
                if (checkLogin() == true)
                {
                    //login thanh cong, save info
                    _CN = Connection.ExcuteScalar(string.Format("select MaCN = dbo.fc_GetMaCN()")).Trim();
                    disEndMenuLogin(false);
                    HienThiThongTinUser();
                    _ChiNhanh = login.cbbCN.Text;
                    _ChiNhanhroot = _ChiNhanh;
                    _usernameroot = _username;
                    _passwordroot = _password;
                    _datasourceRoot = login.cbbCN.SelectedValue.ToString();
                    //set value cbbCN
                    cbbCN.SelectedIndex = login.cbbCN.SelectedIndex;
                    //show combobox change Chi Nhanh
                    if (_quyen == "CONGTY")
                    {
                        cbbCN.Enabled = true;
                    }
                    //set quyen     
                    PhanQuyen(_quyen, true);
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại ! Kiểm tra lại !");
                }

            }
        }

        private bool checkLogin()
        {
            try
            {
                string sqlcon = "server =" + frmMain._datasource + "; uid= " + frmMain._username + "; pwd= " + frmMain._password + "; database = " + frmMain._database;
                SqlConnection con = new SqlConnection(sqlcon);
                con.Open();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
                return false;
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn đăng xuất ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DongTatCaTab();
                disEndMenuLogin(true);
                ResetInfo();
                btnLogin_ItemClick(sender, e);

                //reset uct
                uctVatTu.uctVT = new uctVatTu();
                uctKho.uctK = new uctKho();
                uctNhanvien.uctNV = new uctNhanvien();
                //clear undoList
                uctVatTu.undoList.Clear();
                uctKho.undoList.Clear();
                uctNhanvien.undoList.Clear();
                //clear redoList
                uctVatTu.redoList.Clear();
                uctKho.redoList.Clear();
                uctNhanvien.redoList.Clear();
            }
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemTabPages(uctNhanvien.uctNV, 4, "Quản lý nhân viên");
        }

        private void btnRegister_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDangKy1 register = null;
        Check_Login:
            if (register == null || register.IsDisposed)
            {
                register = new frmDangKy1();
            }
            if (register.ShowDialog() == DialogResult.OK)
            {
                if (register.txtUser.Text.Trim(' ') == "")
                {
                    XtraMessageBox.Show("Hãy nhập tài khoản !");
                    goto Check_Login;
                }
                else if (register.txtPass.Text.Trim(' ') == "")
                {
                    XtraMessageBox.Show("Hãy nhập mật khẩu !");
                    goto Check_Login;
                }
                else if (register.txtRepass.Text.Trim(' ') == "")
                {
                    XtraMessageBox.Show("Hãy nhập lại mật khẩu !");
                    goto Check_Login;
                }
                else if (!register.txtRepass.Text.Equals(register.txtPass.Text))
                {
                    XtraMessageBox.Show("Mật khẩu không khớp !");
                    goto Check_Login;
                }
                else if (register.cbbMaNV.SelectedValue == null)
                {
                    XtraMessageBox.Show("Mã nhân viên không hợp lệ !");
                    goto Check_Login;
                }
                int kq = AccountCtrl.TaoTaiKhoan(register.txtUser.Text, register.txtPass.Text, register.cbbMaNV.SelectedValue.ToString(), register.cbbQuyen.Text);
                if (kq == 0)
                {
                    MessageBox.Show("Thành công !");
                }
                else
                {
                    MessageBox.Show("Thất bại (tên đăng nhập hoặc mã nhân viên đã được sử dụng)!");
                    goto Check_Login;
                }
            }
        }

        private void đóngTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DongTabHienTai();
        }

        private void đóngTấtCảToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DongTatCaTab();
        }

        private void btnVattu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemTabPages(uctVatTu.uctVT, 4, "Quản lý vật tư");
        }

        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemTabPages(uctKho.uctK, 4, "Quản lý kho");
        }

        private void btnDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDatHang DDH = null;
            if (DDH == null || DDH.IsDisposed)
            {
                DDH = new frmDatHang();
            }
            DDH.ShowDialog();
        }

        private void btnNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhieuNhap PN = null;
            if (PN == null || PN.IsDisposed)
            {
                PN = new frmPhieuNhap();
            }
            PN.ShowDialog();
        }

        private void btnPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhieuXuat PX = null;
            if (PX == null || PX.IsDisposed)
            {
                PX = new frmPhieuXuat();
            }
            PX.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DHDataSet.v_DS_PhanManh' table. You can move, or remove it, as needed.
            this.v_DS_PhanManhTableAdapter.Fill(this.qLVT_DHDataSet.v_DS_PhanManh);
        }

        private void cbbCN_TextChanged(object sender, EventArgs e)
        {
            //cbb has changed
            if (cbbCN.SelectedValue != null)
            {
                if (cbbCN.SelectedValue.ToString() != _datasource)
                {
                    //remove all tabs
                    DongTatCaTab();
                    //reset static var
                    uctVatTu.uctVT = new uctVatTu();
                    uctKho.uctK = new uctKho();
                    uctNhanvien.uctNV = new uctNhanvien();
                    //switch accounts
                    if (cbbCN.SelectedValue.ToString().Equals(_datasourceRoot))
                    {
                        _username = _usernameroot;
                        _password = _passwordroot;
                    }
                    else
                    {
                        _username = _userHTKN;
                        _password = _passwordHTKN;
                    }
                    //save new data
                    _datasource = cbbCN.SelectedValue.ToString();
                    _CN = Connection.ExcuteScalar(string.Format("select MaCN = dbo.fc_GetMaCN()")).Trim();
                }
            }
        }

        private void btnRpt_NhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xrp_DSNhanVien dsnv = new xrp_DSNhanVien();
            if (_CN.Trim(' ').Equals("CN1"))
            {
                dsnv.DataSource = dsnv.sqlDataSource1;
            }
            else if (_CN.Trim(' ').Equals("CN2"))
            {
                dsnv.DataSource = dsnv.sqlDataSource2;
            }
            dsnv.ShowPreview();
        }

        private void btnRpt_SoluongTrigia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSLTG_PhieuNhap frmSLTG_PhieuNhap = null;
            if (frmSLTG_PhieuNhap == null || frmSLTG_PhieuNhap.IsDisposed)
            {
                frmSLTG_PhieuNhap = new frmSLTG_PhieuNhap();
            }
            if (frmSLTG_PhieuNhap.ShowDialog() == DialogResult.OK)
            {
                xrp_DS_SLTG_PhieuNhap sltgPN = new xrp_DS_SLTG_PhieuNhap(_quyen, frmSLTG_PhieuNhap.dtpStart.Value, frmSLTG_PhieuNhap.dtpEnd.Value);
                sltgPN.ShowPreview();
            }

        }

        private void btnRpt_HoatDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHoatDongNV frmHoatDongNV = null;
            if (frmHoatDongNV == null || frmHoatDongNV.IsDisposed)
            {
                frmHoatDongNV = new frmHoatDongNV();
            }
            if (frmHoatDongNV.ShowDialog() == DialogResult.OK)
            {
                int manv = Convert.ToInt32(frmHoatDongNV.cbbMaNV.Text);
                xrp_TT_NhanVien xrp_TT_NhanVien = new xrp_TT_NhanVien(manv, frmHoatDongNV.dtpStart.Value, frmHoatDongNV.dtpEnd.Value);
                xrp_TT_NhanVien.ShowPreview();
            }
        }

        private void btnRpt_DonDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xrp_DS_DDH_ChuaNhap xrp_DS_DDH_ChuaNhap = new xrp_DS_DDH_ChuaNhap();
            if (_CN.Trim(' ').Equals("CN1"))
            {
                xrp_DS_DDH_ChuaNhap.DataSource = xrp_DS_DDH_ChuaNhap.sqlDataSource1;
            }
            else if (_CN.Trim(' ').Equals("CN2"))
            {
                xrp_DS_DDH_ChuaNhap.DataSource = xrp_DS_DDH_ChuaNhap.sqlDataSource2;
            }
            xrp_DS_DDH_ChuaNhap.ShowPreview();
        }

        private void btnRpt_NhapXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTongHopNhapXuat frmTongHopNhapXuat = null;
            if (frmTongHopNhapXuat == null || frmTongHopNhapXuat.IsDisposed)
            {
                frmTongHopNhapXuat = new frmTongHopNhapXuat();
            }
            if (frmTongHopNhapXuat.ShowDialog() == DialogResult.OK)
            {
                xrp_TH_NhapXuat xrp_TH_NhapXuat = new xrp_TH_NhapXuat(frmTongHopNhapXuat.dtpStart.Value, frmTongHopNhapXuat.dtpEnd.Value);
                xrp_TH_NhapXuat.ShowPreview();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSLTG_PhieuXuat frmSLTG_PhieuXuat = null;
            if (frmSLTG_PhieuXuat == null || frmSLTG_PhieuXuat.IsDisposed)
            {
                frmSLTG_PhieuXuat = new frmSLTG_PhieuXuat();
            }
            if (frmSLTG_PhieuXuat.ShowDialog() == DialogResult.OK)
            {
                xrp_SLTG_PhieuXuat sltgPX = new xrp_SLTG_PhieuXuat(_quyen, frmSLTG_PhieuXuat.dtpStart.Value, frmSLTG_PhieuXuat.dtpEnd.Value);
                if (_CN.Trim(' ').Equals("CN1"))
                {
                    sltgPX.DataSource = sltgPX.qlvT_DHDataSet_CN11;
                }
                else if (_CN.Trim(' ').Equals("CN2"))
                {
                    sltgPX.DataSource = sltgPX.qlvT_DHDataSet_CN21;
                }
                sltgPX.ShowPreview();
            }

        }

        private void btnRpt_VatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xrp_DS_VatTu dsvt = new xrp_DS_VatTu();
            if (_CN.Trim(' ').Equals("CN1"))
            {
                dsvt.DataSource = dsvt.sqlDataSource1;
            }
            else if (_CN.Trim(' ').Equals("CN2"))
            {
                dsvt.DataSource = dsvt.sqlDataSource2;
            }
            dsvt.ShowPreview();
        }
    }
}
