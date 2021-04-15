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
using System.Text.RegularExpressions;
using QLVT_DATHANG.Models;
using System.Globalization;

namespace QLVT_DATHANG.Views
{
    public partial class uctVatTu : UserControl
    {
        public uctVatTu()
        {
            InitializeComponent();
        }

        private static string filter;
        internal static Stack<Act> undoList = new Stack<Act>();
        internal static Stack<Act> redoList = new Stack<Act>();
        public static uctVatTu uctVT = new uctVatTu();

        private void LoadData()
        {
            dGVDSVatTu.DataSource = Controllers.VatTuCtrl.FillDataSetVatTu().Tables[0];
        }
        private void HienThiDSVatTu()
        {
            applyFilter(filter, dGVDSVatTu);
            dGVDSVatTu.Dock = DockStyle.Fill;
            dGVDSVatTu.BorderStyle = BorderStyle.Fixed3D;
            dGVDSVatTu.RowHeadersVisible = false;
            FormatData(); 
            TextAlignment();
        }
        private void TextAlignment()
        {
            //format
            this.dGVDSVatTu.Columns["Số lượng tồn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSVatTu.Columns["Tên VT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSVatTu.Columns["Mã VT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSVatTu.Columns["Đơn vị tính"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //format
            this.dGVDSVatTu.Columns["Số lượng tồn"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dGVDSVatTu.Columns["Tên VT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dGVDSVatTu.Columns["Mã VT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dGVDSVatTu.Columns["Đơn vị tính"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void FormatData()
        {
            //format
            this.dGVDSVatTu.Columns["Số lượng tồn"].DefaultCellStyle.Format = "0,0";
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
        private void uctVatTu_Load(object sender, EventArgs e)
        {
            LoadData();
            SetUp(sender, e);
        }

        private void SetUp(object sender, EventArgs e)
        {
            HienThiDSVatTu();
            dGVDSVatTu.Enabled = true;
            binding();
            dis_end(true);
            PhanQuyen(frmMain._quyen);
            button2_Click(sender, e);
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
            txtDVT.Enabled = !e;
            txtTenVT.Enabled = !e;
            txtSoLuongTon.Enabled = !e;
            btnThem.Enabled = e;
            btnXoa.Enabled = e;
            btnBoLoc.Enabled = e;
            button2.Enabled = e;
            btnReload.Enabled = e;
            disUndo();
            disRedo();
            btnHuy.Enabled = !e;
            btnLuu.Enabled = !e;
        }

        private void binding()
        {
            txtMaVT.DataBindings.Clear();
            txtMaVT.DataBindings.Add("Text", dGVDSVatTu.DataSource, "Mã VT");
            txtTenVT.DataBindings.Clear();
            txtTenVT.DataBindings.Add("Text", dGVDSVatTu.DataSource, "Tên VT");
            txtDVT.DataBindings.Clear();
            txtDVT.DataBindings.Add("Text", dGVDSVatTu.DataSource, "Đơn vị tính");
            txtSoLuongTon.DataBindings.Clear();
            txtSoLuongTon.DataBindings.Add("Text", dGVDSVatTu.DataSource, "Số lượng tồn");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear_data();
            dis_end(false);
            button2_Click(sender, e);
        }

        private void clear_data()
        {
            txtDVT.DataBindings.Clear();
            txtMaVT.DataBindings.Clear();
            txtSoLuongTon.DataBindings.Clear();
            txtTenVT.DataBindings.Clear();

            txtTenVT.Text = "";
            txtMaVT.Text = Connection.ExcuteScalar(string.Format("select MaVT = dbo.fc_GetMaVT()"));
            txtSoLuongTon.Text = "";
            txtDVT.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetUp(sender, e);
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
        private void btnReload_Click(object sender, EventArgs e)
        {
            filter = "";
            uctVatTu_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string _MaVT = "";
            try
            {
                _MaVT = txtMaVT.Text.Trim(' ');
            }
            catch { }

            string _TenVT = "";
            try
            {
                _TenVT = txtTenVT.Text.Trim(' ');
            }
            catch { }

            string _DVT = "";
            try
            {
                _DVT = txtDVT.Text.Trim(' ');
            }
            catch { }

            int _SoLuongTon = 0;
            try
            {
                _SoLuongTon = Convert.ToInt32(txtSoLuongTon.Text.Replace(",",""));
            }
            catch { }

            if (_MaVT == "")
            {
                MessageBox.Show("Mã vật tư không được để trống !");
            }
            else if (_TenVT == "")
            {
                MessageBox.Show("Tên vật tư không được để trống !");
            }
            else if (_DVT == "")
            {
                MessageBox.Show("Đơn vị tính không được để trống !");
            }
            else if (txtSoLuongTon.Text.Trim(' ').Equals(""))
            {
                MessageBox.Show("Số lượng không được để trống !");
            }
            else if (_SoLuongTon <= 0)
            {
                MessageBox.Show("Số lượng >= 0");
            }
            else
            {
                int k = VatTuCtrl.InsertVatTu(_MaVT, _TenVT, _DVT, _SoLuongTon);
                if (k == 0)
                {
                    MessageBox.Show("Thêm thành công !");
                    string str = "VATTU," + txtMaVT.Text + "," + txtDVT.Text + "," + txtTenVT.Text + "," + txtSoLuongTon.Text;
                    addActUndo(str, Act.ActType.INSERT);
                    redoList.Clear();
                    uctVatTu_Load(sender, e);
                    btnThem_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }
            }
        }

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaVT = "";
            try
            {
                _MaVT = txtMaVT.Text;
            }
            catch { }

            if (_MaVT == "")
            {
                MessageBox.Show("Mã vật tư không hợp lệ !");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = Controllers.VatTuCtrl.DeleteVatTu(_MaVT);
                if (i == 0)
                {
                    string str = "VATTU," + txtMaVT.Text + "," + txtDVT.Text + "," + txtTenVT.Text + "," + txtSoLuongTon.Text;
                    //undoList.Push(new Act(Act.ActType.DELETE, str));
                    //disUndo();
                    addActUndo(str, Act.ActType.DELETE);
                    redoList.Clear();
                    MessageBox.Show("Xóa thành công !");
                    uctVatTu_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !");
                }
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
                        uctVatTu_Load(sender, e);
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
                        uctVatTu_Load(sender, e);
                    }
                }
            }
            catch (Exception) { }
            disRedo();
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
            cbbLoc.Items.Add("Đơn vị tính");
            cbbLoc.Items.Add("Tên VT");
            cbbLoc.Items.Add("Số lượng tồn");
            cbbLoc.Items.Add("Mã VT");
            cbbLoc.SelectedIndex = cbbLoc.Items.Count - 1;
            cbbLoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void dis_all_filter(bool e)
        {
            cbbCompare1.Visible = !e;
            cbbCompare2.Visible = !e;
            cbbLoc.Visible = !e;
            txtLoc.Visible = !e;
            txtLocPhu.Visible = !e;
            btnLoc.Visible = !e;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            filter = "";
            applyFilter(filter, dGVDSVatTu);
            dis_filter(true);
            dis_all_filter(true);
            resetfilter();
            txtLocPhu.Visible = false;
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
        private void btnLoc_Click(object sender, EventArgs e)
        {
            Regex rg1 = new Regex(@"^\d{1,}$");
            if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Số lượng tồn".ToUpper()))
            {
                long x;
                if (Int64.TryParse(txtLoc.Text.Replace(",", ""), out x) && Int64.TryParse(txtLocPhu.Text.Replace(",", ""), out x))
                {
                    filter = "[" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare1.Text + txtLoc.Text.Replace(",", "") + 
                        " AND [" + cbbLoc.SelectedItem.ToString() + "]" + cbbCompare2.Text + txtLocPhu.Text.Replace(",", "");
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
            //uctVatTu_Load(sender, e);
            applyFilter(filter, dGVDSVatTu);
        }

        private void cbbLoc_TextChanged(object sender, EventArgs e)
        {
            if (cbbLoc.SelectedItem.ToString().ToUpper().Equals("Số lượng tồn".ToUpper()))
            {
                txtLoc.Visible = true;
                txtLocPhu.Visible = true;
                cbbCompare1.Visible = true;
                cbbCompare2.Visible = true;
                cbbCompare1.SelectedIndex = cbbCompare1.Items.Count - 1;
                cbbCompare2.SelectedIndex = cbbCompare2.Items.Count - 1;
            }
            else
            {
                txtLoc.Visible = true;
                txtLocPhu.Visible = false;
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
                if (cbbLoc.Text == "Số lượng tồn")
                {
                    txtLoc.Text = "VD: 30";
                }
                if (cbbLoc.Text == "Tên VT")
                {
                    txtLoc.Text = "VD: Tủ lạnh";
                }
                if (cbbLoc.Text == "Đơn vị tính")
                {
                    txtLoc.Text = "VD: Cái";
                }
                if (cbbLoc.Text == "Mã VT")
                {
                    txtLoc.Text = "VD: VT10";
                }
                txtLoc.ForeColor = Color.Silver;
            }
        }

        private void txtLoc_Enter(object sender, EventArgs e)
        {
            if (txtLoc.Text == "VD: 30" || txtLoc.Text == "VD: Tủ lạnh" || txtLoc.Text == "VD: VT10" ||
                txtLoc.Text == "VD: Cái")
            {
                txtLoc.Text = "";
                txtLoc.ForeColor = Color.Black;
            }
        }

        private void txtLocPhu_Leave(object sender, EventArgs e)
        {
            if (txtLocPhu.Text.Trim(' ') == "")
            {
                if (cbbLoc.Text == "Số lượng tồn")
                {
                    txtLocPhu.Text = "VD: 30";
                }
                if (cbbLoc.Text == "Tên VT")
                {
                    txtLocPhu.Text = "VD: Tủ lạnh";
                }
                if (cbbLoc.Text == "Đơn vị tính")
                {
                    txtLocPhu.Text = "VD: Cái";
                }
                if (cbbLoc.Text == "Mã VT")
                {
                    txtLocPhu.Text = "VD: VT10";
                }
                txtLocPhu.ForeColor = Color.Silver;
            }
        }

        private void txtLocPhu_Enter(object sender, EventArgs e)
        {
            if (txtLocPhu.Text == "VD: 30" || txtLocPhu.Text == "VD: Tủ lạnh" || txtLocPhu.Text == "VD: VT10" ||
                txtLocPhu.Text == "VD: Cái")
            {
                txtLocPhu.Text = "";
                txtLocPhu.ForeColor = Color.Black;
            }
        }
        private void resetfilter()
        {
            txtLoc.Text = "";
            txtLocPhu.Text = "";
        }

        private void txtSoLuongTon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtSoLuongTon.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtSoLuongTon.Text.Replace(",","")));
                txtSoLuongTon.SelectionStart = txtSoLuongTon.Text.Length;
            }
            catch { }
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            if (cbbLoc.Text.Equals("Số lượng tồn"))
            {
                try
                {
                    txtLoc.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtLoc.Text.Replace(",", "")));
                    txtLoc.SelectionStart = txtLoc.Text.Length;
                }
                catch { }
            }
        }

        private void txtLocPhu_TextChanged(object sender, EventArgs e)
        {
            if (cbbLoc.Text.Equals("Số lượng tồn"))
            {
                try
                {
                    txtLocPhu.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0}", Int64.Parse(txtLocPhu.Text.Replace(",", "")));
                    txtLocPhu.SelectionStart = txtLocPhu.Text.Length;
                }
                catch { }
                
            }
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
