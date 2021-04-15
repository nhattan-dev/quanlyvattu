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

namespace QLVT_DATHANG.Views
{
    public partial class frmHoatDongNV : DevExpress.XtraEditors.XtraForm
    {
        public frmHoatDongNV()
        {
            InitializeComponent();
        }

        private void frmHoatDongNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN2.v_DS_NhanVien' table. You can move, or remove it, as needed.
            this.v_DS_NhanVienTableAdapter1.Fill(this.qLVT_DHDataSet_CN2.v_DS_NhanVien);
            // TODO: This line of code loads data into the 'qLVT_DHDataSet_CN1.v_DS_NhanVien' table. You can move, or remove it, as needed.
            this.v_DS_NhanVienTableAdapter.Fill(this.qLVT_DHDataSet_CN1.v_DS_NhanVien);
            string _CN = Connection.ExcuteScalar(string.Format("select MaCN = dbo.fc_GetMaCN()"));
            if (_CN.ToUpper().Trim().Equals("CN1".ToUpper()))
            {
                cbbMaNV.DataSource = qLVT_DHDataSet_CN1.v_DS_NhanVien;
            }
            else if (_CN.ToUpper().Trim().Equals("CN2".ToUpper()))
            {
                cbbMaNV.DataSource = qLVT_DHDataSet_CN2.v_DS_NhanVien;
            }
            cbbMaNV.DisplayMember = "MANV";
            cbbMaNV.ValueMember = "TEN";
            cbbMaNV_TextChanged(sender, e);
        }

        private void cbbMaNV_TextChanged(object sender, EventArgs e)
        {
            if (cbbMaNV.SelectedValue != null)
            {
                txtTen.Text = cbbMaNV.SelectedValue.ToString();
            }
        }
    }
}