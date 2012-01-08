using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_Content : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            string connStr =
           @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
           ";Persist Security Info=False;";
            OleDbConnection conn = new OleDbConnection(connStr);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from ty_content where id=" + Request["id"];
            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                Literal1.Text = dr[1].ToString();
                CKEditorControl1.Text = dr[2].ToString();
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string connStr =
          @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
          ";Persist Security Info=False;";
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = "update ty_content set content='"+CKEditorControl1.Text+"' where id=" + Request["id"];
        cmd.Connection = conn;
        conn.Open();
        cmd.ExecuteNonQuery();
        Literal1.Text = "<div class='notification success png_bg'><a href='#' class='close'><img src='resources/images/icons/cross_grey_small.png' title='Close this notification' alt='close' /></a><div>更新成功！</div></div>";
    }
}