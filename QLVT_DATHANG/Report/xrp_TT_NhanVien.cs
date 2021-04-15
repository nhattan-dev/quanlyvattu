using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class xrp_TT_NhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public xrp_TT_NhanVien(int MaNV, DateTime Start, DateTime End)
        {
            InitializeComponent();
            if (frmMain._CN.Trim(' ').Equals("CN1"))
            {
                DataSource = qlvT_DHDataSet_CN11;
                DataAdapter = sp_ThongTinNhanVienTableAdapter_CN1;
                sp_ThongTinNhanVienTableAdapter_CN1.Fill(qlvT_DHDataSet_CN11.sp_ThongTinNhanVien, MaNV, Start, End);
            }
            else if (frmMain._CN.Trim(' ').Equals("CN2"))
            {
                DataSource = qlvT_DHDataSet_CN21;
                DataAdapter = sp_ThongTinNhanVienTableAdapter_CN2;
                sp_ThongTinNhanVienTableAdapter_CN2.Fill(qlvT_DHDataSet_CN21.sp_ThongTinNhanVien, MaNV, Start, End);
            }
        }
        QLVT_DHDataSet_CN1TableAdapters.sp_ThongTinNhanVienTableAdapter sp_ThongTinNhanVienTableAdapter_CN1 = new QLVT_DATHANG.QLVT_DHDataSet_CN1TableAdapters.sp_ThongTinNhanVienTableAdapter();
        QLVT_DHDataSet_CN2TableAdapters.sp_ThongTinNhanVienTableAdapter sp_ThongTinNhanVienTableAdapter_CN2 = new QLVT_DATHANG.QLVT_DHDataSet_CN2TableAdapters.sp_ThongTinNhanVienTableAdapter();
    }
}
