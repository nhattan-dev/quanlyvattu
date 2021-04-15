using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Controllers
{
    class PhieuXuatCtrl
    {
        public static int InsertPhieuXuat(string _maPX, string _maKho, int _maNV, string _tenKH)
        {
            try
            {
                Models.PhieuXuatMod phieuXuat = new Models.PhieuXuatMod(_maPX, _maKho, _maNV, _tenKH);
                return phieuXuat.InsertPhieuXuat();
            }
            catch
            {
                return 1;
            }
        }

        public static int InsertCTPX(string _maPX, string _maVT, int _soLuong, float _donGia)
        {
            try
            {
                Models.PhieuXuatMod phieuXuat = new Models.PhieuXuatMod(_maPX, _maVT, _soLuong, _donGia);
                return phieuXuat.InsertCTPX();
            }
            catch
            {
                return 1;
            }
        }
        public static DataSet FillDataSetPhieuXuat()
        {
            try
            {
                return Models.PhieuXuatMod.FillDataSetPhieuXuat();
            }
            catch
            {
                return null;
            }
        }
        public static DataSet FillDataSetCTPX()
        {
            try
            {
                return Models.PhieuXuatMod.FillDataSetCTPX();
            }
            catch
            {
                return null;
            }
        }
        public static int DeletePhieuXuat(string _maPX)
        {
            try
            {
                Models.PhieuXuatMod phieuXuat = new Models.PhieuXuatMod(_maPX);
                return phieuXuat.DeletePhieuXuat();
            }
            catch
            {
                return 1;
            }
        }
    }
}
