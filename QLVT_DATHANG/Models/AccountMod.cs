using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT_DATHANG.Models
{
    class AccountMod
    {
        protected string loginname;
        protected string password;
        protected string username;
        protected string quyen;

        public AccountMod(string _loginname, string _password, string _username, string _quyen)
        {
            loginname = _loginname;
            password = _password;
            username = _username;
            quyen = _quyen;
        }
        public int TaoTaiKhoan()
        {
            string[] paras = new string[] { "@LGNAME", "@PASS", "@USERNAME", "@ROLE" };
            object[] values = new object[] { loginname, password, username, quyen };
            return Connection.RequestStatus("sp_TaoTaiKhoan", CommandType.StoredProcedure, paras, values);
        }
    }
}
