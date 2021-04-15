using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class xrp_SLTG_PhieuXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public xrp_SLTG_PhieuXuat(string Group, DateTime Start, DateTime End)
        {
            InitializeComponent();
            if (frmMain._CN.Trim(' ').Equals("CN1"))
            {
                qlvT_DHDataSet_CN11.EnforceConstraints = false;
                DataSource = qlvT_DHDataSet_CN11;
                DataAdapter = sp_SLTG_PhieuXuatTableAdapter_CN1;
                sp_SLTG_PhieuXuatTableAdapter_CN1.Fill(qlvT_DHDataSet_CN11.sp_SLTG_PhieuXuat, Group, Start, End);
            }
            else if (frmMain._CN.Trim(' ').Equals("CN2"))
            {
                qlvT_DHDataSet_CN21.EnforceConstraints = false;
                DataSource = qlvT_DHDataSet_CN21;
                DataAdapter = sp_SLTG_PhieuXuatTableAdapter_CN2;
                sp_SLTG_PhieuXuatTableAdapter_CN2.Fill(qlvT_DHDataSet_CN21.sp_SLTG_PhieuXuat, Group, Start, End);
            }
        }
        QLVT_DHDataSet_CN1TableAdapters.sp_SLTG_PhieuXuatTableAdapter sp_SLTG_PhieuXuatTableAdapter_CN1 = new QLVT_DATHANG.QLVT_DHDataSet_CN1TableAdapters.sp_SLTG_PhieuXuatTableAdapter();
        QLVT_DHDataSet_CN2TableAdapters.sp_SLTG_PhieuXuatTableAdapter sp_SLTG_PhieuXuatTableAdapter_CN2 = new QLVT_DATHANG.QLVT_DHDataSet_CN2TableAdapters.sp_SLTG_PhieuXuatTableAdapter();
    }
}
