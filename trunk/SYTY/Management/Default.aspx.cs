using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Management_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            List<ArticleModule> articleModules = new List<ArticleModule>();
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
                am.listStyle = "<li><span><a href='/newsList.aspx?id=" + dr["id"] + "' >" + dr["title"] +
                               "</a></span><label>" + dr["intime"] +
                               "</label></li>";
                articleModules.Add(am);
                i++;
            }

            int pagesize = 10;
            int pagecount = ((int) (articleModules.Count/10)) + ((articleModules.Count%10 == 0 ? 0 : 1));
            int currentPage = 1;
            if (Request["page"] != null)
            {
                currentPage = int.Parse(Request["page"]);
            }

            var displayList = articleModules.Skip((currentPage - 1)*pagesize).Take(pagesize);
            StringBuilder sb = new StringBuilder();
            foreach (ArticleModule articleModule in displayList)
            {
                sb.Append("<tr> ");
                sb.Append("<td>" + articleModule.aid + "</td>");
                sb.Append("<td><a href='/newslist.aspx?id=" + articleModule.aid + "' title='title'>" +
                          articleModule.title + "</a></td>");
                // sb.Append("<td>Consectetur adipiscing</td>");
                sb.Append("<td>");
                sb.Append(" <a href='/management/newsAdd.aspx?id=" + articleModule.aid +
                          "' title='Edit'><img src='resources/images/icons/pencil.png' alt='Edit' /></a>");
                sb.Append("<a href='/management/newsdel.aspx?id=" + articleModule.aid +
                          "' title='Delete'><img src='resources/images/icons/cross.png' alt='Delete' /></a> ");
                sb.Append("</td>");
                sb.Append("</tr>");
            }
            Literal1.Text = sb.ToString();
            Literal2.Text += PagerHTML(currentPage, pagecount, "/management/default.aspx");


        }
    }
    public static string PagerHTML(int pageIndex, int pageCount, string url)
    {
        string html = "<div class='pagination'>";
        int page = pageCount;
        for (int i = 1; i <= page; i++)
        {
            if (i == 1)
            {
                if (pageIndex == 1)
                {
                    html = html + "<a href='#' title='First Page'>&laquo; Previous</a>";
                }
                else
                {
                    html = html + "<a href='" + url + "?page=" + (pageIndex - 1) + "'title='First Page' >&laquo; Previous</a>";
                }
            }
            if (pageIndex == i)
            {
                html = html + "<a href='#' class='number current' >" + i + "</a>";
            }
            else
            {
                html = html + "<a href='" + url + "?page=" + i + "' class='number'>" + i + "</a>";
            }
            if (i == page)
            {
                if (pageIndex == page)
                {
                    html = html + "<a href='#' title='Last Page'>Next &raquo;</a>";
                }
                else
                {
                    html = html + "<a href='" + url + "?page=" + (pageIndex + 1) + "' title='Last Page'> Next &raquo; </a>";
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