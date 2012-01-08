using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
namespace GK2010.Common
{
    public class DropDownListHelper
    {
        /// <summary>
        /// 绑定值
        /// </summary>
        /// <param name="drop">DropDownList控件</param>
        /// <param name="TextField">显示字段</param>
        /// <param name="ValueField">值字段</param>
        /// <param name="objSourse">数据源</param>
        public static void Bind(System.Web.UI.WebControls.DropDownList drop, string TextField, string ValueField, object objSourse)
        {
            drop.DataSource = objSourse;
            drop.DataTextField = TextField;
            drop.DataValueField = ValueField;
            drop.DataBind();

            drop.Items.Insert(0, new ListItem("请选择", "0"));
        }

        /// <summary>
        /// 获取已选项
        /// </summary>
        /// <param name="drop">DropDownList控件</param>
        /// <returns></returns>
        public static string GetValue(System.Web.UI.WebControls.DropDownList drop)
        {
            return drop.SelectedValue;
        }

        /// <summary>
        /// 设置已选项
        /// </summary>
        /// <param name="drop">DropDownList控件</param>
        /// <param name="strValue">已选择的值</param>
        public static void SetValue(System.Web.UI.WebControls.DropDownList drop, string strValue)
        {
            try{drop.SelectedValue = strValue;}
            catch{}            
        }        
    }
}
