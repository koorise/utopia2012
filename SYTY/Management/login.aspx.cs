using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Management_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string connStr =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
            ";Persist Security Info=False;";
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = "select * from ty_admin where adminname='"+TextBox1.Text+"' and passwd='"+ TextBox2.Text +"'";
        cmd.Connection = conn;
        conn.Open();
        OleDbDataReader dr = cmd.ExecuteReader();
        if(dr.Read())
        {
           AddCookies();
        }
        Response.Redirect("~/management/default.aspx");

    }
    #region##添加cookeis
    ///<summary>
    /// 添加cookeis
    ///</summary>
    public void AddCookies()
    {

        HttpCookie cookies = new HttpCookie("admin");
        cookies["name"] = "koorise";
        cookies["sex"] = "1";
        cookies.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(cookies);

    }
    #endregion
}