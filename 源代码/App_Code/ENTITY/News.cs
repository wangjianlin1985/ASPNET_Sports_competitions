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
    ///News ��ժҪ˵����������Ѷʵ��
    /// </summary>

    public class News
    {
        /*��Ѷid*/
        private int _newsId;
        public int newsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        /*��ѶͼƬ*/
        private string _newsPhoto;
        public string newsPhoto
        {
            get { return _newsPhoto; }
            set { _newsPhoto = value; }
        }

        /*��Ѷ����*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*��Ѷ���*/
        private int _newsTypeObj;
        public int newsTypeObj
        {
            get { return _newsTypeObj; }
            set { _newsTypeObj = value; }
        }

        /*��Ѷ����*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*�Ƿ���ʾ*/
        private string _showFlag;
        public string showFlag
        {
            get { return _showFlag; }
            set { _showFlag = value; }
        }

        /*����ʱ��*/
        private DateTime _publishDate;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

    }
}
