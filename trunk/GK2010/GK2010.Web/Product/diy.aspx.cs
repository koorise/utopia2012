using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.BLL;
using GK2010.Utility;
using GK2010.Common;
using System.Linq;
namespace GK2010.Web.Product
{
    public partial class diy : PageBase
    {
        #region 参数
        public int ProductID
        {
            get
            {
                return ConfigParam.ID;
            }
        }
        #endregion

       
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
             
            ZPageBase_MainChannel.EnumNavigator = EnumNavigator.Product;
            ShowInfo();
            ShowPartsInfo(); 

        }
        #endregion

        #region 显示价格、型号及计算公式
        private void ShowInfo()
        {
            BLL.Product bll = new BLL.Product();
            Model.Product model = bll.GetModel(ProductID);
            if (model != null)
            {
                litModelType.Text = "<span id='litModelType'>" + model.DiyTypeEn + "</span>";
                litOriginalPrice.Text = "<span id='litOriginalPrice'>" + model.DefaultPriceOld.ToString() + "</span>";
                litMemberPrice.Text = "<span id='litMemberPrice'>" + model.DefaultPrice.ToString() + "</span>";
                litJF.Text = "<span id='litJF'>" + model.DefaultJF.ToString() + "</span>";
                litBasicDiscountPrice.Text = "<span id='litBasicDiscountPrice' style='display:none'>"+ model.BasicDiscountPrice/100 +"</span>";
                litProductID.Text = "<input id='litProductID' type='hidden' value="+ ProductID + " name='productid' />";

            }
            
            
            #region 显示基本信息，价格
            BLL.Product bllProduct = new BLL.Product();
            Model.Product modelProduct = bllProduct.GetModel(ProductID);
            if (modelProduct != null)
            {

            }
            #endregion
        }
        #endregion
        
