using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.Program
{
    public partial class Add : System.Web.UI.Page
    {
       
	    #region Page_Load
	    protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Program");
            if (!IsPostBack)
            {
                AdminIndustry1.TableName = TableName.Program;
                AdminIndustry1.TableID = 0;

                AdminMedium1.TableName = TableName.Program;
                AdminMedium1.TableID = 0;

                AdminTag1.TableName = TableName.Program;
                AdminTag1.TableID = 0;                 
            }
		    
	    }
	    #endregion

	    #region 添加
	    protected void btnAdd_Click(object sender, EventArgs e)
	    {
        
		    string Title = txtTitle.Text;
		    string Detail = txtDetail.Value;		
		    int IndexFlag = chkIndexFlag.Checked?1:0;  
            int ChannelFlag = chkChannelFlag.Checked ? 1 : 0;
            int CommendFlag = chkCommendFlag.Checked ? 1 : 0;
            int HotFlag = chkHotFlag.Checked ? 1 : 0; 		   
            long PostDate = DatetimeHelper.Now;
            int PostUserID = LoginHelper.UserID;          

		    GK2010.Model.Program model=new GK2010.Model.Program();
		
		    model.Title = Title;		   
		    model.Detail = Detail;		 
		    model.IndexFlag = IndexFlag;
		    model.ChannelFlag = ChannelFlag;
            model.HotFlag = HotFlag;
            model.CommendFlag = CommendFlag;
            model.SEOTitle = AdminSEO1.SEOTitle;
            model.SEOKeywords = AdminSEO1.SEOKeywords;
            model.SEODescription = AdminSEO1.SEODescription;
		    model.PostDate = PostDate;
		    model.PostUserID = PostUserID;
		    

		    GK2010.BLL.Program bll=new GK2010.BLL.Program();
		    int ret = bll.Add(model);
    		
		    #region 转向到操作结果界面
		    if (ret > 0)
		    {
                AdminIndustry1.Save(TableName.Program, ret);
                AdminMedium1.Save(TableName.Program, ret);
                AdminTag1.Save(TableName.Program, ret);

                string ReturnUrl = ConfigParam.ReturnUrl;
                if (ReturnUrl == "") { ReturnUrl = "manage.aspx"; }
			    MessageBox.ShowAlertAndRedirect(this.Page, "添加成功", ReturnUrl);
		    }
		    else
		    {
		    MessageBox.ShowAlert(this.Page, "添加失败");
		    }
		    #endregion

	    }
	    #endregion

    }
}
