using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG.Controllers
{
    class KhoCtrl
    {
        public static int DeleteKho(string _MaKho)
        {
            try
            {
                Models.KhoMod _Kho = new Models.KhoMod(_MaKho);
                return _Kho.DeleteKho();
            }
            catch { return 1; }
        }

        public static int InsertKho(string _makho, string _tenkho, string _diachi, string _macn)
        {
            try
            {
                Models.KhoMod _Kho = new Models.KhoMod(_makho, _tenkho, _diachi, _macn);
                return _Kho.InsertKho();
            }
            catch
            {
                return 1;
            }
        }
        public static int KhoTonTai_all(string _makho)
        {
            try
            {
                Models.KhoMod _Kho = new Models.KhoMod(_makho);
                return _Kho.KhoTonTai_all();
            }
            catch
            {
                return 1;
            }
        }
        public static DataSet FillDataSetKho()
        {
            try
            {
                return Models.KhoMod.FillDataSetKho();
            }
            catch
            {
                return null;
            }
        }
    }
}
