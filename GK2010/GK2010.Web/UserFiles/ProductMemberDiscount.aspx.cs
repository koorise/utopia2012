using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Json;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Service
{
    public partial class ProductMemberDiscount : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 非管理员
            if (!LoginHelper.IsAdmin)
            {
                Response.Write("{}");
                Response.End();
            }
            #endregion

            //中文解码 Server.UrlDecode();
            string jsonResult = "{}";
            string jsoncall = ConfigParam.callback;
            string type = ConfigParam.Type;
            int UserID = ConfigParam.GetIntGet("UserID");
            int ProductID = ConfigParam.GetIntGet("ProductID");
            int BasicDiscount = ConfigParam.GetIntGet("BasicDiscount");
            int Discount = ConfigParam.GetIntGet("Discount");
            string Type = ConfigParam.GetStrGet("Type");            
            if (type != "")
            {
                switch (type)
                {
                    case "JF":
                        jsonResult = ChangeDiscountJF(ProductID, UserID, BasicDiscount, Discount);
                        break;
                    case "Price":
                        jsonResult = ChangeDiscountPrice(ProductID, UserID, BasicDiscount, Discount);
                        break;
                }
            }
            Response.ContentType = "text/plain";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(jsoncall + "(" + jsonResult + ")");
        }
        #endregion        

        #region 修改积分折扣
        public string ChangeDiscountJF(int ProductID,int UserID, int BasicDiscount, int Discount)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            string Status = "<span style='color:green'>已设置</span>";
            if (Discount > 0 && Discount <= 100)
            {
                BLL.ProductMemberDiscount bll = new GK2010.BLL.ProductMemberDiscount();
                Model.ProductMemberDiscount model = bll.GetModel(UserID, ProductID);
                if (model != null)
                {
                    model.CheckFlag = 1;
                    if (Discount < BasicDiscount)
                    {
                        Status = "未审核";
                        model.CheckFlag = 2;//未审核
                    }
                    model.DiscountJF = Discount;
                }
                else
                {
                    model = new GK2010.Model.ProductMemberDiscount();
                    model.UserID = UserID;
                    model.ProductID = ProductID;
                    model.DiscountPrice = 100;
                    model.DiscountJF = Discount;
                    model.CheckFlag = 1;
                    if (Discount < BasicDiscount)
                    {
                        Status = "未审核";
                        model.CheckFlag = 2;//未审核
                    }
                    model.CheckDate = 0;
                    model.CheckUserID = 0;
                }
                bool ok = bll.Operator(model);
                if (ok)
                {
                    collection.Add(new JsonStringValue("Result", "OK"));
                    collection.Add(new JsonStringValue("Status", Status));
                }
                else
                {
                    collection.Add(new JsonStringValue("Result", "Fail"));
                    
                }  
            }
            else
            {
                collection.Add(new JsonStringValue("Result", "修改失败：只可输入0-100之间的整数！"));
            }
            return collection.ToString();
        }
        #endregion

        #region 修改产品折扣
        public string ChangeDiscountPrice(int ProductID, int UserID, int BasicDiscount, int Discount)
        {
            string Status = "<span style='color:green'>已设置</span>";
            JsonObjectCollection collection = new JsonObjectCollection();
            if (Discount < BasicDiscount)
            {
                collection.Add(new JsonStringValue("Result", "修改失败：不可低于最低标准折扣"));            
                return collection.ToString();
            }

            if (Discount > 0 && Discount <= 100)
            {
                BLL.ProductMemberDiscount bll = new GK2010.BLL.ProductMemberDiscount();
                Model.ProductMemberDiscount model = bll.GetModel(UserID, ProductID);
                if (model != null)
                {
                    model.CheckFlag = 1;
                    if (Discount < BasicDiscount)
                    {
                        Status = "未审核";
                        model.CheckFlag = 2;//未审核
                    }
                    model.DiscountPrice = Discount;
                }
                else
                {
                    model = new GK2010.Model.ProductMemberDiscount();
                    model.UserID = UserID;
                    model.ProductID = ProductID;
                    model.DiscountPrice = Discount;
                    model.DiscountJF = 100;
                    model.CheckFlag = 1;

                    if (Discount < BasicDiscount)
                    {
                        Status = "未审核";
                        model.CheckFlag = 2;//未审核
                    }
                    model.CheckDate = 0;
                    model.CheckUserID = 0;
                }
                bool ok = bll.Operator(model);
                if (ok)
                {
                    collection.Add(new JsonStringValue("Result", "OK"));
                    collection.Add(new JsonStringValue("Status", Status));
                }
                else
                {
                    collection.Add(new JsonStringValue("Result", "Fail"));
                }
            }
            else
            {
                collection.Add(new JsonStringValue("Result", "修改失败：只可输入0-100之间的整数！"));
            }
            
            return collection.ToString();
        }
        #endregion

    }
}
