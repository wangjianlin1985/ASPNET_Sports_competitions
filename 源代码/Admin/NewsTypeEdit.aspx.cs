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
    public partial class NewsTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["typeId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "typeId")))
            {
                ENTITY.NewsType newsType = BLL.bllNewsType.getSomeNewsType(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "typeId")));
                typeName.Value = newsType.typeName;
            }
        }

        protected void BtnNewsTypeSave_Click(object sender, EventArgs e)
        {
            ENTITY.NewsType newsType = new ENTITY.NewsType();
            newsType.typeName = typeName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "typeId")))
            {
                newsType.typeId = int.Parse(Request["typeId"]);
                if (BLL.bllNewsType.EditNewsType(newsType))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"NewsTypeEdit.aspx?typeId=" + Request["typeId"] + "\"} else  {location.href=\"NewsTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllNewsType.AddNewsType(newsType))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"NewsTypeEdit.aspx\"} else  {location.href=\"NewsTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsTypeList.aspx");
        }
    }
}

