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
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///first time page load
            if (!X.IsAjaxRequest)
            {
                cbUserType.SetValue("-1");
            }
        }
        
        protected void btnAddNew_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            //Yeni kayit eklemek için
            wndAddNewUser.Show();
        }

 

        protected void btnGetList_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            //filteleme kullanılarak yapılan listeleme
            Store str = grdList.GetStore();
            str.DataSource = new User().getList(txtFilter.Text, Convert.ToInt32(cbUserType.Value), -1);
            str.DataBind();
        }
    }
}