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
    public partial class NewsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindnewsTypeObj();
                string sqlstr = " where 1=1 ";
                if (Request["title"] != null && Request["title"].ToString() != "")
                {
                    sqlstr += "  and title like '%" + Request["title"].ToString() + "%'";
                    title.Text = Request["title"].ToString();
                }
                if (Request["newsTypeObj"] != null && Request["newsTypeObj"].ToString() != "0")
                {
                    sqlstr += "  and newsTypeObj=" + Request["newsTypeObj"].ToString();
                    newsTypeObj.SelectedValue = Request["newsTypeObj"].ToString();
                }
                if (Request["showFlag"] != null && Request["showFlag"].ToString() != "")
                {
                    sqlstr += "  and showFlag like '%" + Request["showFlag"].ToString() + "%'";
                    showFlag.Text = Request["showFlag"].ToString();
                }
                if (Request["publishDate"] != null && Request["publishDate"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,publishDate,120) like '" + Request["publishDate"].ToString() + "%'";
                    publishDate.Text = Request["publishDate"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindnewsTypeObj()
        {
            ListItem li = new ListItem("不限制", "0");
            newsTypeObj.Items.Add(li);
            DataSet newsTypeObjDs = BLL.bllNewsType.getAllNewsType();
            for (int i = 0; i < newsTypeObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = newsTypeObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["typeName"].ToString(), dr["typeName"].ToString());
                newsTypeObj.Items.Add(li);
            }
            newsTypeObj.SelectedValue = "0";
        }

        protected void BtnNewsAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllNews.DelNews(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "NewsList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllNews.GetNews(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpNews.DataSource = dsLog;
            RpNews.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpNews_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllNews.DelNews((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "NewsList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "NewsList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "NewsList.aspx");
                }
            }
        }
        public string GetNewsTypenewsTypeObj(string newsTypeObj)
        {
            return BLL.bllNewsType.getSomeNewsType(int.Parse(newsTypeObj)).typeName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsList.aspx?title=" + title.Text.Trim()  + "&&newsTypeObj=" + newsTypeObj.SelectedValue.Trim()+ "&&showFlag=" + showFlag.Text.Trim()+ "&&publishDate=" + publishDate.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet newsDataSet = BLL.bllNews.GetNews(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>新闻资讯记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>资讯id</th>");
            sb.Append("<th>资讯图片</th>");
            sb.Append("<th>资讯标题</th>");
            sb.Append("<th>资讯类别</th>");
            sb.Append("<th>是否显示</th>");
            sb.Append("<th>发布时间</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < newsDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = newsDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["newsId"].ToString() + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["newsPhoto"].ToString() + "'/></span></td>");
                sb.Append("<td>" + dr["title"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllNewsType.getSomeNewsType(Convert.ToInt32(dr["newsTypeObj"])).typeName + "</td>");
                sb.Append("<td>" + dr["showFlag"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["publishDate"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "新闻资讯记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
