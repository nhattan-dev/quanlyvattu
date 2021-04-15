using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Models
{
    class PhieuNhapMod
    {
        protected string maPN { get; set; }
        protected string maVT { get; set; }
        protected string maDDH { get; set; }
        protected string maKho { get; set; }
        protected int maNV { get; set; }
        protected float donGia { get; set; }
        protected int soLuong { get; set; }

        public PhieuNhapMod(string _maPN)
        {
            maPN = _maPN;
        }

        public PhieuNhapMod(string _maSoDDH, string _maPN)
        {
            maDDH = _maSoDDH;
        }

        public PhieuNhapMod(string _maPN, string _maVT, string _maDDH, string _maKho, int _maNV, int _soLuong, float _donGia)
        {
            maPN = _maPN;
            maVT = _maVT;
            maKho = _maKho;
            maNV = _maNV;
            maDDH = _maDDH;
            soLuong = _soLuong;
            donGia = _donGia;
        }

        public PhieuNhapMod(string maPN, string maDDH, string maKho, int maNV)
        {
            this.maPN = maPN;
            this.maDDH = maDDH;
            this.maKho = maKho;
            this.maNV = maNV;
        }

        public PhieuNhapMod(string maPN, string maVT, int soLuong, float donGia)
        {
            this.maPN = maPN;
            this.maVT = maVT;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }

        public int DaNhapDDH()
        {
            string[] paras = new string[1] {"MasoDDH" };
            object[] values = new object[1] { maDDH};
            return Connection.RequestStatus("sp_DaNhapDDH", CommandType.StoredProcedure, paras, values);
        }

        public int InsertPhieuNhap()
        {
            string[] paras = new string[4] { "@MaPN", "@MANV", "@MAKHO", "@MasoDDH"};
            object[] values = new object[4] { maPN, maNV, maKho, maDDH };
            return Connection.RequestStatus("dbo.sp_ThemPhieuNhap", CommandType.StoredProcedure, paras, values);
        }

        public int InsertCTPN()
        {
            string[] paras = new string[4] { "@MaPN", "@MAVT", "@SOLUONG", "@DONGIA", };
            object[] values = new object[4] { maPN, maVT, soLuong, donGia };
            return Connection.RequestStatus("dbo.sp_ThemCTPN", CommandType.StoredProcedure, paras, values);
        }

        public int PhieuNhapTonTai()
        {
            string[] paras = new string[1] { "@MAPN" };
            object[] values = new object[1] { maPN };
            return Connection.RequestStatus("dbo.sp_TonTaiMaPhieuNhap", CommandType.StoredProcedure, paras, values);
        }
        public int PhieuNhapTonTai_all()
        {
            string[] paras = new string[1] { "@MAPN" };
            object[] values = new object[1] { maPN };
            return Connection.RequestStatus("dbo.sp_TonTaiMaPhieuNhap_all", CommandType.StoredProcedure, paras, values);
        }

        public static DataSet FillDataSetPhieuNhap()
        {
            return Connection.FillDataSet("sp_GetPhieuNhap", CommandType.StoredProcedure);
        }

        public static DataSet FillDataSetCTPN()
        {
            return Connection.FillDataSet("sp_GetCTPN", CommandType.StoredProcedure);
        }
        public DataSet FillDataSetThongTin()
        {
            string[] paras = new string[1] { "@MasoDDH" };
            object[] values = new object[1] { maDDH };
            return Connection.FillDataSet("sp_ThongTin_PhieuNhap", CommandType.StoredProcedure, paras, values);
        }

        public int DeletePhieuNhap()
        {
            string[] paras = new string[1] { "@MAPN" };
            object[] values = new object[1] { maPN };
            return Connection.RequestStatus("dbo.sp_XoaPhieuNhap", CommandType.StoredProcedure, paras, values);
        }
    }
}
