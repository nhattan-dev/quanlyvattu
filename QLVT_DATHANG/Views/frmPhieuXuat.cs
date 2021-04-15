using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLVT_DATHANG.QLVT_DHDataSet_CN1TableAdapters;
using System.Text.RegularExpressions;
using System.Globalization;

namespace QLVT_DATHANG.Views
{
    public partial class frmPhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        private DataSet dataCTPX;
        private DataSet dataPX;
        public frmPhieuXuat()
        {
            InitializeComponent();
        }
        private static string filter = "";
        private static string filterCTPX = "";

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN2.v_DS_Vattu' table. You can move, or remove it, as needed.
            this.v_DS_VattuTableAdapter1.Fill(this.qLVT_DHDataSet_CN2.v_DS_Vattu);
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN2.v_DS_Kho' table. You can move, or remove it, as needed.
            this.v_DS_KhoTableAdapter1.Fill(this.qLVT_DHDataSet_CN2.v_DS_Kho);
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN1.v_DS_Vattu' table. You can move, or remove it, as needed.
            this.v_DS_VattuTableAdapter.Fill(this.qLVT_DHDataSet_CN1.v_DS_Vattu);
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN1.v_DS_Kho' table. You can move, or remove it, as needed.
            this.v_DS_KhoTableAdapter.Fill(this.qLVT_DHDataSet_CN1.v_DS_Kho);
            LoadData_PhieuXuat();
            LoadData_CTPX();
            SetUp(sender, e);
        }

        private void SetUp(object sender, EventArgs e)
        {
            HienThiDSPX();
            dGVDSPX.Enabled = true;
            lblNgay.Visible = true;
            dTPNgay.Visible = true;
            binding();
            binding_CTPX();
            dis_end(true);
            dis_end_CTPX(true);
            PhanQuyen(frmMain._quyen);
            setStyleComboBox(true);
            setStyleComboBox_CTPX(true);
            button2_Click(sender, e);
            txtMaPX_TextChanged(sender, e);
            lblfilter_TextChanged(sender, e);
        }
        private void LoadData_CTPX()
        {
            dataCTPX = Controllers.PhieuXuatCtrl.FillDataSetCTPX();
            dGVDSCTPX.DataSource = dataCTPX.Tables[0];
        }
        private void LoadData_PhieuXuat()
        {
            dataPX = Controllers.PhieuXuatCtrl.FillDataSetPhieuXuat();
            dGVDSPX.DataSource = dataPX.Tables[0];
        }
        private void HienThiDSPX()
        {
            applyFilter(filter, dGVDSPX);
            dGVDSPX.Dock = DockStyle.Fill;
            dGVDSPX.BorderStyle = BorderStyle.Fixed3D;
            dGVDSPX.RowHeadersVisible = false;
            FormatData();
            TextAlignment();
        }
        private void TextAlignment()
        {
            //PX
            this.dGVDSPX.Columns["Mã PX"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPX.Columns["Mã NV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPX.Columns["Mã kho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPX.Columns["Họ tên KH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSPX.Columns["Ngày"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //CTPX
            this.dGVDSCTPX.Columns["Mã PX"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSCTPX.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTPX.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTPX.Columns["Mã VT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //PX header
            this.dGVDSPX.Columns["Mã PX"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPX.Columns["Mã NV"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPX.Columns["Mã kho"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSPX.Columns["Họ tên KH"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSPX.Columns["Ngày"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //CTPX header
            this.dGVDSCTPX.Columns["Mã PX"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSCTPX.Columns["Số lượng"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTPX.Columns["Đơn giá"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTPX.Columns["Mã VT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void FormatData()
        {
            this.dGVDSCTPX.Columns["Số lượng"].DefaultCellStyle.Format = "0,0";
            this.dGVDSCTPX.Columns["Đơn giá"].DefaultCellStyle.Format = "c0";
        }
        private void PhanQuyen(string quyen)
        {
            if (quyen.Equals("CONGTY"))
            {
                btnThemPX.Enabled = false;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }
        }
        void binding()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dGVDSPX.DataSource, "Mã NV");
            txtMaPX.DataBindings.Clear();
            txtMaPX.DataBindings.Add("Text", dGVDSPX.DataSource, "Mã PX");
            dTPNgay.DataBindings.Clear();
            dTPNgay.DataBindings.Add("Text", dGVDSPX.DataSource, "Ngày");
            cbbMaKho.DataBindings.Clear();
            cbbMaKho.DataBindings.Add("Text", dGVDSPX.DataSource, "Mã kho");
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", dGVDSPX.DataSource, "Họ tên KH");
            lblfilter.DataBindings.Clear();
            lblfilter.DataBindings.Add("Text", dGVDSPX.DataSource, "Mã PX");
        }
        void binding_CTPX()
        {
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dGVDSCTPX.DataSource, "Đơn giá");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dGVDSCTPX.DataSource, "Số lượng");
            cbbMaVT.DataBindings.Clear();
            cbbMaVT.DataBindings.Add("Text", dGVDSCTPX.DataSource, "Mã VT");
        }
        public void setStyleComboBox(bool e)
        {
            if (e)
            {
                cbbMaKho.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                cbbMaKho.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        public void setStyleComboBox_CTPX(bool e)
        {
            if (e)
            {
                cbbMaVT.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                cbbMaVT.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private void clear_data()
        {
            txtMaNV.DataBindings.Clear();
            cbbMaKho.DataBindings.Clear();
            txtMaPX.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            dTPNgay.DataBindings.Clear();

            txtMaNV.Text = "";
            cbbMaKho.Text = "";
            txtMaPX.Text = Connection.ExcuteScalar(string.Format("select MaPX = dbo.fc_GetMaPX()"));
            txtTenKH.Text = "";
        }
        private void clear_data_CTPX()
        {
            cbbMaVT.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtDonGia.DataBindings.Clear();

            cbbMaVT.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnThemPX_Click(object sender, EventArgs e)
        {
            btn_subCancel_Click(sender, e);
            clear_data();
            if (frmMain._CN.Trim(' ').Equals("CN1"))
            {
                //kho
                cbbMaKho.DataSource = qLVT_DHDataSet_CN1.v_DS_Kho;
            }
            else if (frmMain._CN.Trim(' ').Equals("CN2"))
            {
                //kho
                cbbMaKho.DataSource = qLVT_DHDataSet_CN2.v_DS_Kho;
            }
            //kho
            cbbMaKho.DisplayMember = "TENKHO";
            cbbMaKho.ValueMember = "MAKHO";

            dis_end(false);
            lblNgay.Visible = false;
            dTPNgay.Visible = false;
            setStyleComboBox(false);
            //Set value for txtMaNV
            txtMaNV.Text = frmMain._user;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            filter = "";
            frmPhieuXuat_Load(sender, e);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            int _MaNV = 0;
            try
            {
                _MaNV = Convert.ToInt32(txtMaNV.Text.Trim(' '));
            }
            catch { }

            string _TenKH = "";
            try
            {
                _TenKH = txtTenKH.Text.Trim(' ');
            }
            catch { }

            string _MaKho = "";
            try
            {
                _MaKho = cbbMaKho.SelectedValue.ToString();
            }
            catch { }

            string _MaPX = "";
            try
            {
                _MaPX = txtMaPX.Text.Trim(' ');
            }
            catch { }

            if (_MaPX == "")
            {
                XtraMessageBox.Show("Mã phiếu nhập không được trống !");
            }
            else if (_TenKH == "")
            {
                XtraMessageBox.Show("Tên khách hàng không được trống !");
            }
            else if (_MaKho == "")
            {
                XtraMessageBox.Show("Mã kho không hợp lệ !");
            }
            else
            {
                int i = 0;
                i = Controllers.PhieuXuatCtrl.InsertPhieuXuat(_MaPX, _MaKho, _MaNV, _TenKH);
                if (i == 0)
                {
                    MessageBox.Show("Thêm thành công !");
                    LoadData_PhieuXuat();
                    SetUp(sender, e);
                    btnThemPX_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }
            }
        }
        private void dis_end(bool e)
        {
            dTPNgay.Enabled = !e;
            txtTenKH.Enabled = !e;
            cbbMaKho.Enabled = !e;
            btnThemPX.Enabled = e;
            btnReload.Enabled = e;
            btnBoLoc.Enabled = e;
            button2.Enabled = e;
            btnHuy.Enabled = !e;
            btnLuu.Enabled = !e;
        }
        private void dis_end_CTPX(bool e)
        {
            cbbMaVT.Enabled = !e;
            txtSoLuong.Enabled = !e;
            txtDonGia.Enabled = !e;
            btnThemPX.Enabled = e;
            btnReload.Enabled = e;
            btnBoLoc.Enabled = e;
            button2.Enabled = e;
            btn_subCancel.Enabled = !e;
            btn_subSave.Enabled = !e;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetUp(sender, e);
        }

        private void cbbMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void dis_all_filter(bool e)
        {
            grpbFilter.Visible = !e;
        }
        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            dis_all_filter(false);
            cbbLoc.Items.Clear();
            cbbLoc.Items.Add("Họ tên KH");
            cbbLoc.Items.Add("Mã kho");
            cbbLoc.Items.Add("Mã NV");
            cbbLoc.Items.Add("Mã VT");
            cbbLoc.Items.Add("Mã PX");
            cbbLoc.Items.Add("Số lượng");
            cbbLoc.Items.Add("Đơn giá");
            cbbLoc.Items.Add("Ngày");
            cbbLoc.SelectedIndex = cbbLoc.Items.Count - 1;
            cbbLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            txtLoc_Leave(sender, e);
            txtLocPhu_Leave(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filter = "";
            applyFilter(filter, dGVDSPX);
            applyFilter(filterCTPX, dGVDSCTPX);
            dis_all_filter(true);
            resetfilter();
            txtLocPhu.Visible = false;
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
                applyFilter(filterCTPX + filter, dGVDSCTPX);
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
                applyFilter(filter, dGVDSPX);
            }
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
        private void resetfilter()
        {
            txtLoc.Text = "";
            txtLocPhu.Text = "";
        }

        private void txtLoc_Leave(object sender, EventArgs e)
        {
            if (txtLoc.Text.Trim(' ') == "")
            {
                if (cbbLoc.Text == "Họ tên KH")
                {
                    txtLoc.Text = "VD: Nguyễn Văn A";
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
                if (cbbLoc.Text == "Mã PX")
                {
                    txtLoc.Text = "VD: PX000010";
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
            if (txtLoc.Text == "VD: Nguyễn Văn A" || txtLoc.Text == "VD: A1N1" || txtLoc.Text == "VD: 12" ||
                txtLoc.Text == "VD: VT08" || txtLoc.Text == "VD: PX000010" ||
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
                if (cbbLoc.Text == "Họ tên KH")
                {
                    txtLocPhu.Text = "VD: Nguyễn Văn A";
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
                if (cbbLoc.Text == "Mã PX")
                {
                    txtLocPhu.Text = "VD: PX000010";
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
            if (txtLocPhu.Text == "VD: Nguyễn Văn A" || txtLocPhu.Text == "VD: A1N1" || txtLocPhu.Text == "VD: 12" ||
               txtLocPhu.Text == "VD: VT08" || txtLocPhu.Text == "VD: PX000010" ||
               txtLocPhu.Text == "VD: 50" || txtLocPhu.Text == "VD: 100000")
            {
                txtLocPhu.Text = "";
                txtLocPhu.ForeColor = Color.Black;
            }
        }

        private void btn_subSave_Click(object sender, EventArgs e)
        {
            string _MaVT = "";
            try
            {
                _MaVT = cbbMaVT.SelectedValue.ToString();
            }
            catch { }

            float _DonGia = 0f;
            try
            {
                _DonGia = float.Parse(txtDonGia.Text.Replace(",", "").Replace("$", ""));
            }
            catch { }

            string _MaPX = "";
            try
            {
                _MaPX = txtMaPX.Text;
            }
            catch { }

            int _SoLuong = 0;
            try
            {
                _SoLuong = Convert.ToInt32(txtSoLuong.Text.Replace(",", ""));
            }
            catch { }

            if (_MaPX == "" || _MaVT == "" || txtSoLuong.Text == "" || txtDonGia.Text == "")
            {
                XtraMessageBox.Show("Nhập đầy đủ thông tin !");
            }
            else
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
                    i = Controllers.PhieuXuatCtrl.InsertCTPX(_MaPX, _MaVT, _SoLuong, _DonGia);
                    if (i == 0)
                    {
                        MessageBox.Show("Thêm thành công !");
                        //frmPhieuXuat_Load(sender, e);
                        LoadData_CTPX();
                        SetUp(sender, e);
                        thêmCTToolStripMenuItem_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại !");
                    }
                }
            }
        }

        private void btn_subCancel_Click(object sender, EventArgs e)
        {
            SetUp(sender, e);
        }

        private void txtMaPX_TextChanged(object sender, EventArgs e)
        {
        }

        private void applyFilter(string filter, DataGridView dtgv)
        {
            //add filter
            try
            {
                (dtgv.DataSource as DataTable).DefaultView.RowFilter = filter;
            }
            catch (Exception)
            {
                (dtgv.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }

        private void thêmCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHuy_Click(sender, e);
            button2_Click(sender, e);

            //set value for txtKho, txtVT, txtPN
            clear_data_CTPX();

            dis_end_CTPX(false);
            setStyleComboBox_CTPX(false);
            if (frmMain._CN.Equals("CN1"))
            {
                v_DS_VattuTableAdapter.Fill(qLVT_DHDataSet_CN1.v_DS_Vattu);
                cbbMaVT.DataSource = qLVT_DHDataSet_CN1.v_DS_Vattu;
            }
            else if (frmMain._CN.Equals("CN2"))
            {
                v_DS_VattuTableAdapter1.Fill(qLVT_DHDataSet_CN2.v_DS_Vattu);
                cbbMaVT.DataSource = qLVT_DHDataSet_CN2.v_DS_Vattu;
            }

            //dat hang
            cbbMaVT.DisplayMember = "TENVT";
            cbbMaVT.ValueMember = "MAVT";

            if (cbbMaVT.Text.Trim() == "")
            {
                MessageBox.Show("Không có vật tư nào !");
            }

        }
        private void lblfilter_TextChanged(object sender, EventArgs e)
        {
            if (lblfilter.Text != "")
                filterCTPX = "[" + "Mã PX" + "] LIKE '%" + lblfilter.Text + "%'";
            else
                filterCTPX = "[" + "Mã PX" + "] LIKE 'none'";
            applyFilter(filterCTPX, dGVDSCTPX);
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