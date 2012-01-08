using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.Drawing.Imaging;

public partial class Management_imgManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Response.Cache.SetNoStore();
        if(!IsPostBack)
        {
            string connStr =
           @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
           ";Persist Security Info=False;";
            OleDbConnection conn = new OleDbConnection(connStr);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from sys_img_type order by id desc";
            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr[1].ToString();
                li.Value = dr[0].ToString();
                DropDownList1.Items.Add(li);
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
        cmd.CommandText = "insert into sys_img_type (imgtype)values('" + TextBox1.Text + "')";
        cmd.Connection = conn;
        conn.Open();
        cmd.ExecuteNonQuery();
        Response.Redirect("~/management/imgManage.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string connStr =
          @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
          ";Persist Security Info=False;";
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = "update sys_img_type set imgtype='"+TextBox1.Text+"' where id="+DropDownList1.Items[DropDownList1.SelectedIndex].Value;
        cmd.Connection = conn;
        conn.Open();
        cmd.ExecuteNonQuery();
        Response.Redirect("~/management/imgManage.aspx");

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string connStr =
         @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
         ";Persist Security Info=False;";
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = "delete from sys_img_type  where id=" + DropDownList1.Items[DropDownList1.SelectedIndex].Value;
        cmd.Connection = conn;
        conn.Open();
        cmd.ExecuteNonQuery();
        Response.Redirect("~/management/imgManage.aspx");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        int isCover = 0;
        if(!CheckBox1.Checked)
        {
            isCover = 1;
        }
        string imgurl = Guid.NewGuid().ToString() + ".gif";
        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/") + imgurl);
        MakeThumbnail(Server.MapPath("~/Upload/") + imgurl, Server.MapPath("~/Upload/s_") + imgurl,145,105,"HW");
        string connStr =
        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/Database.mdb") +
        ";Persist Security Info=False;";
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = "insert into ty_img (flagid,imgtitle,imgurl,content,typename,imgURL_small,iscover)values(" +
                          DropDownList1.Items[DropDownList1.SelectedIndex].Value + ",'" + tbTitle.Text + "','/Upload/" +
                          imgurl + "','" + TextBox2.Text + "','" + DropDownList1.Items[DropDownList1.SelectedIndex].Text +
                          "','/Upload/s_" +
                          imgurl + "'," + isCover + ")";
        cmd.Connection = conn;
        conn.Open();
        cmd.ExecuteNonQuery();  
    }
    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param>    
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
}