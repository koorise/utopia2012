using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web;
namespace GK2010.Common
{
    public class FileHelper
    {
        #region 构造函数
        private HttpPostedFile _fileUpload = null;
        private string _UserFilesPath = "";//上传目录相对地址
        private string _UserFilesDirectory = "";//上传目录绝对地址

        public FileHelper(HttpPostedFile _fileUpload)
        {
            this._fileUpload = _fileUpload;
            this._UserFilesPath = "/UserFiles/";
        }
        public FileHelper(HttpPostedFile _fileUpload, string _UserFilesPath)
        {           
            this._fileUpload = _fileUpload;
            this._UserFilesPath = _UserFilesPath;
        }
        #endregion

        protected string UserFilesDirectory
        {
            get
            {
                _UserFilesDirectory = HttpContext.Current.Server.MapPath(this._UserFilesPath);                
                return _UserFilesDirectory;
            }
        }

        #region 图片检查
        /// <summary>
        /// 图片检查
        /// </summary>
        private bool Check()
        {
           HttpPostedFile hpfImage = _fileUpload;

          
            //判断是否为空文件
            if (hpfImage.ContentLength == 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 保存原始图片
        /// <summary>
        /// 保存原始图片
        /// </summary>
        public Model.File Save()
        {
            if (!Check())
            {
                return null;
            }
            else
            {
                #region 上传图片
                HttpPostedFile hpfImage = _fileUpload;

                string strTempDate = DateTime.Now.ToString("yyyy-MM-dd");
                string temDir = UserFilesDirectory + strTempDate;
                DirectoryInfo diBak = new DirectoryInfo(temDir);
                if (!diBak.Exists)
                {
                    diBak.Create();
                }
                int iCounter = 0;

                string strFileExtension = System.IO.Path.GetExtension(hpfImage.FileName);//后缀名
                string strFileName = System.IO.Path.GetFileNameWithoutExtension(hpfImage.FileName);//文件名不速后缀
                string strFullFilePath = System.IO.Path.Combine(diBak.FullName, strFileName + strFileExtension);//上传路径
                while (true)
                {                    
                    if (System.IO.File.Exists(strFullFilePath))
                    {
                        iCounter++;
                        strFileName = System.IO.Path.GetFileNameWithoutExtension(hpfImage.FileName) + "(" + iCounter + ")";
                        strFullFilePath =  System.IO.Path.Combine(diBak.FullName, strFileName + strFileExtension) ;
                    }
                    else
                    {
                        hpfImage.SaveAs(strFullFilePath);
                        break;
                    }
                }
                #endregion             

                #region 图片路径
                string PictureNormal = this._UserFilesPath + strTempDate + "/" + strFileName + strFileExtension;
                string PictureBig = this._UserFilesPath + strTempDate + "/" + strFileName + "_310_310" + strFileExtension;
                string PictureSmall = this._UserFilesPath + strTempDate + "/" + strFileName + "_100_100" + strFileExtension;
             
                #endregion

                #region 生成缩略图
                System.Drawing.Image imgOraginal = System.Drawing.Image.FromFile(strFullFilePath);
                if (imgOraginal.Width > 0)
                {
                    string ThumbPath = UserFilesDirectory + strTempDate + "/" + strFileName;
                    SaveThumbnamilPic(imgOraginal, ThumbPath, strFileExtension);
                    imgOraginal.Dispose();
                }
                #endregion

                Model.File model = new Model.File();
                model.PictureSmall =  PictureSmall;
                model.PictureNormal = PictureNormal;
                model.PictureBig =  PictureBig;
                return model;
            }
        }
        #endregion
      
        #region 保存缩略图片
        /// <summary>
        /// 保存缩略图片
        /// </summary>
        private void SaveThumbnamilPic(System.Drawing.Image imgOraginal, string strThumbPath, string strFileExtension)
        {
            string strPath_100_100 = strThumbPath + "_100_100" + strFileExtension;
            string strPath_310_310 = strThumbPath + "_310_310" + strFileExtension;

            SaveThumbnamilPic(imgOraginal, strPath_100_100, 100, 100, false);
            SaveThumbnamilPic(imgOraginal, strPath_310_310, 310, 310, false);           
        }
        
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="imgOraginal">原始图片路径</param>
        /// <param name="strPath">缩略图保存路径</param>
        /// <param name="maxWidth">缩略图width</param>
        /// <param name="maxHeight">缩略图height</param>
        /// <param name="WatermarkFlag">水印</param>
        private void SaveThumbnamilPic(System.Drawing.Image imgOraginal, string strPath, int maxWidth, int maxHeight, bool WatermarkFlag)
        {
            int iOraginalWidth = imgOraginal.Width;
            int iOraginalHeight = imgOraginal.Height;

            int NewImgHeight, NewImgWidth;
            if (iOraginalWidth > iOraginalHeight)
            {
                NewImgWidth = maxWidth;
                NewImgHeight = (int)(iOraginalHeight / (float)iOraginalWidth * maxWidth);
            }
            else
            {
                NewImgHeight = maxHeight;
                NewImgWidth = (int)(iOraginalWidth / (float)iOraginalHeight * maxHeight);
            }

            //如果缩略图的尺寸大于原图尺寸，则用原图片大小
            if (NewImgHeight >= iOraginalHeight && NewImgWidth >= iOraginalWidth)
            {
                NewImgHeight = iOraginalHeight;
                NewImgWidth = iOraginalWidth;
            }


            System.Drawing.Image bitmap = new System.Drawing.Bitmap(NewImgWidth, NewImgHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设定缩略图的生成质量
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.Clear(System.Drawing.Color.Transparent);
            g.DrawImage(imgOraginal, new System.Drawing.Rectangle(0, 0, NewImgWidth, NewImgHeight), new System.Drawing.Rectangle(0, 0, iOraginalWidth, iOraginalHeight), System.Drawing.GraphicsUnit.Pixel);


            //缩略图的图片名称          
            try
            {
                //保存图片
                bitmap.Save(strPath, System.Drawing.Imaging.ImageFormat.Jpeg);                
            }
            catch (Exception ex)
            {
                             
            }
            finally
            {                
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion
    }
}
