using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_imgdel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        if (Request["ID"] != null)
        {
            string id = Request["ID"];
            string connStr =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
            ";Persist Security Info=False;";
            OleDbConnection conn = new OleDbConnection(connStr);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "delete from ty_img where id=" + id;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("~/management/imglist.aspx");
        }
    }
}