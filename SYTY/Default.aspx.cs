using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            List<ImgType> imgTypes = new List<ImgType>();
            List<ImgDB> imgDbs = new List<ImgDB>();
            string connStr =
          @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
          ";Persist Security Info=False;";
            OleDbConnection conn = new OleDbConnection(connStr);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText =
                "select top 16 * from ty_img where iscover=0 order by id desc";
            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Literal1.Text += "<a href='#'><img src='" + dr["imgURL"].ToString().Replace("~", "") + "' alt='index_baner1_" + i + "'/></a>";
                Literal2.Text += "<li><img src='" + dr["imgURL_small"].ToString().Replace("~", "") + "' width='50' heigth='50' /><p>" + dr["typename"] + "</p></li>";
                i++;
                
            }
            dr.Close();
           
            cmd.CommandText = "select top 5 * from ty_article order by id desc";
            OleDbDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                Literal3.Text += "<li><a href='news.aspx?id=" + dr1["id"].ToString() + "' class='dt'>" + dr1["title"].ToString() + "</a><span class='dd'>" + DateTime.Parse(dr1["intime"].ToString()).ToShortDateString() + "</span></li>";
            }

        }
    }
    public class ImgType
    {
        public string typeid { get; set; }
        public string typename { get; set; }
    }
    public class ImgDB
    {
        public string ID { get; set; }
        public string FlagID { get; set; }
        public string imgTitle { get; set; }
        public string imgUrl { get; set; }
        public string imgUrlSmall { get; set; }
    }
}