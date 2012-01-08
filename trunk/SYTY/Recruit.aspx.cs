using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
public partial class Recruit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string connStr =
           @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
           ";Persist Security Info=False;";
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText =
            "insert into ty_zhaopin (username,sex,XueLi,School,Credit,WorkYears,Exp,Phones,[Email])values('" +
            tbUsername.Text + "','" + ddlSex.Items[ddlSex.SelectedIndex].Value + "','" + tbXueLi.Text + "','"+tbSchool.Text+"','" +
            ddlZhicheng.Items[ddlZhicheng.SelectedIndex].Value + "','" +
            ddlWorksYears.Items[ddlWorksYears.SelectedIndex].Value + "','" + tbExp.Text + "','" + tbPhones.Text + "','" +
            tbEmail.Text + "')"; 
         
        cmd.Connection = conn;
        conn.Open();
        cmd.ExecuteNonQuery();
         
        Response.Write("<script language='javascript'>alert('感谢你的投递！');window.location.href='default.aspx';</script>");
    }
}