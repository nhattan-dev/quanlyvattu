using QLVT_DATHANG.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Models
{
    class Act
    {
        public enum ActType
        {
            DELETE,
            INSERT,
            CHUYENCN
        }

        private ActType type { get; set; }
        private string[] paras { get; set; }

        public ActType GetType()
        {
            return type;
        }
        public string GetParameters()
        {
            string str = "";
            int key = 0;
            foreach(string s in paras){
                if (key == 1)
                    str += ",";
                str += s;
                key = 1;
            }
            return str;
        }

        public Act(ActType _type, string _paras)
        {
            type = _type;
            paras = _paras.Split(',');
        }

        public int Undo()
        {
            if (type == ActType.DELETE)
            {
                if (paras[0].ToUpper().Equals("VATTU"))
                {
                    return VatTuCtrl.InsertVatTu(paras[1], paras[2], paras[3], Convert.ToInt32(paras[4]));
                }
                else if (paras[0].ToUpper().Equals("KHO"))
                {
                    return KhoCtrl.InsertKho(paras[1], paras[2], paras[3], paras[4]);
                }
                else if (paras[0].ToUpper().Equals("NHANVIEN"))
                {
                    return NhanVienCtrl.Restore(Convert.ToInt32(paras[1]));
                }
            }
            else if (type == ActType.INSERT)
            {
                if (paras[0].ToUpper().Equals("VATTU"))
                {
                    return VatTuCtrl.DeleteVatTu(paras[1]);
                }
                else if (paras[0].ToUpper().Equals("KHO"))
                {
                    return KhoCtrl.DeleteKho(paras[1]);
                }
                else if (paras[0].ToUpper().Equals("NHANVIEN"))
                {
                    return NhanVienCtrl.DeleteNhanVien(Convert.ToInt32(paras[1]));
                }
            }else if(type == ActType.CHUYENCN)
            {
                if (paras[0].ToUpper().Equals("NHANVIEN"))
                {
                    return NhanVienCtrl.Restore_ChuyenNV(paras[1]);
                }
            }
            return 1;
        }
    }
}
