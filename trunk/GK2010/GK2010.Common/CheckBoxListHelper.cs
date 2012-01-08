using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
namespace GK2010.Common
{
    public class CheckBoxListHelper
    {
        /// <summary>
        /// 绑定值
        /// </summary>
        /// <param name="chk"></param>
        /// <param name="TextField"></param>
        /// <param name="ValueField"></param>
        /// <param name="objSourse"></param>
        public static void Bind(System.Web.UI.WebControls.CheckBoxList chk, string TextField, string ValueField, object objSourse)
        {
            chk.DataSource = objSourse;
            chk.DataTextField = TextField;
            chk.DataValueField = ValueField;
            chk.DataBind();
        }

        /// <summary>
        /// 获取已选项
        /// </summary>
        /// <param name="chk">CheckBoxList控件</param>
        /// <returns></returns>
        public static string GetValue(System.Web.UI.WebControls.CheckBoxList chk)
        {
            string ret = "";
            foreach (ListItem item in chk.Items)
            {
                if (item.Selected)
                {
                    ret += item.Value + ",";
                }
            }

            ret = GK2010.Utility.StringHelper.DelLastChar(ret);
            return ret;
        }

        /// <summary>
        /// 设置已选项
        /// </summary>
        /// <param name="chk">CheckBoxList控件</param>
        /// <param name="strValue">已选择的值</param>
        public static void SetValue(System.Web.UI.WebControls.CheckBoxList chk,string strValue)
        {
            strValue = "," +strValue+ ",";
            string itemValue = "";
            foreach (ListItem item in chk.Items)
            {
                itemValue = "," + item.Value + ",";
                if (strValue.IndexOf(itemValue) >= 0)
                {
                    item.Selected = true;
                }
            }
        }
    }
}
