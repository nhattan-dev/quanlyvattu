using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Controllers
{
    class AccountCtrl
    {
        public static int TaoTaiKhoan(string _loginname, string _password, string _username, string _quyen)
        {
            try
            {
                Models.AccountMod _account = new Models.AccountMod(_loginname, _password, _username, _quyen);
                return _account.TaoTaiKhoan();
            }
            catch
            {
                return 1;
            }
        }
    }
}
