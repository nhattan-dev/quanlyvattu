using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Models
{
    class PhieuXuatMod
    {


        protected string maPX { get; set; }
        protected string maVT { get; set; }
        protected string maKho { get; set; }
        protected int maNV { get; set; }
        protected string tenKH { get; set; }
        protected float donGia { get; set; }
        protected int soLuong { get; set; }
        public PhieuXuatMod(string maPX)
        {
            this.maPX = maPX;
        }

        public PhieuXuatMod(string _maPX, string _maVT, string _maKho, int _maNV, string _tenKH, int _soLuong, float _donGia)
        {
            maPX = _maPX;
            maVT = _maVT;
            maKho = _maKho;
            maNV = _maNV;
            tenKH = _tenKH;
            soLuong = _soLuong;
            donGia = _donGia;
        }
        public PhieuXuatMod(string _maPX, string _maKho, int _maNV, string _tenKH)
        {
            maPX = _maPX;
            maKho = _maKho;
            maNV = _maNV;
            tenKH = _tenKH;
        }
        public PhieuXuatMod(string _maPX, string _maVT, int _soLuong, float _donGia)
        {
            maPX = _maPX;
            maVT = _maVT;
            soLuong = _soLuong;
            donGia = _donGia;
        }
        public static DataSet FillDataSetPhieuXuat()
        {
            return Connection.FillDataSet("sp_GetPhieuXuat", CommandType.StoredProcedure);
        }

        public static DataSet FillDataSetCTPX()
        {
            return Connection.FillDataSet("sp_GetCTPX", CommandType.StoredProcedure);
        }

        public int PhieuXuatTonTai_all()
        {
            string[] paras = new string[1] { "@MAPX" };
            object[] values = new object[1] { maPX };
            return Connection.RequestStatus("dbo.sp_TonTaiMaPhieuXuat_all", CommandType.StoredProcedure, paras, values);
        }
        public int PhieuXuatTonTai()
        {
            string[] paras = new string[1] { "@MAPX" };
            object[] values = new object[1] { maPX };
            return Connection.RequestStatus("dbo.sp_TonTaiMaPhieuXuat", CommandType.StoredProcedure, paras, values);
        }

        public int InsertPhieuXuat()
        {
            string[] paras = new string[4] { "@MaPX", "@MANV", "@MAKHO", "@HOTENKH" };
            object[] values = new object[4] { maPX, maNV, maKho, tenKH };
            return Connection.RequestStatus("dbo.sp_ThemPhieuXuat", CommandType.StoredProcedure, paras, values);
        }

        public int InsertCTPX()
        {
            string[] paras = new string[4] { "@MaPX", "@MAVT", "@SOLUONG", "@DONGIA" };
            object[] values = new object[4] { maPX, maVT, soLuong, donGia };
            return Connection.RequestStatus("dbo.sp_ThemCTPX", CommandType.StoredProcedure, paras, values);
        }

        internal int DeletePhieuXuat()
        {
            string[] paras = new string[1] {"@MAPX" };
            object[] values = new object[1] { maPX };
            return Connection.RequestStatus("dbo.sp_XoaPhieuXuat", CommandType.StoredProcedure, paras, values);
        }
    }
}
