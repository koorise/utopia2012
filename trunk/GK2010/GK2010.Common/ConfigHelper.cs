using System.Web;
using System.Text;
using System.Security.Cryptography;
/// <summary>
/// ≈‰÷√≤Œ ˝
/// </summary>
namespace GK2010.Common
{
    public class ConfigHelper
    {
       

        public static Model.Config Config
        {    
           get
           {
                GK2010.BLL.Config bll = new GK2010.BLL.Config();
                GK2010.Model.Config model = bll.GetModel();
                if (model != null)
                {
                    return model;
                }
                else
                {
                    model = new GK2010.Model.Config();
                    return model;
                }
            }
        }

    }
}