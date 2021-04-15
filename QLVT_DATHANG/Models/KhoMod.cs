using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Models
{
    class KhoMod
    {
        protected string MaKho { get; set; }
        protected string TenKho { get; set; }
        protected string DiaChi { get; set; }
        protected string MaCN { get; set; }

        public KhoMod(string _MaKho)
        {
            MaKho = _MaKho;
        }
        public KhoMod(string _MaKho, string _TenKho, string _DiaChi, string _MaCN)
        {
            MaKho = _MaKho;
            TenKho = _TenKho;
            DiaChi = _DiaChi;
            MaCN = _MaCN;
        }
        public int DeleteKho()
        {
            string[] paras = new string[] { "@MaKho" };
            object[] values = new object[] { MaKho };
            return Connection.RequestStatus("sp_XoaKho", CommandType.StoredProcedure, paras, values); ;
        }
        public int InsertKho()
        {
            string[] paras = new string[4] { "@MAKHO", "@TENKHO", "@DIACHI", "@MACN" };
            object[] values = new object[4] { MaKho, TenKho, DiaChi, MaCN };
            return Connection.RequestStatus("dbo.sp_ThemKho", CommandType.StoredProcedure, paras, values);
        }
        public int KhoTonTai()
        {
            string[] paras = new string[1] { "@MAKho" };
            object[] values = new object[1] { MaKho };
            return Connection.RequestStatus("dbo.sp_TonTaiMaKho", CommandType.StoredProcedure, paras, values);
        }
        public int KhoTonTai_all()
        {
            string[] paras = new string[1] { "@MAKho" };
            object[] values = new object[1] { MaKho };
            return Connection.RequestStatus("dbo.sp_TonTaiMaKho_all", CommandType.StoredProcedure, paras, values);
        }
        public static DataSet FillDataSetKho()
        {
            return Connection.FillDataSet("sp_GetKho", CommandType.StoredProcedure);
        }
    }
}
