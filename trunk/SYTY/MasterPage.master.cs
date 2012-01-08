using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<LMenu> lMenus = new List<LMenu>();

        //lMenus.Add(GetLMenu("网站首页", "default.aspx"));
        lMenus.Add(GetLMenu("田园理念", "Philosophy.aspx"));
        lMenus.Add(GetLMenu("精英团队", "team.aspx"));
        lMenus.Add(GetLMenu("田园展示", "imgList.aspx"));
        lMenus.Add(GetLMenu("新闻中心", "newsList.aspx"));
        lMenus.Add(GetLMenu("联系我们", "ContactUS.aspx"));
        lMenus.Add(GetLMenu("人才招聘", "Recruit.aspx"));
        StringBuilder sb = new StringBuilder();
        foreach (LMenu l in lMenus)
        {
            if (Request.Url.AbsoluteUri.ToLower().Contains(l.url.ToLower()))
            {
                sb.Append("<li class='nav_item nav_item_selected'>");
            }
            else
            {
                sb.Append("<li class='nav_item'>");
            }
            sb.Append("<a href='" + l.url + "'>" + l.title + "</a>");
            sb.Append("</li>");
        }
        Literal1.Text = sb.ToString();
    }
    public LMenu GetLMenu(string title, string url)
    {
        LMenu l1 = new LMenu();
        l1.title = title;
        l1.url = "/" + url;
        return l1;

    }
    public class LMenu
    {
        public string title { get; set; }
        public string url { get; set; }
    }
}
