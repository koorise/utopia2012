using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DelCookeis();
        Response.Redirect("~/default.aspx");
    }
    #region##删除cookies
    ///<summary>
    /// 删除cookies
    ///</summary>
    public void DelCookeis()
    {

        if (Request.Cookies["admin"] != null)
        {
            HttpCookie cookies = new HttpCookie("admin");
            cookies.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookies);
        }

    }
    #endregion
}