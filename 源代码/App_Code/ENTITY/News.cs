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
    ///News 的摘要说明：新闻资讯实体
    /// </summary>

    public class News
    {
        /*资讯id*/
        private int _newsId;
        public int newsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        /*资讯图片*/
        private string _newsPhoto;
        public string newsPhoto
        {
            get { return _newsPhoto; }
            set { _newsPhoto = value; }
        }

        /*资讯标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*资讯类别*/
        private int _newsTypeObj;
        public int newsTypeObj
        {
            get { return _newsTypeObj; }
            set { _newsTypeObj = value; }
        }

        /*资讯内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*是否显示*/
        private string _showFlag;
        public string showFlag
        {
            get { return _showFlag; }
            set { _showFlag = value; }
        }

        /*发布时间*/
        private DateTime _publishDate;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

    }
}
