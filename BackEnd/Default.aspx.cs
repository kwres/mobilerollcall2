using CLB.Models;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd
{
    public partial class Defaults : System.Web.UI.Page
    {

        public User User
        {
            get
            {
                User r = new User();
                r.Email = txtMail.Text;
                r.PasswordHash = txtPassword.Text;
                return r;
            }
            set
            {
                txtMail.SetValue(value.Email);
                txtPassword.SetValue(value.PasswordHash);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginClick(object sender, Ext.Net.DirectEventArgs e)
        {
            var control = new User();
            var login= control.login();
            if (login == true)
            {
                X.Msg.Alert("UYARI", "Giriş yapılıyor...").Show();
                return;
            }
            else
            {
                X.Msg.Alert("UYARI", "Hatalı bilgi, tekrar deneyiniz").Show();
                return;
            }

        }

       
    }
}