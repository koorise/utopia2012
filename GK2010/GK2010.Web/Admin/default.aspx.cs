using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin
{
    public partial class _default : System.Web.UI.Page
    {
        #region 变量
        public string strUSUALL = "";
        public string strMAIN_BLOCK = "";
        public string strSUBMENU_CONFIG = "";
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 判断用没有登录
            if (!LoginHelper.HasLogin)
            {
                Response.Write("<script>top.location.href='/admin/login.aspx';</script>");
                return;
            }
            #endregion

            #region 判断是不是网站后台管理员
            if (!LoginHelper.IsAdmin)
            {
                Response.Write("<script>top.location.href='/admin/login.aspx';</script>");
                return;
            }
            #endregion

            if (!IsPostBack)
            {
                GK2010.Model.Member Member = LoginHelper.Member;
                if (Member != null)
                {
                    //用户名
                    txtUserName.Text = Member.UserName;

                    //级别
                    txtUserLevel.Text = BLL.MemberGroup.GetTitle(Member.GroupID);

                    GK2010.BLL.SystemTree bll = new GK2010.BLL.SystemTree();
                    DataTable dt = bll.GetTable(Member.ID.ToString(), "Group");

                    //绑定常用
                    List<GK2010.Model.SystemTree> models = bll.DataTableToList(dt.Select("isdefault=1", "SortID ASC"));
                    foreach (GK2010.Model.SystemTree model in models)
                    {
                        strUSUALL += "{id:'" + model.ID + "',name:'" + model.Title + "',url:'" + model.Url + "'},";
                    }
                    strUSUALL = StringHelper.DelLastChar(strUSUALL);

                    //主选项
                    models = bll.DataTableToList(dt.Select("parentid=0", "SortID ASC"));
                    //int i = 0;
                    //int pos = 0;
                    foreach (GK2010.Model.SystemTree model in models)
                    {
                        strMAIN_BLOCK += "{id:'" + model.ID + "',name:'" + model.Title + "',enname:'" + model.TitleEn + "'},";
                    }
                    strMAIN_BLOCK = StringHelper.DelLastChar(strMAIN_BLOCK);

                    //子类别
                    strSUBMENU_CONFIG = BindSubmenu(dt);
                }
            }

        }
        #endregion

        #region BindSubmenu
        public string BindSubmenu(DataTable dt)
        {
            string strReturn = "";

            GK2010.BLL.SystemTree bll = new GK2010.BLL.SystemTree();
            List<GK2010.Model.SystemTree> models = bll.DataTableToList(dt.Select("ParentID=0", "SortID ASC"));

            foreach (GK2010.Model.SystemTree model in models)
            {
                if (model.HasChild == 1)
                {
                    strReturn += "'" + model.ID + "':{'id':'','items':[" + BindSubmenu(model.ID, dt) + "]},";
                }
            }
            strReturn = StringHelper.DelLastChar(strReturn);
            return strReturn;
        }
        #endregion

        #region BindSubmenu
        private string BindSubmenu(int ParentID, DataTable dt)
        {
            string strReturn = "";

            GK2010.BLL.SystemTree bll = new GK2010.BLL.SystemTree();
            List<GK2010.Model.SystemTree> models = bll.DataTableToList(dt.Select("ParentID=" + ParentID, "SortID ASC"));
            foreach (GK2010.Model.SystemTree model in models)
            {

                if (model.HasChild == 1)
                {
                    strReturn += "{'id':'" + model.ID + "','name':'" + model.Title + "','items':[" + BindSubmenu(model.ID, dt) + "]},";
                }
                else
                {
                    strReturn += "{id:'" + model.ID + "',name:'" + model.Title + "',url:'" + model.Url + "',enname:'" + model.TitleEn + "'},";
                }
            }

            strReturn = StringHelper.DelLastChar(strReturn);
            return strReturn;
        }
        #endregion
    }
}
