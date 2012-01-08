using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Text;

public partial class imgList : System.Web.UI.Page
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
            cmd.CommandText = "select imgtitle,content,imgurl from ty_img";
            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            List<TyCase> tyCases=new List<TyCase>();
            while (dr.Read())
            {
                TyCase ty=new TyCase();
                ty.title = dr[0].ToString();
                ty.content = dr[1].ToString();
                ty.imgurl = dr[2].ToString().Replace("~","");
                tyCases.Add(ty);
            }
            dr.Close();
            var sss = tyCases.Distinct(new Comparint());
            
            StringBuilder centerStr =  new StringBuilder();
            StringBuilder footStr = new StringBuilder();
            StringBuilder leftStr = new StringBuilder();
            int i = 0;
            foreach (var tyCase in sss)
            {
                 if(i==0)
                 {
                     leftStr.Append("<div class='intro description'>");
                     leftStr.Append("<h4 class='h4'>" + tyCase.title + "</h4>");
                     leftStr.Append("<h5 class='h5'>项目介绍：</h5>");
                     leftStr.Append("<p>" + tyCase.content + "</p>");
                     leftStr.Append("</div>");

                     footStr.Append("<li class='selected'>");
                     footStr.Append("<p><a class='img145x105'>");
                     footStr.Append("<img alt='#' style='width:145px;height:105px;' src='" + tyCase.imgurl + "' /></a></p>");
                     footStr.Append("<h6 class='h6'>" + tyCase.title + "</h6>");
                     footStr.Append("</li>");

                     centerStr.Append("<ul class='pic_list_change pic_list_change_show clearfix'>");
                     i++;
                 }
                 else
                 {
                     leftStr.Append("<div class='intro'>");
                     leftStr.Append("<h4 class='h4'>" + tyCase.title + "</h4>");
                     leftStr.Append("<h5 class='h5'>项目介绍：</h5>");
                     leftStr.Append("<p>" + tyCase.content + "</p>");
                     leftStr.Append("</div>");

                     footStr.Append("<li>");
                     footStr.Append("<p><a class='img145x105'>");
                     footStr.Append("<img alt='#' style='width:145px;height:105px;' src='" + tyCase.imgurl + "' /></a></p>");
                     footStr.Append("<h6 class='h6'>" + tyCase.title + "</h6>");
                     footStr.Append("</li>");

                     centerStr.Append("<ul class='pic_list_change clearfix'>");

                 }
                
                  
                var q =
                        from c in tyCases
                        where c.title == tyCase.title
                        select c;
               
                foreach (TyCase cCase in q)
                {
                   centerStr.Append("<li><a class='img145x105 lightbox' href='" + cCase.imgurl + "'><img style='width:145px;height:105px;' alt='#' src='" + cCase.imgurl + "' /></a></li>");
                }
                centerStr.Append("</ul>");
            }
            litCenter.Text = centerStr.ToString();
            litLeft.Text = leftStr.ToString();
            litFoot.Text = footStr.ToString();

        }
    }
    public class TyCase
    {
        public string title { get; set; }
        public string content { get; set; }
        public string imgurl { get; set; }
    }
    public class Comparint : IEqualityComparer<TyCase>
    {

        public bool Equals(TyCase x, TyCase y)
        {
            if (x == null && y == null)
                return false;
            return x.title == y.title;
        }

        public int GetHashCode(TyCase obj)
        {
         return obj.ToString().GetHashCode();
       }
    }
}