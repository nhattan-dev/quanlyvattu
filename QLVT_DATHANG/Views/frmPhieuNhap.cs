//using DevExpress.XtraEditors;
using DevExpress.XtraEditors;
using QLVT_DATHANG.QLVT_DHDataSet_CN1TableAdapters;
using System;
using System.Drawing;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace QLVT_DATHANG.Views
{
    public partial class frmPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        private DataSet dataCTPN;
        private DataSet dataPN;
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private static string filter = "";
        private static string filterCTPN = "";
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN2.v_DS_DatHangChuaNhap' table. You can move, or remove it, as needed.
            this.v_DS_DatHangChuaNhapTableAdapter1.Fill(this.qLVT_DHDataSet_CN2.v_DS_DatHangChuaNhap);
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN1.v_DS_DatHangChuaNhap' table. You can move, or remove it, as needed.
            this.v_DS_DatHangChuaNhapTableAdapter.Fill(this.qLVT_DHDataSet_CN1.v_DS_DatHangChuaNhap);
            LoadData_PhieuNhap();
            LoadData_CTPN();
            SetUp(sender, e);
        }
        private void SetUp(object sender, EventArgs e)
        {
            HienThiDSPN();
            setStyleComboBox(true);
            setStyleComboBox_CTPN(true);
            lblNgay.Visible = true;
            dTPNgay.Visible = true;
            binding();
            binding_CTPN();
            dis_end(true);
            dis_end_CTPN(true);
            button2_Click(sender, e);
            PhanQuyen(frmMain._quyen);
            filterCTPNbyMaPN();
        }
        public void setStyleComboBox(bool e)
        {
            if (e == true)
            {
                cbbMaDDH.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                cbbMaDDH.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        public void setStyleComboBox_CTPN(bool e)
        {
            if (e == true)
            {
                cbbMaVT.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                cbbMaVT.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private void PhanQuyen(string quyen)
        {
            if (quyen.Equals("CONGTY"))
            {
                btnThemPN.Enabled = false;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }
        }
        private void LoadData_PhieuNhap()
        {
            dataPN = Controllers.PhieuNhapCtrl.FillDataSetPhieuNhap();
            dGVDSPN.DataSource = dataPN.Tables[0];
        }
        private void LoadData_CTPN()
        {
            dataCTPN = Controllers.PhieuNhapCtrl.FillDataSetCTPN();
            dGVDSCTPN.DataSource = dataCTPN.Tables[0];
        }
        private void HienThiDSPN()
        {

            applyFilter(filter, dGVDSPN);
            dGVDSPN.Dock = DockStyle.Fill;
            dGVDSPN.BorderStyle = BorderStyle.Fixed3D;
            dGVDSPN.RowHeadersVisible = false;
            dGVDSCTPN.Dock = DockStyle.Fill;
            dGVDSCTPN.BorderStyle = BorderStyle.Fixed3D;
            dGVDSCTPN.RowHeadersVisible = false;
            FormatData();
            TextAlignment();
        }
        private void TextAlignment()
        {
            //PN
            this.dGVDSPN.Columns["Mã PN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPN.Columns["Mã NV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPN.Columns["Mã kho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPN.Columns["Mã ĐĐH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPN.Columns["Ngày"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //CTPN
            this.dGVDSCTPN.Columns["Mã PN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSCTPN.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTPN.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTPN.Columns["Mã VT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //PN header
            this.dGVDSPN.Columns["Mã PN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPN.Columns["Mã NV"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPN.Columns["Mã kho"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPN.Columns["Mã ĐĐH"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPN.Columns["Ngày"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //CTPN header
            this.dGVDSCTPN.Columns["Mã PN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSCTPN.Columns["Số lượng"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTPN.Columns["Đơn giá"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTPN.Columns["Mã VT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void FormatData()
        {
            this.dGVDSCTPN.Columns["Số lượng"].DefaultCellStyle.Format = "0,0";
            this.dGVDSCTPN.Columns["Đơn giá"].DefaultCellStyle.Format = "c0";
        }
        private void clear_data()
        {
            txtMaNV.DataBindings.Clear();
            txtMaKho.DataBindings.Clear();
            txtMaPN.DataBindings.Clear();
            cbbMaDDH.DataBindings.Clear();
            dTPNgay.DataBindings.Clear();

            txtMaNV.Text = "";
            txtMaKho.Text = "";
            cbbMaDDH.Text = "";
        }
        private void clear_data_CTPN()
        {
            cbbMaVT.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtDonGia.DataBindings.Clear();

            cbbMaVT.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
        }
        void binding()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dGVDSPN.DataSource, "Mã NV");
            cbbMaDDH.DataBindings.Clear();
            cbbMaDDH.DataBindings.Add("Text", dGVDSPN.DataSource, "Mã ĐĐH");
            dTPNgay.DataBindings.Clear();
            dTPNgay.DataBindings.Add("Text", dGVDSPN.DataSource, "Ngày");
            txtMaKho.DataBindings.Clear();
            txtMaKho.DataBindings.Add("Text", dGVDSPN.DataSource, "Mã kho");
            txtMaPN.DataBindings.Clear();
            txtMaPN.DataBindings.Add("Text", dGVDSPN.DataSource, "Mã PN");
            lblfilter.DataBindings.Clear();
            lblfilter.DataBindings.Add("Text", dGVDSPN.DataSource, "Mã PN");
        }
        void binding_CTPN()
        {
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dGVDSCTPN.DataSource, "Đơn giá");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dGVDSCTPN.DataSource, "Số lượng");
            cbbMaVT.DataBindings.Clear();
            cbbMaVT.DataBindings.Add("Text", dGVDSCTPN.DataSource, "Mã VT");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            filter = "";
            frmPhieuNhap_Load(sender, e);
        }
        private void dis_end_CTPN(bool e)
        {
            txtSoLuong.Enabled = !e;
            txtDonGia.Enabled = !e;
            cbbMaVT.Enabled = !e;
            btnThemPN.Enabled = e;
            btnReload.Enabled = e;
            btnBoLoc.Enabled = e;
            button2.Enabled = e;
            btn_subCancel.Enabled = !e;
            btn_subSave.Enabled = !e;
        }
        private void dis_end(bool e)
        {
            dTPNgay.Enabled = !e;
            cbbMaDDH.Enabled = !e;
            btnThemPN.Enabled = e;
            btnReload.Enabled = e;
            btnBoLoc.Enabled = e;
            button2.Enabled = e;
            btnHuy.Enabled = !e;
            btnLuu.Enabled = !e;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btn_subCancel_Click(sender, e);
            button2_Click(sender, e);
            clear_data();
            //set value combo box nhan vien
            if (frmMain._CN.Trim(' ').Equals("CN1"))
            {
                //dat hang
                cbbMaDDH.DataSource = qLVT_DHDataSet_CN1.v_DS_DatHangChuaNhap;
            }
            else if (frmMain._CN.Trim(' ').Equals("CN2"))
            {
                //dat hang
                cbbMaDDH.DataSource = qLVT_DHDataSet_CN2.v_DS_DatHangChuaNhap;
            }
            //dat hang
            cbbMaDDH.DisplayMember = "TEN";
            cbbMaDDH.ValueMember = "MAsoDDH";

            dis_end(false);
            lblNgay.Visible = false;
            dTPNgay.Visible = false;
            setStyleComboBox(false);
            //setStyleComboBox_CTPN(false);

            //set value for txtKho, txtVT, txtPN
            if (cbbMaDDH.SelectedValue != null && cbbMaDDH.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                DataSet info = Controllers.PhieuNhapCtrl.FillDataSetThongTin(cbbMaDDH.SelectedValue.ToString().Trim(' '));
                if (info.Tables[0].Rows.Count > 0)
                {
                    txtMaPN.Text = info.Tables[0].Rows[0]["MAPN"].ToString();
                    txtMaKho.Text = info.Tables[0].Rows[0]["MAKHO"].ToString();
                }
            }
            else if (cbbMaDDH.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                txtMaPN.Text = "";
                txtMaKho.Text = "";
                MessageBox.Show("Không có đơn đặt hàng nào !");
            }
            //set value for txtMaNV
            txtMaNV.Text = frmMain._user;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetUp(sender, e);
        }


        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            int _MaNV = 0;
            try
            {
                _MaNV = Convert.ToInt32(txtMaNV.Text);
            }
            catch { }

            string _MaDDH = "";
            try
            {
                _MaDDH = cbbMaDDH.SelectedValue.ToString();
            }
            catch { }

            string _MaKho = "";
            try
            {
                _MaKho = txtMaKho.Text.Trim(' ');
            }
            catch { }

            string _MaPN = "";
            try
            {
                _MaPN = txtMaPN.Text.Trim(' ');
            }
            catch { }

            if (_MaPN == "" || _MaNV == 0)
            {
                XtraMessageBox.Show("Nhập đầy đủ thông tin !");
            }
            else if (_MaDDH == "")
            {
                XtraMessageBox.Show("Mã ĐĐH không hợp lệ !");
            }
            else if (_MaKho == "")
            {
                XtraMessageBox.Show("Mã kho không được trống !");
            }
            else
            {
                int i = 0;
                i = Controllers.PhieuNhapCtrl.InsertPhieuNhap(_MaPN, _MaDDH, _MaKho, _MaNV);
                if (i == 0)
                {
                    MessageBox.Show("Thêm thành công !");
                    LoadData_PhieuNhap();
                    SetUp(sender, e);
                    btnThem_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }
            }
        }

        private void cbbMaDDH_TextChanged(object sender, EventArgs e)
        {
            if (cbbMaDDH.SelectedValue != null && cbbMaDDH.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                DataSet info = Controllers.PhieuNhapCtrl.FillDataSetThongTin(cbbMaDDH.SelectedValue.ToString().Trim(' '));
                if (info.Tables[0].Rows.Count > 0)
                {
                    txtMaPN.Text = info.Tables[0].Rows[0]["MAPN"].ToString();
                    txtMaKho.Text = info.Tables[0].Rows[0]["MAKHO"].ToString();
                }
            }
            else if (cbbMaDDH.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                txtMaPN.Text = "";
                txtMaKho.Text = "";
                MessageBox.Show("Không có đơn đặt hàng nào !");
            }

        }

        private void applyFilter(string filter, DataGridView dtgv)
        {
            //add filter
            if (dtgv != null)
            {
                try
                {
                    (dtgv.DataSource as DataTable).DefaultView.RowFilter = filter;
                }
                catch (Exception)
                {
                    (dtgv.DataSource as DataTable).DefaultView.RowFilter = "";
                }
            }
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            dis_all_filter(false);
            cbbLoc.Items.Clear();
            cbbLoc.Items.Add("Mã ĐĐH");
            cbbLoc.Items.Add("Mã kho");
            cbbLoc.Items.Add("Mã NV");
            cbbLoc.Items.Add("Mã VT");
            cbbLoc.Items.Add("Mã PN");
            cbbLoc.Items.Add("Số lượng");
            cbbLoc.Items.Add("Đơn giá");
            cbbLoc.Items.Add("Ngày");
            cbbLoc.SelectedIndex = cbbLoc.Items.Count - 1;
            cbbLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            txtLoc_Leave(sender, e);
            txtLocPhu_Leave(sender, e);
        }
        private void dis_all_filter(bool e)
        {
            grpbFilter.Visible = !e;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filter = "";
            applyFilter(filter, dGVDSPN);
            applyFilter(filterCTPN, dGVDSCTPN);
            dis_all_filter(true);
            resetfilter();
        }

        private void cbbLoc_TextChanged(object sender, EventArgs e)
        {
            if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Số lượng".ToUpper()) || cbbLoc.SelectedItem.ToString().ToUpper().Equals("Đơn giá".ToUpper()))
            {
                txtLoc.Visible = true;
                txtLocPhu.Visible = true;
                dtpStart.Visible = false;
                dtpEnd.Visible = false;
                cbbCompare1.Visible = true;
                cbbCompare2.Visible = true;
                cbbCompare1.SelectedIndex = cbbCompare1.Items.Count - 1;
                cbbCompare2.SelectedIndex = cbbCompare2.Items.Count - 1;
            }
            else if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Ngày".ToUpper()))
            {
                txtLocPhu.Visible = false;
                txtLoc.Visible = false;
                dtpStart.Visible = true;
                dtpEnd.Visible = true;
                cbbCompare1.Visible = true;
                cbbCompare2.Visible = true;
                cbbCompare1.SelectedIndex = cbbCompare1.Items.Count - 1;
                cbbCompare2.SelectedIndex = cbbCompare2.Items.Count - 1;
            }
            else
            {
                txtLoc.Visible = true;
                txtLocPhu.Visible = false;
                dtpStart.Visible = false;
                dtpEnd.Visible = false;
                cbbCompare1.Visible = false;
                cbbCompare2.Visible = false;
            }
            resetfilter();
            txtLoc_Leave(sender, e);
            txtLocPhu_Leave(sender, e);
        }
        public void dis_filter(bool e)
        {
            cbbLoc.Visible = !e;
            txtLoc.Visible = !e;
            btnLoc.Visible = !e;
        }
        private void resetfilter()
        {
            txtLoc.Text = "";
            txtLocPhu.Text = "";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            Regex rg1 = new Regex(@"^\d{1,}$");
            string value = cbbLoc.SelectedItem.ToString().ToUpper();
            if (value.Equals("Số lượng".ToUpper()) || value.Equals("Đơn giá".ToUpper()) || value.Equals("Mã VT".ToUpper()))
            {
                string filter = " AND ";
                if (value.Equals("Số lượng".ToUpper()) || value.Equals("Đơn giá".ToUpper()))
                {
                    long x;
                    if (Int64.TryParse(txtLoc.Text.Replace(",", "").Replace("$", ""), out x) && Int64.TryParse(txtLocPhu.Text.Replace(",", "").Replace("$", ""), out x))
                    {
                        filter += "[" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare1.Text + txtLoc.Text.Replace(",", "").Replace("$", "") +
                            " AND [" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare2.Text + txtLocPhu.Text.Replace(",", "").Replace("$", "");
                    }
                    else
                    {
                        MessageBox.Show("Nhập sai định dạng !");
                        return;
                    }
                }
                else
                {
                    filter += "[" + cbbLoc.SelectedItem.ToString() + "] LIKE '%" + txtLoc.Text + "%'";
                }
                applyFilter(filterCTPN + filter, dGVDSCTPN);
            }
            else
            {
                if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Mã NV".ToUpper()))
                {
                    if (rg1.IsMatch(txtLoc.Text))
                    {
                        filter = "[" + cbbLoc.SelectedItem.ToString() + "]" + "=" + txtLoc.Text;
                    }
                    else
                    {
                        MessageBox.Show("Nhập sai định dạng !");
                        return;
                    }
                }
                else if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Ngày".ToUpper()))
                {
                    //Regex rg2 = new Regex(@"^(>=|<=|=|>|<)\#([1-9]|([0-1][0-2]))\-(([1-9])|([0-2][0-9])|([3][0-1]))\-\d{4}\#$");
                    filter = "[" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare1.Text + "#" + dtpStart.Value.Month + "-" + dtpStart.Value.Day + "-" + dtpStart.Value.Year + "#" +
                    " AND [" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare2.Text + "#" + dtpEnd.Value.Month + "-" + dtpEnd.Value.Day + "-" + dtpEnd.Value.Year + "#";
                }
                else
                {
                    filter = "[" + cbbLoc.SelectedItem.ToString() + "] LIKE '%" + txtLoc.Text + "%'";
                }
                applyFilter(filter, dGVDSPN);
            }
        }

        private void txtLoc_Leave(object sender, EventArgs e)
        {
            if (txtLoc.Text.Trim(' ') == "")
            {
                if (cbbLoc.Text == "Mã ĐĐH")
                {
                    txtLoc.Text = "VD: MDDH0006";
                }
                if (cbbLoc.Text == "Mã kho")
                {
                    txtLoc.Text = "VD: A1N1";
                }
                if (cbbLoc.Text == "Mã NV")
                {
                    txtLoc.Text = "VD: 12";
                }
                if (cbbLoc.Text == "Mã VT")
                {
                    txtLoc.Text = "VD: VT08";
                }
                if (cbbLoc.Text == "Mã PN")
                {
                    txtLoc.Text = "VD: PN000010";
                }
                if (cbbLoc.Text == "Số lượng")
                {
                    txtLoc.Text = "VD: 50";
                }
                if (cbbLoc.Text == "Đơn giá")
                {
                    txtLoc.Text = "VD: 100000";
                }
                txtLoc.ForeColor = Color.Silver;
            }
        }

        private void txtLoc_Enter(object sender, EventArgs e)
        {
            if (txtLoc.Text == "VD: MDDH0006" || txtLoc.Text == "VD: A1N1" || txtLoc.Text == "VD: 12" ||
                txtLoc.Text == "VD: VT08" || txtLoc.Text == "VD: PN000010" ||
                txtLoc.Text == "VD: 50" || txtLoc.Text == "VD: 100000")
            {
                txtLoc.Text = "";
                txtLoc.ForeColor = Color.Black;
            }
        }

        private void txtLocPhu_Leave(object sender, EventArgs e)
        {
            if (txtLocPhu.Text.Trim(' ') == "")
            {
                if (cbbLoc.Text == "Mã ĐĐH")
                {
                    txtLocPhu.Text = "VD: MDDH0006";
                }
                if (cbbLoc.Text == "Mã kho")
                {
                    txtLocPhu.Text = "VD: A1N1";
                }
                if (cbbLoc.Text == "Mã NV")
                {
                    txtLocPhu.Text = "VD: 12";
                }
                if (cbbLoc.Text == "Mã VT")
                {
                    txtLocPhu.Text = "VD: VT08";
                }
                if (cbbLoc.Text == "Mã PN")
                {
                    txtLocPhu.Text = "VD: PN000010";
                }
                if (cbbLoc.Text == "Số lượng")
                {
                    txtLocPhu.Text = "VD: 50";
                }
                if (cbbLoc.Text == "Đơn giá")
                {
                    txtLocPhu.Text = "VD: 100000";
                }
                txtLocPhu.ForeColor = Color.Silver;
            }
        }

        private void txtLocPhu_Enter(object sender, EventArgs e)
        {
            if (txtLocPhu.Text == "VD: MDDH0006" || txtLocPhu.Text == "VD: A1N1" || txtLocPhu.Text == "VD: 12" ||
               txtLocPhu.Text == "VD: VT08" || txtLocPhu.Text == "VD: PN000010" ||
               txtLocPhu.Text == "VD: 50" || txtLocPhu.Text == "VD: 100000")
            {
                txtLocPhu.Text = "";
                txtLocPhu.ForeColor = Color.Black;
            }
        }

        private void thêmCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHuy_Click(sender, e);
            button2_Click(sender, e);

            //set value for txtKho, txtVT, txtPN
            if (cbbMaDDH.Text != "")
            {
                DataSet info = Controllers.DatHangCtrl.FillDataSetThongTin(cbbMaDDH.Text.Trim(' '));
                if (info.Tables[0].Rows.Count > 0)
                {
                    clear_data_CTPN();
                    dis_end_CTPN(false);
                    setStyleComboBox_CTPN(false);
                    cbbMaVT.DataSource = info.Tables[0];
                    //dat hang
                    cbbMaVT.DisplayMember = "TENVT";
                    cbbMaVT.ValueMember = "MAVT";
                }
                else
                {
                    MessageBox.Show("Không có vật tư nào !");
                }
            }
        }

        private void btn_subSave_Click(object sender, EventArgs e)
        {
            string _MaVT = "";
            try
            {
                _MaVT = cbbMaVT.SelectedValue.ToString().Trim(' ');
            }
            catch { }

            float _DonGia = 0f;
            try
            {
                _DonGia = float.Parse(txtDonGia.Text.Replace(",", "").Replace("$", ""));
            }
            catch { }

            string _MaPN = "";
            try
            {
                _MaPN = txtMaPN.Text;
            }
            catch { }

            int _SoLuong = 0;
            try
            {
                _SoLuong = Convert.ToInt32(txtSoLuong.Text.Replace(",", ""));
            }
            catch { }
            if (_MaPN == "" || _MaVT == "" || txtSoLuong.Text == "" || txtDonGia.Text == "")
            {
                XtraMessageBox.Show("Nhập đầy đủ thông tin !");
            }
            else
            {
                try
                {
                    if (_SoLuong <= 0)
                    {
                        XtraMessageBox.Show("Vui lòng nhập số lượng > 0 !");
                    }
                    else if (_DonGia < 0)
                    {
                        XtraMessageBox.Show("Vui lòng nhập đơn giá >= 0 !");
                    }
                    else
                    {
                        int i = 0;
                        i = Controllers.PhieuNhapCtrl.InsertCTPN(_MaPN, _MaVT, _SoLuong, _DonGia);
                        if (i == 0)
                        {
                            MessageBox.Show("Thêm thành công !");
                            LoadData_CTPN();
                            SetUp(sender, e);
                            //frmPhieuNhap_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại !");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("An error occurred while executing Controllers.DatHangCtrl.InsertPhieuNhap !");
                }
            }
        }

        private void btn_subCancel_Click(object sender, EventArgs e)
        {
            SetUp(sender, e);
        }
        private void filterCTPNbyMaPN()
        {
            if (lblfilter.Text != "")
                filterCTPN = "[" + "Mã PN" + "] LIKE '%" + lblfilter.Text + "%'";
            else
                filterCTPN = "[" + "Mã PN" + "] LIKE 'none'";
            applyFilter(filterCTPN, dGVDSCTPN);
        }

        private void dGVDSPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void lblfilter_TextChanged(object sender, EventArgs e)
        {
            filterCTPNbyMaPN();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtSoLuong.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtSoLuong.Text.Replace(",", "")));
                txtSoLuong.SelectionStart = txtSoLuong.Text.Length;
            }
            catch { }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDonGia.Text = "$" + String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtDonGia.Text.Replace(",", "").Replace("$", "")));
                txtDonGia.SelectionStart = txtDonGia.Text.Length;
            }
            catch { }
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {

            if (cbbLoc.Text.Equals("Số lượng"))
            {
                try
                {
                    txtLoc.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtLoc.Text.Replace(",", "")));
                    txtLoc.SelectionStart = txtLoc.Text.Length;
                }
                catch { }

            }
            if (cbbLoc.Text.Equals("Đơn giá"))
            {
                try
                {
                    txtLoc.Text = "$" + String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtLoc.Text.Replace(",", "").Replace("$", "")));
                    txtLoc.SelectionStart = txtLoc.Text.Length;
                }
                catch { }

            }
        }

        private void txtLocPhu_TextChanged(object sender, EventArgs e)
        {
            if (cbbLoc.Text.Equals("Số lượng"))
            {
                try
                {
                    txtLocPhu.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtLocPhu.Text.Replace(",", "")));
                    txtLocPhu.SelectionStart = txtLocPhu.Text.Length;
                }
                catch { }

            }
            if (cbbLoc.Text.Equals("Đơn giá"))
            {
                try
                {
                    txtLocPhu.Text = "$" + String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtLocPhu.Text.Replace(",", "").Replace("$", "")));
                    txtLocPhu.SelectionStart = txtLocPhu.Text.Length;
                }
                catch { }

            }
        }
        private void isDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbLoc.Text.Equals("Số lượng") && cbbLoc.Text.Equals("Đơn giá"))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}