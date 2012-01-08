using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GK2010.Utility;
using GK2010.Common;
namespace GK2010.Web.Admin.ProductPicture
{
    public partial class Manage : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.SystemTree.CheckPermission("Product");
            if (!IsPostBack)
            {
                BindData();
            }
        }
        #endregion

        #region ������
        private void BindData()
        {            
            GK2010.BLL.ProductPicture bll = new GK2010.BLL.ProductPicture();
            RepeaterList.DataSource = bll.GetList(ConfigParam.ProductID.ToString(),"ProductID");
            RepeaterList.DataBind();            
        }
        #endregion

        #region ����
        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in RepeaterList.Items)
            {
                HtmlInputHidden txtID = (HtmlInputHidden)item.FindControl("txtID");
                HtmlInputText txtSortID = (HtmlInputText)item.FindControl("txtSortID");
                GK2010.BLL.ProductPicture bll = new GK2010.BLL.ProductPicture();
                GK2010.Model.ProductPicture model = bll.GetModel(int.Parse(txtID.Value));
                if (model != null)
                {
                    model.SortID = DecimalHelper.Parse(txtSortID.Value, 0);
                    bll.Update(model);
                }
            }

            #region ת�򵽲����������
            Response.Redirect(Request.RawUrl);
            #endregion
        }
        #endregion

        #region �ϴ�
        protected void btn_upload_Click(object sender, EventArgs e)
        {           
            FileHelper _FileHelper = new FileHelper(FileUpload1.PostedFile);
            Model.File modelFile = new GK2010.Model.File();
            modelFile = _FileHelper.Save();
            if (modelFile != null)
            {
                GK2010.Model.ProductPicture model = new GK2010.Model.ProductPicture();
                model.ProductID = ConfigParam.ProductID;
                model.Title = "";
                model.Summary = "";
                model.Detail = "";
                model.FileID = 0;
                model.SortID = 0;
                model.DefaultFlag = 0;
                model.PictureSmall = modelFile.PictureSmall;
                model.PictureBig = modelFile.PictureBig;
                model.PictureNormal = modelFile.PictureNormal;

                GK2010.BLL.ProductPicture bll = new GK2010.BLL.ProductPicture();
                int ret = bll.Add(model);

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                MessageBox.ShowAlert(this, "�ϴ�ʧ�ܣ�");
            }
        }
        #endregion
    }
}
