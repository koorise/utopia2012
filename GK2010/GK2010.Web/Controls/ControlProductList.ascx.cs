using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Controls
{
    public partial class ControlProductList : System.Web.UI.UserControl
    {
        public int I = 1;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定类别
            BindCategory();
            //绑定虚拟类别
            BindVirtualCategory();
            //显示格式
            BindShowType();
        }
        #endregion


        #region 显示格式
        public void BindShowType()
        {
            //图片1,列表2
            if (ConfigParam.ShowType == 1)
            {
                HyperLinkShowTypeList.ImageUrl = "/images/showtype_list2.jpg";
                HyperLinkShowTypePic.ImageUrl = "/images/showtype_pic1.jpg";
            }
            if (ConfigParam.ShowType == 2)
            {
                HyperLinkShowTypeList.ImageUrl = "/images/showtype_list1.jpg";
                HyperLinkShowTypePic.ImageUrl = "/images/showtype_pic2.jpg";
            }

            HyperLinkShowTypeList.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                           ConfigParam.BigID,
                           ConfigParam.SmallID,
                           0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                           ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                           ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                           ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                           ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                           ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                           ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                           ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                           ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                           ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                           1,
                           2,
                           ConfigParam.Page);
            HyperLinkShowTypePic.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                          ConfigParam.BigID,
                          ConfigParam.SmallID,
                          0,
                           ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                          1,
                          1,
                          ConfigParam.Page);
        }
        #endregion

        #region 绑定类别
        private void BindCategory()
        {
            txtCategory.Text = BLL.ProductCategory.GetTitle(ConfigParam.BigID);

            BLL.ProductCategory bll = new BLL.ProductCategory();
            List<Model.ProductCategory> models = bll.GetList(ConfigParam.BigID.ToString(), "ParentID");
            Model.ProductCategory model = new GK2010.Model.ProductCategory();
            model.ID = 0 ;
            model.Title = "全部";
            models.Insert(0, model);
            RepeaterListCategory.DataSource = models;
            RepeaterListCategory.DataBind();
        }

        protected void RepeaterListCategory_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.ProductCategory model = (Model.ProductCategory)e.Item.DataItem;

                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = model.Title;                    
                    HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                          ConfigParam.BigID,
                          model.ID,
                          0,
                          ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                          ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                          1,
                          ConfigParam.ShowType,
                          1);

                    //设置当前选中项
                    if (model.ID == ConfigParam.SmallID)
                    {
                        //HyperLinkCategoryAll.CssClass = "";
                        HyperLinkTitle.CssClass = "Select";
                    }
                    break;
            }
        }
        #endregion

        #region 绑定虚拟类别

        private void BindVirtualCategory()
        {
            BLL.VirtualCategory bll = new BLL.VirtualCategory();
            RepeaterList.DataSource = bll.GetList(ConfigParam.BigID.ToString(), "ProductCategory");
            RepeaterList.DataBind();
        }

        protected void RepeaterList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.VirtualCategory model = (Model.VirtualCategory)e.Item.DataItem;                    

                    BLL.Virtual bll = new BLL.Virtual();
                    Repeater RepeaterListChild = (Repeater)e.Item.FindControl("RepeaterListChild");

                    List<Model.Virtual> models = bll.GetList(model.ID.ToString(), "CategoryID");
                    Model.Virtual modelVirtual = new Model.Virtual();
                    modelVirtual.ID = 0;
                    modelVirtual.Title = "全部";
                    models.Insert(0, modelVirtual);
                    RepeaterListChild.DataSource = models;
                    RepeaterListChild.DataBind();

                    I++;

                    break;
            }
        }

        protected void RepeaterListChild_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    Model.Virtual model = (Model.Virtual)e.Item.DataItem;

                    //标题
                    HyperLink HyperLinkTitle = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                    HyperLinkTitle.Text = model.Title;
                    HyperLinkTitle.ToolTip = model.Title;                   

                    #region 所有
                    if (I == 1)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            model.ID,
                            ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                            1,
                            ConfigParam.ShowType,
                            1);
                    }
                    if (I == 2)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                            model.ID,
                            ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                            1,
                            ConfigParam.ShowType,
                            1);
                    }
                    if (I == 3)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                            model.ID,
                            ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                            1,
                             ConfigParam.ShowType,
                            1);
                    }
                    if (I == 4)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                            model.ID,
                            ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                            1,
                             ConfigParam.ShowType,
                            1);
                    }
                    if (I == 5)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                            model.ID,
                            ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                            1,
                            ConfigParam.ShowType,
                            1);
                    }
                    if (I == 6)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                            model.ID,
                            ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                            1,
                            ConfigParam.ShowType,
                            1);
                    }
                    if (I == 7)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                            model.ID,
                            ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                            1,
                            ConfigParam.ShowType,
                            1);
                    }
                    if (I == 8)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                            model.ID,
                            ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                            1,
                            ConfigParam.ShowType,
                            1);
                    }
                    if (I == 9)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                            model.ID,
                            ConfigParam.GetIntGet("VirtualCategoryID10", 0),
                            1,
                            ConfigParam.ShowType,
                            1);
                    }
                    if (I == 10)
                    {
                        HyperLinkTitle.NavigateUrl = string.Format(ConfigUrl.UrlProductCategory,
                            ConfigParam.BigID,
                            ConfigParam.SmallID,
                            0,
                            ConfigParam.GetIntGet("VirtualCategoryID1", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID2", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID3", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID4", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID5", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID6", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID7", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID8", 0),
                            ConfigParam.GetIntGet("VirtualCategoryID9", 0),
                            model.ID,
                            1,
                            ConfigParam.ShowType,
                            1);
                    }

                    #endregion

                    //设置当前选中项
                    
                        if (model.ID == ConfigParam.GetIntGet("VirtualCategoryID" + I, -1))
                        {
                            HyperLinkTitle.CssClass = "Select";                            
                        }
                   

                    break;
            }
        }
        #endregion
    }
}