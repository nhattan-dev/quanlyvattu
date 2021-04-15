using DevExpress.Data.Async;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Models
{
    class NhanVienMod
    {
        protected int MANV { get; set; }
        protected string HO { get; set; }
        protected string TEN { get; set; }
        protected string DIACHI { get; set; }
        protected DateTime NGAYSINH { get; set; }
        protected float LUONG { get; set; }
        protected string MACN { get; set; }
        protected int TrangThaiXoa { get; set; }

        public NhanVienMod() { }

        public NhanVienMod(int _manv)
        {
            MANV = _manv;
        }

        public NhanVienMod(int _manv, string _ho, string _ten, string _diachi, DateTime _ngaysinh, float _luong, string _macn, int _trangthaixoa) 
        {
            MANV = _manv;
            HO = _ho;
            TEN = _ten;
            DIACHI = _diachi;
            NGAYSINH = _ngaysinh;
            LUONG = _luong;
            MACN = _macn;
            TrangThaiXoa = _trangthaixoa;
        }

        public int InsertNhanVien()
        {
            int i = 0;
            string[] paras = new string[8] { "@MANV", "@HO", "@TEN", "@DIACHI", "@NGAYSINH", "@LUONG", "@MACN", "@TrangThaiXoa" };
            object[] values = new object[8] { MANV, HO, TEN, DIACHI, NGAYSINH, LUONG, MACN, TrangThaiXoa };
            i = Connection.RequestStatus("dbo.sp_ThemNhanVien", CommandType.StoredProcedure, paras, values);
            return i;   
        }

        internal int Restore()
        {
            string[] para = new string[1] { "@MANV" };
            object[] value = new object[1] { MANV };
            return Connection.RequestStatus("dbo.sp_Restore_NhanVien", CommandType.StoredProcedure, para, value);
        }

        public int ChuyenChiNhanh(int _MaNV_new)
        {
            string[] paras = new string[] { "@MANV", "@NEWID" };
            object[] values = new object[] { MANV, _MaNV_new };
            return Connection.RequestStatus("SP_ChuyenCN", CommandType.StoredProcedure, paras, values);
        }
        
        public int NhanVienTonTai()
        {
            string[] paras = new string[] { "@MANV" };
            object[] values = new object[] { MANV };
            return Connection.RequestStatus("sp_TonTaiNhanVien", CommandType.StoredProcedure, paras, values);
        }

        internal int Restore_ChuyenCN()
        {
            string[] paras = new string[] { "@MANV" };
            object[] values = new object[] { MANV };
            return Connection.RequestStatus("sp_Restore_ChuyenCN", CommandType.StoredProcedure, paras, values);
        }

        public static DataSet getInfo(string TenLogin)
        {
            string[] paras = new string[] { "@TENLOGIN"};
            object[] values = new object[] { TenLogin};
            return Connection.FillDataSet("sp_DangNhap", CommandType.StoredProcedure, paras, values);
        } 


        public int DeleteNhanVien()
        {
            string[] paras = new string[] { "@MANV" };
            object[] values = new object[] { MANV };
            return Connection.RequestStatus("sp_XoaNhanVien", CommandType.StoredProcedure, paras, values);;
        }

        public static DataSet FillDataSetNhanVien()
        {
            return Connection.FillDataSet("sp_GetNhanVien", CommandType.StoredProcedure);
        } 

    }
}
