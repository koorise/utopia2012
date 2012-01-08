using System;
namespace GK2010.Model
{
	/// <summary>
    /// File
	/// </summary>
	[Serializable]
	public class File
	{
        public File()
		{}
		#region Model
     
        private string _PictureSmall = "";
        private string _PictureNormal = "";
        private string _PictureBig = "";

        public string PictureSmall
		{
            set { _PictureSmall = value; }
            get { return _PictureSmall; }
		}
		/// <summary>
		/// 
		/// </summary>
        public string PictureNormal
		{
            set { _PictureNormal = value; }
            get { return _PictureNormal; }
		}
		/// <summary>
		/// 
		/// </summary>
        public string PictureBig
		{
            set { _PictureBig = value; }
            get { return _PictureBig; }
		}
		#endregion Model

	}
}

