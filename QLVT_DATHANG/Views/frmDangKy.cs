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

namespace QLVT_DATHANG
{
    public partial class frmDangKy1 : DevExpress.XtraEditors.XtraForm
    {
        public frmDangKy1()
        {
            InitializeComponent();
        }

        private void frmDangKy1_Load(object sender, EventArgs e)
        {
            cbbMaNV.DataSource = null;
            if (frmMain._CN.Trim(' ').Equals("CN2"))
            {
                this.v_DS_NhanVienTableAdapter1.Fill(this.qLVT_DHDataSet_CN2.v_DS_NhanVien);
                cbbMaNV.DataSource = qLVT_DHDataSet_CN2.v_DS_NhanVien;
            }
            else if (frmMain._CN.Trim(' ').Equals("CN1"))
            {
                this.v_DS_NhanVienTableAdapter.Fill(this.qLVT_DHDataSet_CN1.v_DS_NhanVien);
                cbbMaNV.DataSource = qLVT_DHDataSet_CN1.v_DS_NhanVien;
            }
            cbbMaNV.DisplayMember = "TEN";
            cbbMaNV.ValueMember = "MANV";
            if (frmMain._quyen.Equals("CONGTY"))
            {
                cbbQuyen.Items.Clear();
                cbbQuyen.Items.Add("CONGTY");
                cbbQuyen.SelectedIndex = cbbQuyen.Items.Count - 1;
            }
            if (frmMain._quyen.Equals("CHINHANH"))
            {
                cbbQuyen.Items.Clear();
                cbbQuyen.Items.Add("CHINHANH");
                cbbQuyen.Items.Add("USER");
                cbbQuyen.SelectedIndex = cbbQuyen.Items.Count - 1;
            }
        }
    }
}