using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management_imgList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        string connStr =
   @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
   ";Persist Security Info=False;";
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand();

        cmd.CommandText = "select * from ty_img order by id desc";
        cmd.Connection = conn;
        conn.Open();
        OleDbDataReader dr = cmd.ExecuteReader();
        List<ImgModule> imgModules = new List<ImgModule>();
        int i = 1;
        while (dr.Read())
        {
            ImgModule am = new ImgModule();
            am.id = i;
            am.aid = int.Parse(dr["id"].ToString());
            am.imgtitle = dr["imgtitle"].ToString();
            am.content = dr["content"].ToString();
            am.flagid = int.Parse(dr["flagid"].ToString());
            am.typename = dr["typename"].ToString();
            am.url = dr["imgurl"].ToString().Replace("~","");
            am.surl = dr["imgurl_small"].ToString();
            am.isCover = dr["isCover"].ToString();
            imgModules.Add(am);
            i++;
        }

        int pagesize = 10;
        int pagecount = ((int)(imgModules.Count / 10)) + ((imgModules.Count % 10 == 0 ? 0 : 1));
        int currentPage = 1;
        if (Request["page"] != null)
        {
            currentPage = int.Parse(Request["page"]);
        }

        var displayList = imgModules.Skip((currentPage - 1) * pagesize).Take(pagesize);
        StringBuilder sb = new StringBuilder();
        foreach (ImgModule imgModule in displayList)
        {
            sb.Append("<tr> ");
            sb.Append("<td>" + imgModule.aid + "</td>");
            sb.Append("<td>"+ imgModule.typename +"</td>");
            sb.Append("<td><a href='/newslist.aspx?id=" + imgModule.aid + "' title='title'>" + imgModule.imgtitle + "</a></td>");
            
            sb.Append("<td><a href='" + imgModule.url + "' target=_blank><img src='" + imgModule.surl + "' style='width:50px;height:50px;'></a></td>");
            if(imgModule.isCover!="0")
            {
                sb.Append("<td>否</td>");
            }
            else
            {
                sb.Append("<td>是</td>");
            }
           
            sb.Append("<td><a href='/management/imgdel.aspx?id=" + imgModule.aid + "' title='Delete'><img src='resources/images/icons/cross.png' alt='Delete' /></a> ");
            sb.Append("</td>");
            sb.Append("</tr>");
        }
        Literal1.Text = sb.ToString();
        Literal2.Text += PagerHTML(currentPage, pagecount, "/management/imglist.aspx");
        
        
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
    public class ImgModule
    {
        public int id { get; set; }
        public int aid { get; set; }
        public int flagid { get; set; } 
        public string typename { get; set; }
        public string imgtitle { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        public string surl { get; set; }
        public string isCover { get; set; }
    }
}