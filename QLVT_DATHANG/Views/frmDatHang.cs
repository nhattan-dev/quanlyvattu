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
using System.Text.RegularExpressions;
using System.Globalization;

namespace QLVT_DATHANG.Views
{
    public partial class frmDatHang : DevExpress.XtraEditors.XtraForm
    {
        private DataSet dataCTDH;
        private DataSet dataDH;
        public frmDatHang()
        {
            InitializeComponent();
        }
        private static string filter = "";
        private static string filterCTDDH = "";

        private void LoadData_DatHang()
        {
            dataDH = Controllers.DatHangCtrl.FillDataSetDDH();
            dGVDSDDH.DataSource = dataDH.Tables[0];
        }
        private void LoadData_CTDH()
        {
            dataCTDH = Controllers.DatHangCtrl.FillDataSetCTDDH();
            dGVDSCTDH.DataSource = dataCTDH.Tables[0];
        }
        internal void HienThiDSDDH()
        {
            //add filter
            applyFilter(filter, dGVDSDDH);
            //style
            dGVDSDDH.Dock = DockStyle.Fill;
            dGVDSDDH.BorderStyle = BorderStyle.Fixed3D;
            dGVDSDDH.RowHeadersVisible = false;
            //style
            dGVDSCTDH.Dock = DockStyle.Fill;
            dGVDSCTDH.BorderStyle = BorderStyle.Fixed3D;
            dGVDSCTDH.RowHeadersVisible = false;
            FormatData();
            TextAlignment();
        }
        private void TextAlignment()
        {
            //PX
            this.dGVDSDDH.Columns["Mã ĐĐH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSDDH.Columns["Mã NV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSDDH.Columns["Mã kho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSDDH.Columns["Nhà CC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSDDH.Columns["Ngày"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //CTPX
            this.dGVDSCTDH.Columns["Mã ĐĐH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSCTDH.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTDH.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTDH.Columns["Mã VT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //PX header
            this.dGVDSDDH.Columns["Mã ĐĐH"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSDDH.Columns["Mã NV"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSDDH.Columns["Mã kho"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSDDH.Columns["Nhà CC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSDDH.Columns["Ngày"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //CTPX header
            this.dGVDSCTDH.Columns["Mã ĐĐH"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSCTDH.Columns["Số lượng"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTDH.Columns["Đơn giá"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSCTDH.Columns["Mã VT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void FormatData()
        {
            this.dGVDSCTDH.Columns["Số lượng"].DefaultCellStyle.Format = "0,0";
            this.dGVDSCTDH.Columns["Đơn giá"].DefaultCellStyle.Format = "c0";
        }
        public void PhanQuyen(string Quyen)
        {
            if (Quyen.Equals("CONGTY"))
            {
                btnThemDDH.Enabled = false;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }
        }

        void frmDatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN2.v_DS_Kho' table. You can move, or remove it, as needed.
            this.v_DS_KhoTableAdapter1.Fill(this.qLVT_DHDataSet_CN2.v_DS_Kho);
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN2.v_DS_Vattu' table. You can move, or remove it, as needed.
            this.v_DS_VattuTableAdapter1.Fill(this.qLVT_DHDataSet_CN2.v_DS_Vattu);
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN1.v_DS_Kho' table. You can move, or remove it, as needed.
            this.v_DS_KhoTableAdapter.Fill(this.qLVT_DHDataSet_CN1.v_DS_Kho);
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN1.v_DS_Vattu' table. You can move, or remove it, as needed.
            this.v_DS_VattuTableAdapter.Fill(this.qLVT_DHDataSet_CN1.v_DS_Vattu);

            LoadData_DatHang();
            LoadData_CTDH();
            SetUp(sender, e);
        }

        private void SetUp(object sender, EventArgs e)
        {
            HienThiDSDDH();
            dGVDSDDH.Enabled = true;
            lblNgay.Visible = true;
            dTPNgay.Visible = true;

            binding();
            bindingCTDDH();
            dis_end(true);
            dis_end_ctdh(true);
            setStyleComboBox(true);
            setStyleComboBox_CTDDH(true);
            PhanQuyen(frmMain._quyen);
            button2_Click(sender, e);
            txtMaDDH_TextChanged(sender, e);
        }

        public void setStyleComboBox(bool e)
        {
            if (e == true)
            {
                cbbMaKho.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                cbbMaKho.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        public void setStyleComboBox_CTDDH(bool e)
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

        void binding()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dGVDSDDH.DataSource, "Mã NV");
            txtMaDDH.DataBindings.Clear();
            txtMaDDH.DataBindings.Add("Text", dGVDSDDH.DataSource, "Mã ĐĐH");
            dTPNgay.DataBindings.Clear();
            dTPNgay.DataBindings.Add("Text", dGVDSDDH.DataSource, "Ngày");
            cbbMaKho.DataBindings.Clear();
            cbbMaKho.DataBindings.Add("Text", dGVDSDDH.DataSource, "Mã Kho");
            txtNhaCC.DataBindings.Clear();
            txtNhaCC.DataBindings.Add("Text", dGVDSDDH.DataSource, "Nhà CC");
            lblfilter.DataBindings.Clear();
            lblfilter.DataBindings.Add("Text", dGVDSDDH.DataSource, "Mã ĐĐH");
        }

        void bindingCTDDH()
        {
            cbbMaVT.DataBindings.Clear();
            cbbMaVT.DataBindings.Add("Text", dGVDSCTDH.DataSource, "Mã VT");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dGVDSCTDH.DataSource, "Đơn giá");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dGVDSCTDH.DataSource, "Số lượng");
        }

        void dis_end_ctdh(bool e)
        {
            txtSoLuong.Enabled = !e;
            txtDonGia.Enabled = !e;
            cbbMaVT.Enabled = !e;
            btn_subSave.Enabled = !e;
            btn_subCancel.Enabled = !e;
            btnThemDDH.Enabled = e;
            btnReload.Enabled = e;
            btnBoLoc.Enabled = e;
            button2.Enabled = e;
        }

        void dis_end(bool e)
        {
            txtNhaCC.Enabled = !e;
            cbbMaKho.Enabled = !e;
            dTPNgay.Enabled = !e;
            btnHuy.Enabled = !e;
            btnLuu.Enabled = !e;
            btnThemDDH.Enabled = e;
            btnReload.Enabled = e;
            btnBoLoc.Enabled = e;
            button2.Enabled = e;
        }

        void clear_data()
        {

            txtMaNV.DataBindings.Clear();
            cbbMaKho.DataBindings.Clear();
            txtMaDDH.DataBindings.Clear();
            txtNhaCC.DataBindings.Clear();
            dTPNgay.DataBindings.Clear();

            txtMaNV.Text = "";
            cbbMaKho.Text = "";
            txtMaDDH.Text = Connection.ExcuteScalar(string.Format("select MaDDH = dbo.fc_GetMaDDH()"));
            txtNhaCC.Text = "";
        }

        void clear_data_ctddh()
        {
            txtSoLuong.DataBindings.Clear();
            txtDonGia.DataBindings.Clear();
            cbbMaVT.DataBindings.Clear();

            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            cbbMaVT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btn_subCancel_Click(sender, e);
            button2_Click(sender, e);
            clear_data();
            //set value combo box nhan vien
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
            //set value for txtMaNV
            txtMaNV.Text = frmMain._user;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            filter = "";
            frmDatHang_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int _MaNV = 0;
            try
            {
                _MaNV = Convert.ToInt32(txtMaNV.Text.Trim(' '));
            }
            catch { }

            string _MaDDH = "";
            try
            {
                _MaDDH = txtMaDDH.Text.Trim(' ');
            }
            catch { }

            string _MaKho = "";
            try
            {
                _MaKho = cbbMaKho.SelectedValue.ToString().Trim(' ');
            }
            catch { }

            string _NhaCC = "";
            try
            {
                _NhaCC = txtNhaCC.Text.Trim(' ');
            }
            catch { }

            if (txtMaDDH.Text == "" || _MaNV == 0)
            {
                XtraMessageBox.Show("Mã ĐĐH không được trống !");
            }
            else if (_NhaCC == "")
            {
                XtraMessageBox.Show("Nhà cung cấp không được để trống !");
            }
            else if (_MaKho == "")
            {
                XtraMessageBox.Show("Mã kho không hợp lệ !");
            }
            else
            {
                int i = 0;
                i = Controllers.DatHangCtrl.InsertDDH(_MaNV, _MaDDH, _MaKho, _NhaCC);
                if (i == 0)
                {
                    MessageBox.Show("Thêm thành công !");
                    LoadData_DatHang();
                    SetUp(sender, e);
                    btnThem_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetUp(sender, e);
        }
        public void dis_filter(bool e)
        {
            cbbLoc.Visible = !e;
            txtLoc.Visible = !e;
            btnLoc.Visible = !e;
        }
        private void dis_all_filter(bool e)
        {
            grpbFilter.Visible = !e;
        }
        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            dis_all_filter(false);
            cbbLoc.Items.Clear();
            cbbLoc.Items.Add("Mã ĐĐH");
            cbbLoc.Items.Add("Mã kho");
            cbbLoc.Items.Add("Mã NV");
            cbbLoc.Items.Add("Nhà CC");
            cbbLoc.Items.Add("Ngày");
            cbbLoc.Items.Add("Số lượng");
            cbbLoc.Items.Add("Đơn giá");
            cbbLoc.Items.Add("Mã VT");
            cbbLoc.SelectedIndex = cbbLoc.Items.Count - 1;
            cbbLoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filter = "";
            applyFilter(filter, dGVDSDDH);
            applyFilter(filterCTDDH, dGVDSCTDH);
            //dis_filter(true);
            dis_all_filter(true);
            resetfilter();
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
                applyFilter(filterCTDDH + filter, dGVDSCTDH);
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
                applyFilter(filter, dGVDSDDH);
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
        private void txtLoc_Leave(object sender, EventArgs e)
        {
            if (txtLoc.Text.Trim(' ') == "")
            {
                if (cbbLoc.Text == "Nhà CC")
                {
                    txtLoc.Text = "VD: CTY A";
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
                if (cbbLoc.Text == "Mã ĐĐH")
                {
                    txtLoc.Text = "VD: MDDH0007";
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
            if (txtLoc.Text == "VD: CTY A" || txtLoc.Text == "VD: A1N1" || txtLoc.Text == "VD: 12" ||
                txtLoc.Text == "VD: VT08" || txtLoc.Text == "VD: MDDH0007" ||
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
                if (cbbLoc.Text == "Nhà CC")
                {
                    txtLocPhu.Text = "VD: CTY A";
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
                if (cbbLoc.Text == "Mã ĐĐH")
                {
                    txtLocPhu.Text = "VD: MDDH0007";
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
            if (txtLocPhu.Text == "VD: CTY A" || txtLocPhu.Text == "VD: A1N1" || txtLocPhu.Text == "VD: 12" ||
               txtLocPhu.Text == "VD: VT08" || txtLocPhu.Text == "VD: MDDH0007" ||
               txtLocPhu.Text == "VD: 50" || txtLocPhu.Text == "VD: 100000")
            {
                txtLocPhu.Text = "";
                txtLocPhu.ForeColor = Color.Black;
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

        private void thêmCTDDHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHuy_Click(sender, e);
            button2_Click(sender, e);
            clear_data_ctddh();
            //set value combo box nhan vien
            if (frmMain._CN.Trim(' ').Equals("CN1"))
            {
                //vat tu
                cbbMaVT.DataSource = qLVT_DHDataSet_CN1.v_DS_Vattu;
            }
            else if (frmMain._CN.Trim(' ').Equals("CN2"))
            {
                //vat tu
                cbbMaVT.DataSource = qLVT_DHDataSet_CN2.v_DS_Vattu;
            }
            //vat tu
            cbbMaVT.DisplayMember = "TENVT";
            cbbMaVT.ValueMember = "MAVT";

            dis_end_ctdh(false);
            setStyleComboBox_CTDDH(false);
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

        private void txtMaDDH_TextChanged(object sender, EventArgs e)
        {
            if (lblfilter.Text != "")
                filterCTDDH = "[" + "Mã ĐĐH" + "] LIKE '%" + lblfilter.Text + "%'";
            else
                filterCTDDH = "[" + "Mã ĐĐH" + "] LIKE 'none'";
            applyFilter(filterCTDDH, dGVDSCTDH);

        }

        private void btn_subCancel_Click(object sender, EventArgs e)
        {
            SetUp(sender, e);
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

            int _SoLuong = 0;
            try
            {
                _SoLuong = Convert.ToInt32(txtSoLuong.Text.Replace(",", ""));
            }
            catch { }

            if (txtMaDDH.Text == "" || cbbMaVT.Text == "" || txtSoLuong.Text == "" || txtDonGia.Text == "")
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
                    else if (_DonGia <= 0)
                    {
                        XtraMessageBox.Show("Vui lòng nhập đơn giá > 0 !");
                    }
                    //else if (Controllers.NhanVienCtrl.NhanVienTonTai(_MaNV) == 1)
                    //{
                    //    MessageBox.Show("Mã nhân viên không tồn tại !");
                    //}
                    //else if (Controllers.VatTuCtrl.VatTuTonTai(_MaVT) == 1)
                    //{
                    //    MessageBox.Show("Mã vật tư không tồn tại !");
                    //}
                    //else if (Controllers.KhoCtrl.KhoTonTai(_MaKho) == 1)
                    //{
                    //    MessageBox.Show("Mã kho không tồn tại !");
                    //}
                    //if (Controllers.DatHangCtrl.DDHTonTai_all(_MaDDH) == 0)
                    //{
                    //    MessageBox.Show("Mã đơn đặt hàng đã tồn tại !");
                    //}
                    else
                    {
                        int i = 0;
                        i = Controllers.DatHangCtrl.InsertCTDDH(txtMaDDH.Text, _MaVT, _SoLuong, _DonGia);
                        if (i == 0)
                        {
                            MessageBox.Show("Thêm thành công !");
                            LoadData_CTDH();
                            SetUp(sender, e);
                            //frmDatHang_Load(sender, e);
                            //btnThem_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại !");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("An error occurred while executing Controllers.DatHangCtrl.InsertDDH !");
                }
            }

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