using System;
using System.Collections.Generic;
using System.Text;

namespace GK2010.Model
{
   public class MemberProvince
    {
        #region Model
        private int _id;
        private string _provincename;
        private string _provinceid;
        private decimal _sortid;
        private int _deleteflag;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 省名
        /// </summary>
        public string ProvinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
        }
        /// <summary>
        /// 省编号
        /// </summary>
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeleteFlag
        {
            set { _deleteflag = value; }
            get { return _deleteflag; }
        }
        #endregion Model
    }
}
