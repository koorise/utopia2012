using System;
using System.Collections.Generic;
using System.Text;

namespace GK2010.Model
{
   public class MemberCity
    {
        #region Model
        private int _id;
        private string _provinceid;
        private string _cityname;
        private string _cityid;
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
        /// 
        /// </summary>
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
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
