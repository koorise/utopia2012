using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Response.Cache.SetNoStore(); 
        if(!GetCookies())
        {
         Response.Redirect("~/management/login.aspx");   
        }
    }
    #region##得到cookies
    ///<summary>
    /// 得到cookies
    ///</summary>
    public bool GetCookies()
    {

        HttpCookie cookies = Request.Cookies["admin"];
        if(cookies!=null&& cookies["name"]=="koorise")
         
        return true;
        else
        {
            return false;
        }
    }
    #endregion
}
