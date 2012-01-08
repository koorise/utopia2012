using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newsList : System.Web.UI.Page
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
             
            cmd.CommandText = "select * from ty_article order by id desc";
            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            List<ArticleModule> articleModules=new List<ArticleModule>();
            int i = 1;
            while (dr.Read())
            { 
                ArticleModule am = new ArticleModule();
                am.id = i;
                am.aid = int.Parse(dr["id"].ToString());
                am.title = dr["title"].ToString();
                am.content = dr["content"].ToString();
                am.typeid = int.Parse(dr["typeid"].ToString());
                am.typename = dr["typename"].ToString();
                am.listStyle = "<li><span><a href='/newsList.aspx?id="+dr["id"]+"' >" + dr["title"] + "</a></span><label>" + DateTime.Parse(dr["intime"].ToString()).ToShortDateString() +
                               "</label></li>";
                articleModules.Add(am);
                i++;
            }
            if (Request["id"] != null && Request["id"]!="")
            {
                var q = from c in articleModules
                        where c.aid == int.Parse(Request["id"])
                        select c;
                foreach (ArticleModule articleModule in q)
                {
                    Literal1.Text += "<div class='news'>";
                    Literal1.Text += "<h4 class='title'>" + articleModule.title + "</h4>";
                    Literal1.Text += articleModule.content;
                    Literal1.Text += "</div>";
                } 
               
            }
            else
            {
                int pagesize = 10;
                int pagecount = ((int) (articleModules.Count/10)) + ((articleModules.Count%10 == 0 ? 0 : 1));
                int currentPage = 1;
                if (Request["page"] != null)
                {
                    currentPage = int.Parse(Request["page"]);
                }

                var displayList = articleModules.Skip((currentPage - 1)*pagesize).Take(pagesize);
                Literal1.Text += "<ul class='news'>";
                foreach (ArticleModule articleModule in displayList)
                {
                    Literal1.Text += articleModule.listStyle;
                }
                Literal1.Text  +="</ul>";
                Literal2.Text += PagerHTML(currentPage, pagecount, "newsList.aspx");
            }

        }
    }
    public static string PagerHTML(int pageIndex, int pageCount, string url)
    {
        string html = "<div class='flickr'>";
        int page = pageCount;
        for (int i = 1; i <= page; i++)
        {
            if (i == 1)
            {
                if (pageIndex == 1)
                {
                    html = html + "<span class='disabled'> < </span>";
                }
                else
                {
                    html = html + "<a href='" + url + "?page=" + (pageIndex - 1) + "' ><</a>";
                }
            }
            if (pageIndex == i)
            {
                html = html + "<span class='current'>" + i + "</span>";
            }
            else
            {
                html = html + "<a href='" + url + "?page=" + i + "'>" + i + "</a>";
            }
            if (i == page)
            {
                if (pageIndex == page)
                {
                    html = html + "<span class='disabled'> > </span>";
                }
                else
                {
                    html = html + "<a href='" + url + "?page=" + (pageIndex + 1) + "' > > </a>";
                }
            }
        }

        html = html + "</div>";
        return html;
    }
    public class ArticleModule
    {
        public int id { get; set; }
        public int aid { get; set; }
        public int typeid { get; set; }
        public string typename { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string listStyle { get; set; }
        
    }
}