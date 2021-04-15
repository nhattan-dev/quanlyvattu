using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class xrp_TH_NhapXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public xrp_TH_NhapXuat(DateTime Start, DateTime End)
        {
            InitializeComponent();
            if (frmMain._CN.Trim(' ').Equals("CN1"))
            {
                qlvT_DHDataSet_CN11.EnforceConstraints = false;
                DataSource = qlvT_DHDataSet_CN11;
                DataAdapter = sp_HoatDongNhanVienByTimeTableAdapter_CN1;
                sp_HoatDongNhanVienByTimeTableAdapter_CN1.Fill(qlvT_DHDataSet_CN11.sp_HoatDongNhanVienByTime, Start, End);
            }
            else if (frmMain._CN.Trim(' ').Equals("CN2"))
            {
                qlvT_DHDataSet_CN21.EnforceConstraints = false;
                DataSource = qlvT_DHDataSet_CN21;
                DataAdapter = sp_HoatDongNhanVienByTimeTableAdapter_CN2;
                sp_HoatDongNhanVienByTimeTableAdapter_CN2.Fill(qlvT_DHDataSet_CN21.sp_HoatDongNhanVienByTime, Start, End);
            }
        }
        QLVT_DHDataSet_CN1TableAdapters.sp_HoatDongNhanVienByTimeTableAdapter sp_HoatDongNhanVienByTimeTableAdapter_CN1 = new QLVT_DATHANG.QLVT_DHDataSet_CN1TableAdapters.sp_HoatDongNhanVienByTimeTableAdapter();
        QLVT_DHDataSet_CN2TableAdapters.sp_HoatDongNhanVienByTimeTableAdapter sp_HoatDongNhanVienByTimeTableAdapter_CN2 = new QLVT_DATHANG.QLVT_DHDataSet_CN2TableAdapters.sp_HoatDongNhanVienByTimeTableAdapter();
    }
}
