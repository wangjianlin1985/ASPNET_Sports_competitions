using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class NewsCommentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindNewsnewsObj();
                BindUserInfouserObj();
                if (Request["commentId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindNewsnewsObj()
        {
            newsObj.DataSource = BLL.bllNews.getAllNews();
            newsObj.DataTextField = "title";
            newsObj.DataValueField = "newsId";
            newsObj.DataBind();
        }

        private void BindUserInfouserObj()
        {
            userObj.DataSource = BLL.bllUserInfo.getAllUserInfo();
            userObj.DataTextField = "name";
            userObj.DataValueField = "user_name";
            userObj.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "commentId")))
            {
                ENTITY.NewsComment newsComment = BLL.bllNewsComment.getSomeNewsComment(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "commentId")));
                newsObj.SelectedValue = newsComment.newsObj.ToString();
                content.Value = newsComment.content;
                userObj.SelectedValue = newsComment.userObj;
                commentTime.Value = newsComment.commentTime;
            }
        }

        protected void BtnNewsCommentSave_Click(object sender, EventArgs e)
        {
            ENTITY.NewsComment newsComment = new ENTITY.NewsComment();
            newsComment.newsObj = int.Parse(newsObj.SelectedValue);
            newsComment.content = content.Value;
            newsComment.userObj = userObj.SelectedValue;
            newsComment.commentTime = commentTime.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "commentId")))
            {
                newsComment.commentId = int.Parse(Request["commentId"]);
                if (BLL.bllNewsComment.EditNewsComment(newsComment))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"NewsCommentEdit.aspx?commentId=" + Request["commentId"] + "\"} else  {location.href=\"NewsCommentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllNewsComment.AddNewsComment(newsComment))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"NewsCommentEdit.aspx\"} else  {location.href=\"NewsCommentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsCommentList.aspx");
        }
    }
}

