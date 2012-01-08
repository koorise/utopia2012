using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Security.Cryptography;
using GK2010.Utility;
namespace GK2010.Common
{
    /// <summary>
    /// 计算选型价格
    /// </summary>
    public class PriceHelper
    {
        #region 转换成数字，用来计算
        private static string StrToNum(Model.ProductDiy model)
        {
            string[] sFujian = model.DiyTypeAttachmentFlag.Split(',');
            string[] Fujian = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };

            for (int i = 0; i < sFujian.Length; i++)
            {
                //附件=1，2为基础部件
                if (sFujian[i] == "1")
                {
                    Fujian[i] = "0";
                }
                else
                {
                    Fujian[i] = "1";
                }
                
            }

            string result = model.DiyExpression.ToUpper();
            result = result.Replace("A", "{0}*" + Fujian[0]);
            result = result.Replace("B", "{1}*" + Fujian[1]);
            result = result.Replace("C", "{2}*" + Fujian[2]);
            result = result.Replace("D", "{3}*" + Fujian[3]);
            result = result.Replace("E", "{4}*" + Fujian[4]);
            result = result.Replace("F", "{5}*" + Fujian[5]);
            result = result.Replace("G", "{6}*" + Fujian[6]);
            result = result.Replace("H", "{7}*" + Fujian[7]);
            result = result.Replace("I", "{8}*" + Fujian[8]);
            result = result.Replace("J", "{9}*" + Fujian[9]);
            result = result.Replace("K", "{10}*" + Fujian[10]);
            result = result.Replace("L", "{11}*" + Fujian[11]);
            result = result.Replace("M", "{12}*" + Fujian[12]);
            result = result.Replace("N", "{13}*" + Fujian[13]);
            result = result.Replace("O", "{14}*" + Fujian[14]);
            result = result.Replace("P", "{15}*" + Fujian[15]);
            result = result.Replace("Q", "{16}*" + Fujian[16]);
            result = result.Replace("R", "{17}*" + Fujian[17]);
            result = result.Replace("S", "{18}*" + Fujian[18]);
            result = result.Replace("T", "{19}*" + Fujian[19]);
            result = result.Replace("U", "{20}*" + Fujian[20]);
            result = result.Replace("V", "{21}*" + Fujian[21]);
            result = result.Replace("W", "{22}*" + Fujian[22]);
            result = result.Replace("X", "{23}*" + Fujian[23]);
            result = result.Replace("Y", "{24}*" + Fujian[24]);
            result = result.Replace("Z", "{25}*" + Fujian[25]);

            return result;
        }
        #endregion

        #region 计算表达式的值
        /// <summary>
        /// 计算表达式的值
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <returns>表达式的值</returns>
        private static object Calc(string expression)
        {
            try
            {
                string className = "Calc";
                string methodName = "Run";
                expression = expression.Replace("/", "*1.0/");

                //创建编译器实例。       
                ICodeCompiler complier = (new CSharpCodeProvider().CreateCompiler());
                //设置编译参数。       
                CompilerParameters paras = new CompilerParameters();
                paras.GenerateExecutable = false;
                paras.GenerateInMemory = true;

                //创建动态代码。       
                StringBuilder classSource = new StringBuilder();
                classSource.Append("public class " + className + "\n");
                classSource.Append("{\n");
                classSource.Append(" public object " + methodName + "()\n");
                classSource.Append(" {\n");
                classSource.Append(" return " + expression + ";\n");
                classSource.Append(" }\n");
                classSource.Append("}");

                //编译代码。       
                CompilerResults result = complier.CompileAssemblyFromSource(paras, classSource.ToString());

                // 获取编译后的程序集。       
                Assembly assembly = result.CompiledAssembly;

                // 动态调用方法。       
                object eval = assembly.CreateInstance(className);
                MethodInfo method = eval.GetType().GetMethod(methodName);
                object reobj = method.Invoke(eval, null);
                GC.Collect();
                return reobj;
            }
            catch
            {
                return 0;
            }

        }
        #endregion

        #region 计算价格
        /// <summary>
        /// 计算价格
        /// </summary>
        /// <param name="model">参数</param>
        /// <returns>价格</returns>
        public static decimal GetPrice(Model.ProductDiy model)
        {
            if (model != null && model.DiyTypePrice != "")
            {
                try
                {
                    string Expression = StrToNum(model);                   
                    string Result = string.Format(Expression, model.DiyTypePrice.Split(','));
                    decimal price = DecimalHelper.Parse(Calc(Result).ToString(), 0);
                    return price;
                }
                catch
                {
                    return -1;//异常
                }
            }
            //其他
            return -2;   
        }
        #endregion

        #region 默认型号
        /// <summary>
        /// 默认型号
        /// </summary>
        /// <param name="model">参数</param>
        /// <returns>价格</returns>
        public static string GetType(Model.ProductDiy model)
        {
            string[] strDiyTypeAttachmentFlag = model.DiyTypeAttachmentFlag.Split(',');
            string[] strDiyTypeEn = model.DiyTypeEn.Split(',');
            string strRet = "";
            for (int i = 0; i < strDiyTypeAttachmentFlag.Length; i++)
            {
                if (strDiyTypeAttachmentFlag[i] == "2")
                {
                    strRet += strDiyTypeEn[i];
                }
            }

            return strRet;
        }
        #endregion


        #region  更新产品型号及价格
        /// <summary>
        /// 更新产品型号及价格
        /// </summary>
        public static bool UpdateProduct(int ProductID)
        {
            BLL.ProductParts bll = new GK2010.BLL.ProductParts();
            Model.ProductDiy model = bll.Static(ProductID);
            if (model != null)
            {
                //产品价格
                model.Price = PriceHelper.GetPrice(model);
                //产品型号
                model.Type = PriceHelper.GetType(model);
                return PriceHelper.UpdateProduct(ProductID, model);
            }
            return false;
        }
        #endregion


        #region  更新产品型号及价格
        /// <summary>
        /// 更新产品型号及价格
        /// </summary>
        public static bool UpdateProduct(int ProductID,Model.ProductDiy model)
        {
            BLL.Product bllProduct = new GK2010.BLL.Product();
            Model.Product modelProduct = bllProduct.GetModel(ProductID);
            if (modelProduct != null)
            {
                modelProduct.DiyTypeCn = model.DiyTypeCn;
                modelProduct.DiyTypeEn = model.DiyTypeEn;
                modelProduct.DiyTypePartsID = model.DiyTypePartsID;
                modelProduct.DiyTypePrice = model.DiyTypePrice;
                modelProduct.DiyTypeAttachmentFlag = model.DiyTypeAttachmentFlag;
                modelProduct.DiyTypeShowFlag = model.DiyTypeShowFlag;
                modelProduct.DiyExpression = model.DiyExpression;
                modelProduct.DefaultType = model.Type;// PriceHelper.GetType(model);//计算默认型号
                modelProduct.DefaultPrice = model.Price;

                return bllProduct.Update(modelProduct);
            }
            return false;
        }
        #endregion
    }
}