        private  void ShowPartsInfo()
        {
            string _s1 = "";
            string _s2 = "";
            BLL.ProductParts bll=new ProductParts();
            List<Model.ProductParts> pp = bll.GetListNew(ProductID);
            int i = 1;
            foreach (Model.ProductParts p in pp)
            {
                if ((p.Flag==1)&&(p.AttachmentFlag==2))
                {
                    if (p.Path.Split(',').Length == 1)
                    {
                        string abcStr = ABCHelper.Parse(i++);
                        _s1 += "<div class='bd_hd'><h2>" + abcStr + "&nbsp;&nbsp;&nbsp;&nbsp;" + p.Title +
                               "</h2></div>";
                        if (p.HasChild == 0)
                        {
                            var q =
                                from c in pp
                                where c.Path.StartsWith(p.Path + ",")
                                select c;
                            foreach (Model.ProductParts _p in q)
                            {
                                _s1 += "<ul>\n";
                                _s1 += "<li class='blue'>";
                                _s1 += "<input type='radio' class='ppradio' onclick='ChangeOption(\"p_" + p.ID + "\",this.value)'  name='p_" + p.ID + "' value='" + _p.ID + "$" + _p.TitleEn +
                                "$"+ _p.Title +"$"+_p.Price+"$"+abcStr+"' title='" +
                                _p.Title + "'";
                                if (_p.DefaultFlag == 1)
                                {
                                    _s1 += "checked";
                                    litPartsList.Text += "<li><a href='#'>" + abcStr + " 型号：" + _p.Title + "(" + _p.TitleEn + ")</a></li>";
                                }
                                _s1 += " />&nbsp;&nbsp;";
                                _s1 += _p.Title;
                                _s1 += "</li>\n";
                                _s1 += "</ul>\n";
                            }
                        }
                        if (p.HasChild == 1)
                        {
                            var q =
                                from c in pp
                                where c.ParentID == p.ID
                                select c;
                            _s1 += "<table width='100'% border='0' cellspacing='0' cellpadding='0'>\n";
                            _s1 += "<tr>\n";
                            _s1 += "<td valign='top'>";
                            if (p.PictureID != 0)
                            {
                                _s1 += "<img src='" + p.PictureSmall + "' alt='' />";
                            }
                            else
                            {
                                _s1 += "<img src='/images/pc25.jpg' alt='' />";
                            }
                            _s1 += "</td><td>";
                            foreach (Model.ProductParts _p in q)
                            {
                                _s1 += " <div class='h2_tit'>";
                                _s1 += "<h2><span><a href=''>了解更多</a></span>" + _p.Title + "</h2>";
                                _s1 += "<div class='bd_ul'><ul>";
                                var _q =
                                    from _c in pp
                                    where _c.Path.StartsWith(_p.Path + ",")
                                    select _c;
                                foreach (Model.ProductParts __p in _q)
                                {
                                    _s1 += "<li class='blue'>";
                                    _s1 += "<input type='radio' class='ppradio' onclick='ChangeOption(\"p_" + _p.ID +
                                           "\",this.value)' name='p_" + _p.ID + "' value='" + __p.ID + "$" + __p.TitleEn +
                                           "$" + __p.Title + "$" + __p.Price + "$" + abcStr + "' title='" +
                                           __p.Title + "'";
                                    if (__p.DefaultFlag == 1)
                                    {
                                        _s1 += "checked";
                                        litPartsList.Text += "<li><a href='#'>" + abcStr + " 型号：" + _p.Title + "(" + _p.TitleEn + ")</a></li>";
                                    }
                                    _s1 += " />&nbsp;&nbsp;";
                                    _s1 += __p.Title;
                                    _s1 += "</li>\n";
                                }
                                _s1 += "</ul>";
                                _s1 += "</div>";
                            }
                            _s1 += "</td></tr></table>";

                        }
                    }
                }
                if((p.Flag==1)&&(p.AttachmentFlag==1))
                {
                    if (p.Path.Split(',').Length == 1)
                    {
                        string abcStr = ABCHelper.Parse(i++);
                        _s2 += "<div class='bd_hd'><h2><input type='checkbox' onclick='SetFj(this.checked,\"" + abcStr + "_" + p.ID + "\")'   name='ck_" + p.ID + "'>&nbsp;&nbsp;&nbsp;&nbsp;" + abcStr + "&nbsp;&nbsp;&nbsp;&nbsp;" + p.Title +
                               "</h2></div>";
                        if (p.HasChild == 0)
                        {
                            var q =
                                from c in pp
                                where c.Path.StartsWith(p.Path + ",")
                                select c;
                            foreach (Model.ProductParts _p in q)
                            {
                                _s2 += "<ul>\n";
                                _s2 += "<li class='blue'>";
                                _s2 += "<input type='radio' onclick='ChangeOption(\"\", \"\")' class='" + abcStr + "_" + p.ID + "' name='p_" + p.ID + "' value='" + _p.ID +
                                       "$" + _p.TitleEn +
                                       "$" + _p.Title + "$" + _p.Price + "$" + abcStr + "' title='" +
                                       _p.Title + "'";
                                if (_p.DefaultFlag == 1)
                                {
                                    _s2 += "checked";
                                   
                                }
                                _s2 += " />&nbsp;&nbsp;";
                                _s2 += _p.Title;
                                _s2 += "</li>\n";
                                _s2 += "</ul>\n";
                            }
                        }
                        if (p.HasChild == 1)
                        {
                            var q =
                                from c in pp
                                where c.ParentID == p.ID
                                select c;
                            _s2 += "<table width='100'% border='0' cellspacing='0' cellpadding='0'>\n";
                            _s2 += "<tr>\n";
                            _s2 += "<td valign='top'>";
                            if (p.PictureID != 0)
                            {
                                _s2 += "<img src='" + p.PictureSmall + "' alt='' />";
                            }
                            else
                            {
                                _s2 += "<img src='/images/pc25.jpg' alt='' />";
                            }
                            _s2 += "</td><td>";
                            foreach (Model.ProductParts _p in q)
                            {
                                _s2 += " <div class='h2_tit'>";
                                _s2 += "<h2><span><a href=''>了解更多</a></span>" + _p.Title + "</h2>";
                                _s2 += "<div class='bd_ul'><ul>";
                                var _q =
                                    from _c in pp
                                    where _c.Path.StartsWith(_p.Path + ",")
                                    select _c;
                                foreach (Model.ProductParts __p in _q)
                                {
                                    _s2 += "<li class='blue'>";
                                    _s2 += "<input type='radio' class='"+abcStr+"_"+p.ID+"' onclick='ChangeOption(\"p_" + _p.ID +
                                           "\",this.value)' name='p_" + _p.ID + "' value='" + __p.ID + "$" + __p.TitleEn +
                                           "$" + __p.Title + "$" + __p.Price + "$" + abcStr + "' title='" +
                                           __p.Title + "'";
                                    if (__p.DefaultFlag == 1)
                                    {
                                        _s2 += "checked";
                                    }
                                    _s2 += " />&nbsp;&nbsp;";
                                    _s2 += __p.Title;
                                    _s2 += "</li>\n";
                                }
                                _s2 += "</ul>";
                                _s2 += "</div>";
                            }
                            _s2 += "</td></tr></table>";

                        }
                    }
                }
            }
         
            lblTxta.Text = _s1;
            lblTxtb.Text = _s2;
        }
    }
}
