using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class xrp_HD_NhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public xrp_HD_NhanVien()
        {
            InitializeComponent();
            if (frmMain._CN.Trim(' ').Equals("CN1"))
            {
                DataSource = qlvT_DHDataSet_CN11;
                DataAdapter = sp_HoatDongNhanVienTableAdapter_CN1;
                sp_HoatDongNhanVienTableAdapter_CN1.Fill(qlvT_DHDataSet_CN11.sp_HoatDongNhanVien);
            }
            else if (frmMain._CN.Trim(' ').Equals("CN2"))
            {
                DataSource = qlvT_DHDataSet_CN21;
                DataAdapter = sp_HoatDongNhanVienTableAdapter_CN2;
                sp_HoatDongNhanVienTableAdapter_CN2.Fill(qlvT_DHDataSet_CN21.sp_HoatDongNhanVien);
            }
        }
        QLVT_DHDataSet_CN1TableAdapters.sp_HoatDongNhanVienTableAdapter sp_HoatDongNhanVienTableAdapter_CN1 = new QLVT_DATHANG.QLVT_DHDataSet_CN1TableAdapters.sp_HoatDongNhanVienTableAdapter();
        QLVT_DHDataSet_CN2TableAdapters.sp_HoatDongNhanVienTableAdapter sp_HoatDongNhanVienTableAdapter_CN2 = new QLVT_DATHANG.QLVT_DHDataSet_CN2TableAdapters.sp_HoatDongNhanVienTableAdapter();
    }
}
