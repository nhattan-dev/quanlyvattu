using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Controllers
{
    class VatTuCtrl
    {
        public static int DeleteVatTu(string _MaVT)
        {
            try
            {
                Models.VatTuMod _vatTu = new Models.VatTuMod(_MaVT);
                return _vatTu.DeleteVatTu();
            }
            catch { return 1; }
        }

        public static int InsertVatTu(string _mavt, string _tenvt, string _dvt, int _soluongton)
        {
            try
            {
                Models.VatTuMod _vatTu = new Models.VatTuMod(_mavt, _tenvt, _dvt, _soluongton);
                return _vatTu.InsertVatTu();
            }
            catch
            {
                return 1;
            }
        }
        public static DataSet FillDataSetVatTu()
        {
            try
            {
                return Models.VatTuMod.FillDataSetVatTu();
            }
            catch
            {
                return null;
            }
        }
    }
}
