using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Controllers
{
    class NhanVienCtrl
    {
        public static int DeleteNhanVien(int _MaNV)
        {
            try
            {
                Models.NhanVienMod _nhanVien = new Models.NhanVienMod(_MaNV);
                return _nhanVien.DeleteNhanVien();
            }
            catch { return 1; }
        }

        public static int InsertNhanVien(int _manv, string _ho, string _ten, string _diachi, DateTime _ngaysinh, float _luong, string _macn, int _trangthaixoa)
        {
            try
            {
                Models.NhanVienMod _nhanVien = new Models.NhanVienMod( _manv,  _ho,  _ten,  _diachi,  _ngaysinh,  _luong,  _macn,  _trangthaixoa);
                return _nhanVien.InsertNhanVien();
            }
            catch
            {
                return 1;   
            }
        }
        public static DataSet FillDataSetNhanVien()
        {
            try
            {
                return Models.NhanVienMod.FillDataSetNhanVien();
            }
            catch
            {
                return null;
            }
        }

        internal static int Restore(int manv)
        {
            try
            {
                Models.NhanVienMod nhanVien = new Models.NhanVienMod(manv);
                return nhanVien.Restore();
            }
            catch { return 1; }
        }

        public static DataSet GetInfo(string TenLogin)
        {
            try
            {
                return Models.NhanVienMod.getInfo(TenLogin);
            }
            catch
            {
                return null;
            }
        }

        public static int ChuyenChiNhanh(int _MaNV, int _MaNV_new)
        {
            try
            {
                Models.NhanVienMod _nhanVien = new Models.NhanVienMod(_MaNV);
                return _nhanVien.ChuyenChiNhanh(_MaNV_new);
            }
            catch
            {
                return 1;
            }
        }

        public static int Restore_ChuyenNV(string manv)
        {
            try
            {
                Models.NhanVienMod nhanVien = new Models.NhanVienMod(Convert.ToInt32(manv));
                return nhanVien.Restore_ChuyenCN();
            }
            catch { return 1; }
        }
    }
}
