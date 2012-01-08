using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class news : System.Web.UI.Page
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
            cmd.CommandText = "select * from ty_article where id=" + Request["id"];
            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                Label1.Text = dr["title"].ToString();
                Literal1.Text = dr["content"].ToString();
                Label2.Text = dr["intime"].ToString();
                Label3.Text ="<a href='newsList.aspx?id="+dr["typeid"]+"'>"+ dr["typename"].ToString()+"</a>";
                Label4.Text = dr["typename"].ToString();
            }
        }
    }
}