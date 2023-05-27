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
    ///NewsComment 的摘要说明：资讯评论实体
    /// </summary>

    public class NewsComment
    {
        /*评论id*/
        private int _commentId;
        public int commentId
        {
            get { return _commentId; }
            set { _commentId = value; }
        }

        /*被评资讯*/
        private int _newsObj;
        public int newsObj
        {
            get { return _newsObj; }
            set { _newsObj = value; }
        }

        /*评论内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*评论用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*评论时间*/
        private string _commentTime;
        public string commentTime
        {
            get { return _commentTime; }
            set { _commentTime = value; }
        }

    }
}
