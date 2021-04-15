using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using QLVT_DATHANG.Models;
using System.Globalization;

namespace QLVT_DATHANG
{
    public partial class uctNhanvien : UserControl
    {
        public uctNhanvien()
        {
            InitializeComponent();
        }

        public static uctNhanvien uctNV = new uctNhanvien();
        internal static Stack<Act> undoList = new Stack<Act>();
        internal static Stack<Act> redoList = new Stack<Act>();
        private static string filter = "";
        internal void HienThiDSNhanVien()
        {
            applyFilter(filter, dGVDSNhanvien);
            dGVDSNhanvien.Dock = DockStyle.Fill;
            dGVDSNhanvien.BorderStyle = BorderStyle.Fixed3D;
            dGVDSNhanvien.RowHeadersVisible = false;
            if (dGVDSNhanvien.RowCount == 0)
            {
                btnChuyenCN.Enabled = false;
            }
            else
            {
                btnChuyenCN.Enabled = true;
            }
            FormatData();
            TextAlignment();
        }
        private void TextAlignment()
        {
            //format
            this.dGVDSNhanvien.Columns["Mã NV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSNhanvien.Columns["Họ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSNhanvien.Columns["Tên"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSNhanvien.Columns["Địa chỉ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSNhanvien.Columns["Ngày sinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSNhanvien.Columns["Lương"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSNhanvien.Columns["Mã CN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //header
            this.dGVDSNhanvien.Columns["Mã NV"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSNhanvien.Columns["Họ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSNhanvien.Columns["Tên"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSNhanvien.Columns["Địa chỉ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSNhanvien.Columns["Ngày sinh"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSNhanvien.Columns["Lương"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSNhanvien.Columns["Mã CN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void FormatData()
        {
            this.dGVDSNhanvien.Columns["Lương"].DefaultCellStyle.Format = "c0";
        }
        public void PhanQuyen(string Quyen)
        {
            if (Quyen.Equals("CONGTY"))
            {
                btnChuyenCN.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnUndo.Enabled = false;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }
        }

        void uctNhanvien_Load(object sender, EventArgs e)
        {
            LoadData();
            SetUp(sender, e);
        }

        private void LoadData()
        {
            dGVDSNhanvien.DataSource = Controllers.NhanVienCtrl.FillDataSetNhanVien().Tables[0];
        }
        private void SetUp(object sender, EventArgs e)
        {
            HienThiDSNhanVien();
            dGVDSNhanvien.Enabled = true;
            binding();
            dis_end(true);
            PhanQuyen(frmMain._quyen);
            button2_Click(sender, e);
        }

        void binding()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dGVDSNhanvien.DataSource, "Mã NV");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dGVDSNhanvien.DataSource, "Tên");
            txtHo.DataBindings.Clear();
            txtHo.DataBindings.Add("Text", dGVDSNhanvien.DataSource, "Họ");
            dTPNgaySinh.DataBindings.Clear();
            dTPNgaySinh.DataBindings.Add("Text", dGVDSNhanvien.DataSource, "Ngày sinh");
            txtLuong.DataBindings.Clear();
            txtLuong.DataBindings.Add("Text", dGVDSNhanvien.DataSource, "Lương");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dGVDSNhanvien.DataSource, "Địa chỉ");
        }

        void dis_end(bool e)
        {
            txtHo.Enabled = !e;
            txtTen.Enabled = !e;
            txtDiaChi.Enabled = !e;
            txtLuong.Enabled = !e;
            dTPNgaySinh.Enabled = !e;
            btnChuyenCN.Enabled = e;
            btnThem.Enabled = e;
            btnXoa.Enabled = e;
            btnReload.Enabled = e;
            btnBoLoc.Enabled = e;
            button2.Enabled = e;
            disUndo();
            disRedo();
            btnHuy.Enabled = !e;
            btnLuu.Enabled = !e;
        }

        void clear_data()
        {
            txtDiaChi.DataBindings.Clear();
            txtHo.DataBindings.Clear();
            txtLuong.DataBindings.Clear();
            txtMaNV.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            dTPNgaySinh.DataBindings.Clear();

            txtMaNV.Text = Connection.ExcuteScalar(string.Format("select MaNV = dbo.fc_GetMaNV()"));
            txtDiaChi.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtLuong.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetUp(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear_data();
            dis_end(false);
            button2_Click(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int _MaNV = 0;
            try
            {
                _MaNV = Convert.ToInt32(txtMaNV.Text);
            }
            catch { }

            string _Ho = "";
            try
            {
                _Ho = txtHo.Text.Trim(' ');
            }
            catch { }

            string _Ten = "";
            try
            {
                _Ten = txtTen.Text.Trim(' ');
            }
            catch { }

            DateTime _NgaySinh = new DateTime();
            try
            {
                _NgaySinh = dTPNgaySinh.Value;
            }
            catch { }

            float _Luong = 0f;
            try
            {
                _Luong = float.Parse(txtLuong.Text.Replace(",", "").Replace("$", ""));
            }
            catch { }

            string _DiaChi = "";
            try
            {
                _DiaChi = txtDiaChi.Text.Trim(' ');
            }
            catch { }

            if (_Ten == "")
            {
                XtraMessageBox.Show("Tên không được bỏ trống !");
            }
            else if (txtLuong.Text.Trim(' ') == "")
            {
                XtraMessageBox.Show("Lương không được bỏ trống !");
            }
            else if (_Luong < 4000000)
            {
                XtraMessageBox.Show("Vui lòng nhập lương >= 4000000 !");
            }
            else
            {
                int i = 0;
                i = Controllers.NhanVienCtrl.InsertNhanVien(_MaNV, _Ho, _Ten, _DiaChi, _NgaySinh, _Luong, frmMain._CN, 0);
                if (i == 0)
                {
                    string str = "NHANVIEN," + txtMaNV.Text;
                    addActUndo(str, Act.ActType.INSERT);
                    redoList.Clear();
                    MessageBox.Show("Thêm thành công !");
                    uctNhanvien_Load(sender, e);
                    btnThem_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }
            }

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            filter = "";
            uctNhanvien_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int _MaNV = -1;
            try
            {
                _MaNV = Convert.ToInt32(txtMaNV.Text);
            }
            catch { }

            if (_MaNV == -1)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ !");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controllers.NhanVienCtrl.DeleteNhanVien(_MaNV);
                if (i == 0)
                {
                    string str = "NHANVIEN," + txtMaNV.Text;
                    //undoList.Push(new Act(Act.ActType.DELETE, str));
                    //disUndo();
                    addActUndo(str, Act.ActType.DELETE);
                    redoList.Clear();
                    MessageBox.Show("Xóa thành công !");
                    uctNhanvien_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !");
                }
            }
        }
        private void addActUndo(string str, Act.ActType type)
        {
            undoList.Push(new Act(type, str));
            disUndo();
        }
        private void addActRedo(string str, Act.ActType type)
        {
            redoList.Push(new Act(type, str));
            disRedo();
        }
        private void btnChuyenCN_Click(object sender, EventArgs e)
        {
            int _MaNV = 0;
            try
            {
                _MaNV = Convert.ToInt32(txtMaNV.Text);
            }
            catch { }

            int _MaNV_new = 0;

            if (_MaNV > 0)
            {
                //confirm
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn chuyển nhân viên có mã " + _MaNV + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //get new id
                    try
                    {
                        _MaNV_new = Convert.ToInt32(Connection.ExcuteScalar(string.Format("select MaNV = dbo.fc_GetMaNV()")));
                    }
                    catch
                    {
                        MessageBox.Show("Chuyển thất bại !");
                        return;
                    }

                    string manv = txtMaNV.Text;
                    int i = Controllers.NhanVienCtrl.ChuyenChiNhanh(_MaNV, _MaNV_new);
                    uctNhanvien_Load(sender, e);
                    if (i == 0)
                    {
                        string str = "NHANVIEN," + manv;
                        //undoList.Push(new Act(Act.ActType.CHUYENCN, str));
                        //disUndo();
                        addActUndo(str, Act.ActType.CHUYENCN);
                        MessageBox.Show("Chuyển thành công !");
                    }
                    else if (i == 2)
                    {
                        MessageBox.Show("Chuyển thành công, xóa login + user thất bại !");
                    }
                    else if (i == 1)
                    {
                        MessageBox.Show("Chuyển thất bại !");
                    }
                }
            }
        }

            public void disUndo()
            {
                if (undoList.Count > 0)
                {
                    btnUndo.Enabled = true;
                }
                else
                {
                    btnUndo.Enabled = false;
                }
            }
            public void disRedo()
            {
                if (redoList.Count > 0)
                {
                    btnRedo.Enabled = true;
                }
                else
                {
                    btnRedo.Enabled = false;
                }
            }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void dis_filter(bool e)
        {
            cbbLoc.Visible = !e;
            txtLoc.Visible = !e;
            btnLoc.Visible = !e;
        }
        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            dis_filter(false);
            cbbLoc.Items.Clear();
            cbbLoc.Items.Add("Tên");
            cbbLoc.Items.Add("Họ");
            cbbLoc.Items.Add("Địa chỉ");
            cbbLoc.Items.Add("Lương");
            cbbLoc.Items.Add("Ngày sinh");
            cbbLoc.SelectedIndex = cbbLoc.Items.Count - 1;
            cbbLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            txtLoc_Leave(sender, e);
            txtLocPhu_Leave(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filter = "";
            applyFilter(filter, dGVDSNhanvien);
            dis_filter(true);
            dis_all_filter(true);
            resetfilter();
            txtLocPhu.Visible = false;
        }
        private void dis_all_filter(bool e)
        {
            cbbCompare1.Visible = !e;
            cbbCompare2.Visible = !e;
            cbbLoc.Visible = !e;
            dtpStart.Visible = !e;
            dtpEnd.Visible = !e;
            txtLoc.Visible = !e;
            txtLocPhu.Visible = !e;
            btnLoc.Visible = !e;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            Regex rg1 = new Regex(@"^\d{1,}$");
            if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Lương".ToUpper()))
            {
                long x;
                if (Int64.TryParse(txtLoc.Text.Replace(",", "").Replace("$", ""), out x) && Int64.TryParse(txtLocPhu.Text.Replace(",", "").Replace("$", ""), out x))
                {
                    filter = "[" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare1.Text + txtLoc.Text.Replace(",", "").Replace("$", "") +
                        " AND [" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare2.Text + txtLocPhu.Text.Replace(",", "").Replace("$", "");
                }
                else
                {
                    MessageBox.Show("Nhập sai định dạng !");
                }
            }
            else if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Ngày sinh".ToUpper()))
            {
                //Regex rg2 = new Regex(@"^(>=|<=|=|>|<)\#([1-9]|([0-1][0-2]))\-(([1-9])|([0-2][0-9])|([3][0-1]))\-\d{4}\#$");
                filter = "[" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare1.Text + "#" + dtpStart.Value.Month + "-" + dtpStart.Value.Day + "-" + dtpStart.Value.Year + "#" +
                    " AND [" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare2.Text + "#" + dtpEnd.Value.Month + "-" + dtpEnd.Value.Day + "-" + dtpEnd.Value.Year + "#";
            }
            else if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Mã NV".ToUpper()))
            {
                if (rg1.IsMatch(txtLoc.Text))
                {
                    filter = "[" + cbbLoc.SelectedItem.ToString() + "]" + "=" + txtLoc.Text;
                }
                else
                {
                    MessageBox.Show("Nhập sai định dạng !");
                }
            }
            else
            {
                filter = "[" + cbbLoc.SelectedItem.ToString() + "] LIKE '%" + txtLoc.Text + "%'";
            }
            applyFilter(filter, dGVDSNhanvien);
            //uctNhanvien_Load(sender, e);
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
        private void resetfilter()
        {
            txtLoc.Text = "";
            txtLocPhu.Text = "";
        }
        private void cbbLoc_TextChanged(object sender, EventArgs e)
        {
            if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Lương".ToUpper()))
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
            else if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Ngày sinh".ToUpper()))
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
                if (cbbLoc.Text == "Mã NV")
                {
                    txtLoc.Text = "VD: 3";
                }
                if (cbbLoc.Text == "Họ")
                {
                    txtLoc.Text = "VD: Nguyễn";
                }
                if (cbbLoc.Text == "Tên")
                {
                    txtLoc.Text = "VD: Ngọc";
                }
                if (cbbLoc.Text == "Địa chỉ")
                {
                    txtLoc.Text = "VD: Đồng Nai";
                }
                if (cbbLoc.Text == "Lương")
                {
                    txtLoc.Text = "VD: 5000000";
                }
                txtLoc.ForeColor = Color.Silver;
            }
        }

        private void txtLoc_Enter(object sender, EventArgs e)
        {
            if (txtLoc.Text == "VD: 3" || txtLoc.Text == "VD: Nguyễn" || txtLoc.Text == "VD: Ngọc" ||
                txtLoc.Text == "VD: 5000000" || txtLoc.Text == "VD: Đồng Nai")
            {
                txtLoc.Text = "";
                txtLoc.ForeColor = Color.Black;
            }
        }

        private void txtLocPhu_Leave(object sender, EventArgs e)
        {
            if (txtLocPhu.Text.Trim(' ') == "")
            {
                if (cbbLoc.Text == "Mã NV")
                {
                    txtLocPhu.Text = "VD: 3";
                }
                if (cbbLoc.Text == "Họ")
                {
                    txtLocPhu.Text = "VD: Nguyễn";
                }
                if (cbbLoc.Text == "Tên")
                {
                    txtLocPhu.Text = "VD: Ngọc";
                }
                if (cbbLoc.Text == "Địa chỉ")
                {
                    txtLocPhu.Text = "VD: Đồng Nai";
                }
                if (cbbLoc.Text == "Lương")
                {
                    txtLocPhu.Text = "VD: 5000000";
                }
                txtLocPhu.ForeColor = Color.Silver;
            }
        }

        private void txtLocPhu_Enter(object sender, EventArgs e)
        {
            if (txtLocPhu.Text == "VD: 3" || txtLocPhu.Text == "VD: Nguyễn" || txtLocPhu.Text == "VD: Ngọc" ||
                txtLocPhu.Text == "VD: 5000000" || txtLocPhu.Text == "VD: Đồng Nai")
            {
                txtLocPhu.Text = "";
                txtLocPhu.ForeColor = Color.Black;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                if (undoList.Count > 0)
                {
                    if (undoList.Peek().Undo() != 0)
                    {
                        MessageBox.Show("Có lỗi xảy ra !");
                    }
                    else
                    {
                        addActRedo(undoList.Peek().GetParameters(), undoList.Peek().GetType() == Act.ActType.INSERT ? Act.ActType.DELETE : Act.ActType.INSERT);
                        undoList.Pop();
                        uctNhanvien_Load(sender, e);
                    }
                }
            }
            catch (Exception) { }
            disUndo();
        }
        private void btnRedo_Click(object sender, EventArgs e)
        {
            try
            {
                if (redoList.Count > 0)
                {
                    if (redoList.Peek().Undo() != 0)
                    {
                        MessageBox.Show("Có lỗi xảy ra !");
                    }
                    else
                    {
                        addActUndo(redoList.Peek().GetParameters(), redoList.Peek().GetType() == Act.ActType.INSERT ? Act.ActType.DELETE : Act.ActType.INSERT);
                        redoList.Pop();
                        uctNhanvien_Load(sender, e);
                    }
                }
            }
            catch (Exception) { }
            disRedo();
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            if (cbbLoc.Text.Equals("Lương"))
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
            if (cbbLoc.Text.Equals("Lương"))
            {
                try
                {
                    txtLocPhu.Text = "$" + String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtLocPhu.Text.Replace(",", "").Replace("$", "")));
                    txtLocPhu.SelectionStart = txtLocPhu.Text.Length;
                }
                catch { }

            }
        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtLuong.Text = "$" + String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtLuong.Text.Replace(",", "").Replace("$", "")));
                txtLuong.SelectionStart = txtLuong.Text.Length;
            }
            catch { }
        }
        private void isDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbLoc.Text.Equals("Số lượng tồn"))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
