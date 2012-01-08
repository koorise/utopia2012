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
    public partial class ProductParts_Handle : System.Web.UI.Page
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
            int PartsID = ConfigParam.GetIntGet("PartsID");
            int ProductID = ConfigParam.GetIntGet("ProductID");
            string Expression = ConfigParam.GetStrGet("Expression");
            Expression = Expression.Replace("%2B", "+");
            if (type != "")
            {
                switch (type)
                {
                    case "ChangeOption":
                        jsonResult = ChangeOption(PartsID, ProductID);
                        break;
                    case "DoCalc":
                        jsonResult = DoCalc(Expression, ProductID);
                        break;
                }
            }
            Response.ContentType = "text/plain";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(jsoncall + "(" + jsonResult + ")");
        }
        #endregion        

        #region 修改默认选项
        public string ChangeOption(int PartsID,int ProductID)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            if (LoginHelper.IsAdmin)
            {
                BLL.ProductParts bll = new GK2010.BLL.ProductParts();
                bool OK = bll.StaticDefault(PartsID);
                if (OK)
                {
                    Model.ProductDiy model = bll.Static(ProductID);
                    if (model != null)
                    {
                        //产品价格
                        decimal TotalPrice = PriceHelper.GetPrice(model);
                        model.Price = TotalPrice;
                        model.Type = PriceHelper.GetType(model);

                        //统计更新产品表
                        PriceHelper.UpdateProduct(ProductID, model);

                        if (TotalPrice >= 0)
                        {
                            collection.Add(new JsonStringValue("Result", "OK"));                           
                            collection.Add(new JsonStringValue("Price", model.Price.ToString()));
                            collection.Add(new JsonStringValue("Type", model.Type));
                        }
                        else
                        {
                            collection.Add(new JsonStringValue("Result", "公式有误，请重新输入！"));
                        }
                    }
                    else
                    {
                        collection.Add(new JsonStringValue("Result", "Fail"));
                    }
                }
                else
                {
                    collection.Add(new JsonStringValue("Result", "Fail"));
                }
            }
            else
            {
                collection.Add(new JsonStringValue("Result", "无权操作"));
            }

            return collection.ToString();
        }
        #endregion

        #region 计算公式及价格
        public string DoCalc(string Expression, int ProductID)
        {
            JsonObjectCollection collection = new JsonObjectCollection();
            //collection.Add(new JsonStringValue("Result", Expression));
            //return collection.ToString();

            if (LoginHelper.IsAdmin)
            {
                BLL.ProductParts bll = new GK2010.BLL.ProductParts();
                Model.ProductDiy model = bll.Static(ConfigParam.ProductID);

                if (model != null)
                {
                    model.DiyExpression = Expression;
                    decimal TotalPrice = PriceHelper.GetPrice(model);
                    model.Price = TotalPrice;
                    model.Type = PriceHelper.GetType(model);
                    PriceHelper.UpdateProduct(ConfigParam.ProductID, model);
                    if (TotalPrice >= 0)
                    {
                        collection.Add(new JsonStringValue("Result", "OK"));
                        collection.Add(new JsonStringValue("Price", model.Price.ToString()));
                        collection.Add(new JsonStringValue("Type", model.Type));
                    }
                    else
                    {
                        collection.Add(new JsonStringValue("Result", "公式有误，请重新输入！" ));
                    }
                }
                else
                {
                    collection.Add(new JsonStringValue("Result", "获取对象失败"));
                }
                
            }
            else
            {
                collection.Add(new JsonStringValue("Result", "无权操作"));
            }

            return collection.ToString();
        }
        #endregion
    }
}
