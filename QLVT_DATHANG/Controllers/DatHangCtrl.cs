using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Controllers
{
    class DatHangCtrl
    {
        internal static int InsertDDH(int manv, string madhh, string makho, string nhacc)
        {
            try
            {
                Models.DatHangMod DDH = new Models.DatHangMod(manv, madhh, makho, nhacc);
                return DDH.InsertDDH();
            }
            catch
            {
                return 1;
            }
        }
        internal static DataSet FillDataSetThongTin(string maDDH)
        {
            try
            {
                Models.DatHangMod datHang = new Models.DatHangMod(maDDH);
                return datHang.FillDataSetThongTin();
            }
            catch
            {
                return null;
            }
        }
        internal static int InsertCTDDH(string masoddh, string mavt, int soluong, float dongia)
        {
            try
            {
                Models.DatHangMod DDH = new Models.DatHangMod(masoddh, mavt, soluong, dongia);
                return DDH.InsertCTDDH();
            }
            catch
            {
                return 1;
            }
        }

        internal static int DeleteDatHang(string _maDDH)
        {
            try
            {
                Models.DatHangMod datHang = new Models.DatHangMod(_maDDH);
                return datHang.DeleteDatHang();
            }
            catch
            {
                return 1;
            }
        }
        internal static DataSet FillDataSetDDH()
        {
            try
            {
                return Models.DatHangMod.FillDataSetDDH();
            }
            catch
            {
                return null;
            }
        }

        internal static DataSet FillDataSetCTDDH()
        {
            try
            {
                return Models.DatHangMod.FillDataSetCTDDH();
            }
            catch
            {
                return null;
            }
        }
    }
}
