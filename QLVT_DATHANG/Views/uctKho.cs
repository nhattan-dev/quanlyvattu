using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLVT_DATHANG.Controllers;
using QLVT_DATHANG.Models;

namespace QLVT_DATHANG.Views
{
    public partial class uctKho : UserControl
    {
        public uctKho()
        {
            InitializeComponent();
        }

        public static uctKho uctK = new uctKho();
        internal static Stack<Act> undoList = new Stack<Act>();
        internal static Stack<Act> redoList = new Stack<Act>();
        private static string filter = "";
        internal void HienThiDSKho()
        {
            try
            {
                (dGVDSKho.DataSource as DataTable).DefaultView.RowFilter = filter;
            }
            catch (Exception)
            {
                (dGVDSKho.DataSource as DataTable).DefaultView.RowFilter = "";
            }
            dGVDSKho.Dock = DockStyle.Fill;
            dGVDSKho.BorderStyle = BorderStyle.Fixed3D;
            dGVDSKho.RowHeadersVisible = false;
            TextAlignment();
        }
        private void TextAlignment()
        {
            //format
            this.dGVDSKho.Columns["Mã kho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSKho.Columns["Tên kho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSKho.Columns["Địa chỉ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSKho.Columns["Mã chi nhánh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //header
            this.dGVDSKho.Columns["Mã kho"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSKho.Columns["Tên kho"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSKho.Columns["Địa chỉ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSKho.Columns["Mã chi nhánh"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void PhanQuyen(string quyen)
        {
            if (quyen.Equals("CONGTY"))
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnUndo.Enabled = false;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }
        }

        private void dis_end(bool e)
        {
            txtDiaChi.Enabled = !e;
            txtMaKho.Enabled = !e;
            txtTenKho.Enabled = !e;
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

        private void binding()
        {
            txtMaCN.DataBindings.Clear();
            txtMaCN.DataBindings.Add("Text", dGVDSKho.DataSource, "Mã chi nhánh");
            txtMaKho.DataBindings.Clear();
            txtMaKho.DataBindings.Add("Text", dGVDSKho.DataSource, "Mã kho");
            txtTenKho.DataBindings.Clear();
            txtTenKho.DataBindings.Add("Text", dGVDSKho.DataSource, "Tên kho");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dGVDSKho.DataSource, "Địa chỉ");
        }


        private void clear_data()
        {
            txtMaCN.DataBindings.Clear();
            txtMaKho.DataBindings.Clear();
            txtTenKho.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();

            txtMaCN.Text = frmMain._CN;
            txtMaKho.Text = "";
            txtTenKho.Text = "";
            txtDiaChi.Text = "";
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

        private void SetUp(object sender, EventArgs e)
        {
            HienThiDSKho();
            dGVDSKho.Enabled = true;
            binding();
            dis_end(true);
            PhanQuyen(frmMain._quyen);
            button2_Click(sender, e);
        }

        private void LoadData()
        {
            dGVDSKho.DataSource = Controllers.KhoCtrl.FillDataSetKho().Tables[0];
        }
        private void uctKho_Load(object sender, EventArgs e)
        {
            LoadData();
            SetUp(sender, e);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            clear_data();
            dis_end(false);
            button2_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaKho = "";
            try
            {
                _MaKho = txtMaKho.Text;
            }
            catch { }
            if (_MaKho == "")
            {
                MessageBox.Show("Mã kho không hợp lệ !");
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controllers.KhoCtrl.DeleteKho(_MaKho);
                if (i == 0)
                {
                    string _CN = Connection.ExcuteScalar(string.Format("select MaCN = dbo.fc_GetMaCN()")).Trim();
                    string str = "KHO," + txtMaKho.Text + "," + txtTenKho.Text + "," + txtDiaChi.Text + "," + _CN;
                    //undoList.Push(new Act(Act.ActType.DELETE, str));
                    //disUndo();
                    addActUndo(str, Act.ActType.DELETE);
                    //clear redoList
                    redoList.Clear();
                    MessageBox.Show("Xóa thành công !");
                    uctKho_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !");
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            filter = "";
            uctKho_Load(sender, e);
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
                        uctKho_Load(sender, e);
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
                        uctKho_Load(sender, e);
                    }
                }
            }
            catch (Exception) { }
            disRedo();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string _MaKho = "";
            try
            {
                _MaKho = txtMaKho.Text.Trim(' ');
            }
            catch { }

            string _TenKho = "";
            try
            {
                _TenKho = txtTenKho.Text.Trim(' ');
            }
            catch { }

            string _DiaChi = "";
            try
            {
                _DiaChi = txtDiaChi.Text.Trim(' ');
            }
            catch { }

            string _MaCN = "";
            try
            {
                _MaCN = txtMaCN.Text.Trim(' ');
            }
            catch { }

            if (_MaCN == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống !");
            }
            else if (_TenKho == "")
            {
                MessageBox.Show("Tên không được để trống !");
            }
            else if (_MaKho == "")
            {
                MessageBox.Show("Mã kho không được để trống !");
            }
            else if (_MaKho.Length == 4)
            {
                MessageBox.Show("Mã kho phải dài 4 kí tự !");
            }
            else if (Controllers.KhoCtrl.KhoTonTai_all(_MaKho) == 0)
            {
                MessageBox.Show("Mã kho đã được sử dụng !");
            }
            else
            {
                int k = KhoCtrl.InsertKho(_MaKho, _TenKho, _DiaChi, _MaCN);
                if (k == 0)
                {
                    MessageBox.Show("Thêm thành công !");
                    string str = "KHO," + txtMaKho.Text + "," + txtTenKho.Text + "," + txtDiaChi.Text + "," + frmMain._CN;
                    addActUndo(str, Act.ActType.INSERT);
                    //clear redoList
                    redoList.Clear();
                    uctKho_Load(sender, e);
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

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            dis_filter(false);
            cbbLoc.Items.Clear();
            cbbLoc.Items.Add("Tên kho");
            cbbLoc.Items.Add("Địa chỉ");
            cbbLoc.Items.Add("Mã kho");
            cbbLoc.SelectedIndex = cbbLoc.Items.Count - 1;
            cbbLoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void dis_filter(bool e)
        {
            cbbLoc.Visible = !e;
            txtLoc.Visible = !e;
            btnLoc.Visible = !e;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            filter = "";
            applyFilter(filter, dGVDSKho);
            dis_filter(true);
            txtLoc.Text = "";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (txtLoc.Text.Trim(' ') == "")
            {
                MessageBox.Show("Vui lòng nhập giá trị lọc !");
            }
            else
            {
                filter = "[" + cbbLoc.SelectedItem.ToString() + "] LIKE '%" + txtLoc.Text + "%'";
                //SetUp(sender, e);
                applyFilter(filter, dGVDSKho);
                //uctKho_Load(sender, e);
            }
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
        private void txtLoc_Leave(object sender, EventArgs e)
        {
            if (txtLoc.Text.Trim(' ') == "")
            {
                if (cbbLoc.Text == "Tên kho")
                {
                    txtLoc.Text = "VD: KHO Tổng";
                }
                if (cbbLoc.Text == "Địa chỉ")
                {
                    txtLoc.Text = "VD: Ninh Thuận";
                }
                if (cbbLoc.Text == "Mã kho")
                {
                    txtLoc.Text = "VD: H3N1";
                }
                txtLoc.ForeColor = Color.Silver;
            }
        }

        private void txtLoc_Enter(object sender, EventArgs e)
        {
            if (txtLoc.Text == "VD: H3N1" || txtLoc.Text == "VD: KHO Tổng" || txtLoc.Text == "VD: Ninh Thuận")
            {
                txtLoc.Text = "";
                txtLoc.ForeColor = Color.Black;
            }
        }

        private void cbbLoc_TextChanged(object sender, EventArgs e)
        {
            txtLoc.Text = "";
            txtLoc_Leave(sender, e);
        }

    }
}
