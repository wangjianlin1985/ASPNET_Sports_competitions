using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///Video 的摘要说明：视频实体
    /// </summary>

    public class Video
    {
        /*视频id*/
        private int _videoId;
        public int videoId
        {
            get { return _videoId; }
            set { _videoId = value; }
        }

        /*视频标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*视频主图*/
        private string _videoPhoto;
        public string videoPhoto
        {
            get { return _videoPhoto; }
            set { _videoPhoto = value; }
        }

        /*视频介绍*/
        private string _videoDesc;
        public string videoDesc
        {
            get { return _videoDesc; }
            set { _videoDesc = value; }
        }

        /*视频文件*/
        private string _videoFile;
        public string videoFile
        {
            get { return _videoFile; }
            set { _videoFile = value; }
        }

        /*发布时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
