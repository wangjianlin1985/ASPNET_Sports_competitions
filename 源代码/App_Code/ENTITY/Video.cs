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
    ///Video ��ժҪ˵������Ƶʵ��
    /// </summary>

    public class Video
    {
        /*��Ƶid*/
        private int _videoId;
        public int videoId
        {
            get { return _videoId; }
            set { _videoId = value; }
        }

        /*��Ƶ����*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*��Ƶ��ͼ*/
        private string _videoPhoto;
        public string videoPhoto
        {
            get { return _videoPhoto; }
            set { _videoPhoto = value; }
        }

        /*��Ƶ����*/
        private string _videoDesc;
        public string videoDesc
        {
            get { return _videoDesc; }
            set { _videoDesc = value; }
        }

        /*��Ƶ�ļ�*/
        private string _videoFile;
        public string videoFile
        {
            get { return _videoFile; }
            set { _videoFile = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
