using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Models
{
    class DatHangMod
    {
        private string maDDH { set; get; }
        protected int manv { set; get; }
        protected string mavt { set; get; }
        protected string makho { set; get; }
        protected string nhacc { set; get; }
        protected float dongia { set; get; }
        protected int soluong { set; get; }

        public DatHangMod(int _manv, string _mavt, string _madhh, string _makho, string _nhacc, float _dongia, int _soluong)
        {
            manv = _manv;
            mavt = _mavt;
            makho = _makho;
            maDDH = _madhh;
            nhacc = _nhacc;
            soluong = _soluong;
            dongia = _dongia;
        }
        public DataSet FillDataSetThongTin()
        {
            string[] paras = new string[1] { "@MasoDDH" };
            object[] values = new object[1] { maDDH };
            return Connection.FillDataSet("sp_VatTu_Ordered_By_MasoDDH", CommandType.StoredProcedure, paras, values);
        }

        public DatHangMod(string _madhh, string _mavt, int _soluong, float _dongia)
        {
            mavt = _mavt;
            maDDH = _madhh;
            soluong = _soluong;
            dongia = _dongia;
        }

        public int DeleteDatHang()
        {
            string[] paras = new string[1] { "MasoDDH" };
            object[] values = new object[1] { maDDH };
            return Connection.RequestStatus("dbo.sp_XoaDatHang", CommandType.StoredProcedure, paras, values);
        }

        internal static DataSet FillDataSetDDH()
        {
            return Connection.FillDataSet("sp_GetDDH", CommandType.StoredProcedure);
        }

        public DatHangMod(string maDDH)
        {
            this.maDDH = maDDH;
        }

        public DatHangMod(int manv, string madhh, string makho, string nhacc)
        {
            this.manv = manv;
            this.maDDH = madhh;
            this.makho = makho;
            this.nhacc = nhacc;
        }

        public DatHangMod(int manv, string mavt, int soluong, float dongia)
        {
            this.manv = manv;
            this.mavt = mavt;
            this.soluong = soluong;
            this.dongia = dongia;
        }

        public int DDHTonTai_all()
        {
            string[] paras = new string[1] { "@MaSoDDH" };
            object[] values = new object[1] { maDDH };
            return Connection.RequestStatus("dbo.sp_TonTaiMaDDH_all", System.Data.CommandType.StoredProcedure, paras, values);
        }
        public int DDHTonTai()
        {
            string[] paras = new string[1] { "@MaSoDDH" };
            object[] values = new object[1] { maDDH };
            return Connection.RequestStatus("dbo.sp_TonTaiMaDDH", System.Data.CommandType.StoredProcedure, paras, values);
        }

        internal static DataSet FillDataSetCTDDH()
        {
            return Connection.FillDataSet("sp_GetCTDDH", CommandType.StoredProcedure);
        }

        public int InsertDDH()
        {
            string[] paras = new string[4] { "@MasoDDH", "@MANV", "@MAKHO", "@NhaCC" };
            object[] values = new object[4] { maDDH, manv, makho, nhacc };
            return Connection.RequestStatus("dbo.sp_ThemDDH", CommandType.StoredProcedure, paras, values);
        }

        public int InsertCTDDH()
        {
            string[] paras = new string[4] { "@MasoDDH", "@MAVT", "@SOLUONG", "@DONGIA" };
            object[] values = new object[4] { maDDH, mavt, soluong, dongia };
            return Connection.RequestStatus("dbo.sp_ThemCTDDH", CommandType.StoredProcedure, paras, values);
        }
    }
}
