using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
namespace GK2010.Common
{
    public class RadioButtonListHelper
    {
        /// <summary>
        /// 绑定值
        /// </summary>
        /// <param name="drop">RadioButtonList控件</param>
        /// <param name="TextField">显示字段</param>
        /// <param name="ValueField">值字段</param>
        /// <param name="objSourse">数据源</param>
        public static void Bind(System.Web.UI.WebControls.RadioButtonList rad, string TextField, string ValueField, object objSourse)
        {
            rad.DataSource = objSourse;
            rad.DataTextField = TextField;
            rad.DataValueField = ValueField;
            rad.DataBind();
        }

        /// <summary>
        /// 获取已选项
        /// </summary>
        /// <param name="drop">DropDownList控件</param>
        /// <returns></returns>
        public static string GetValue(System.Web.UI.WebControls.RadioButtonList rad)
        {
            return rad.SelectedValue;
        }

        /// <summary>
        /// 设置已选项
        /// </summary>
        /// <param name="drop">DropDownList控件</param>
        /// <param name="strValue">已选择的值</param>
        public static void SetValue(System.Web.UI.WebControls.RadioButtonList rad, string strValue)
        {
            try { rad.SelectedValue = strValue; }
            catch{}            
        }        
    }
}
