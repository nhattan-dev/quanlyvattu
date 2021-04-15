using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Models
{
    class VatTuMod
    {
        protected string MaVT { get; set; }
        protected string TenVT { get; set; }
        protected string DVT { get; set; }
        protected int SoLuongTon { get; set; }

        public VatTuMod(string _MaVT)
        {
            MaVT = _MaVT;
        }
        public VatTuMod(string _MaVT, string _TenVT, string _DVT, int _SoLuongTon)
        {
            MaVT = _MaVT;
            TenVT = _TenVT;
            DVT = _DVT;
            SoLuongTon = _SoLuongTon;
        }
        public int DeleteVatTu()
        {
            string[] paras = new string[] { "@MaVT" };
            object[] values = new object[] { MaVT };
            return Connection.RequestStatus("sp_XoaVatTu", CommandType.StoredProcedure, paras, values); ;
        }
        public int InsertVatTu()
        {
            string[] paras = new string[4] { "@MAVT", "@TenVT", "@DVT", "SOLUONGTON" };
            object[] values = new object[4] { MaVT, TenVT, DVT, SoLuongTon };
            return Connection.RequestStatus("dbo.sp_ThemVatTu", CommandType.StoredProcedure, paras, values);
        }
        public int VatTuTonTai()
        {
            string[] paras = new string[1] { "@MAVT"};
            object[] values = new object[1] { MaVT};
            return Connection.RequestStatus("dbo.sp_TonTaiMaVatTu", CommandType.StoredProcedure, paras, values);
        }
        public static DataSet FillDataSetVatTu()
        {
            return Connection.FillDataSet("sp_GetVatTu", CommandType.StoredProcedure);
        }

    }
}
