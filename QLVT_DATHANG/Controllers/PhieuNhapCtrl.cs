using System;
using System.Data;
using System.Windows.Forms;

namespace QLVT_DATHANG.Controllers
{
    internal class PhieuNhapCtrl
    {
        internal static DataSet FillDataSetPhieuNhap()
        {
            try
            {
                return Models.PhieuNhapMod.FillDataSetPhieuNhap();
            }
            catch
            {
                return null;
            }
        }
        internal static DataSet FillDataSetCTPN()
        {
            try
            {
                return Models.PhieuNhapMod.FillDataSetCTPN();
            }
            catch
            {
                return null;
            }
        }
        internal static DataSet FillDataSetThongTin(string maDDH)
        {
            try
            {
                Models.PhieuNhapMod phieuNhap = new Models.PhieuNhapMod(maDDH, "");
                return phieuNhap.FillDataSetThongTin();
            }
            catch
            {
                return null;
            }
        }

        internal static int DaNhapDDH(string maDDH)
        {
            try
            {
                Models.PhieuNhapMod phieuNhap = new Models.PhieuNhapMod(maDDH, "");
                return phieuNhap.DaNhapDDH();
            }
            catch
            {
                return 1;
            }
        }
        internal static int InsertPhieuNhap(string _maPN, string _maDDH, string _maKho, int _maNV)
        {
            try
            {
                Models.PhieuNhapMod phieuNhap = new Models.PhieuNhapMod(_maPN, _maDDH, _maKho, _maNV);
                return phieuNhap.InsertPhieuNhap();
            }
            catch
            {
                return 1;
            }
        }

        internal static int InsertCTPN(string _maPN, string _maVT, int _soLuong, float _donGia)
        {
            try
            {
                Models.PhieuNhapMod phieuNhap = new Models.PhieuNhapMod(_maPN, _maVT, _soLuong, _donGia);
                return phieuNhap.InsertCTPN();
            }
            catch
            {
                return 1;
            }
        }

        internal static int DeletePhieuNhap(string _maPN)
        {
            try
            {
                Models.PhieuNhapMod phieuNhap = new Models.PhieuNhapMod(_maPN);
                return phieuNhap.DeletePhieuNhap();
            }
            catch
            {
                return 1;
            }
        }
    }
}