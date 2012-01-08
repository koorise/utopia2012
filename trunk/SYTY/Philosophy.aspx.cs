using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Philosophy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr =
      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
      ";Persist Security Info=False;";
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand();

        cmd.CommandText = "select * from ty_content where id=3 order by id desc";
        cmd.Connection = conn;
        conn.Open();
        OleDbDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Literal1.Text += "<div class='news'>";
            Literal1.Text += "<h4 class='title'>" + dr["title"]+ "</h4>";
            Literal1.Text += dr["content"].ToString();
            Literal1.Text += "</div>";
        }
    }
}