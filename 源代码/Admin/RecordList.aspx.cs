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
    public partial class RecordList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindteamObj();
                string sqlstr = " where 1=1 ";
                if (Request["contestArea"] != null && Request["contestArea"].ToString() != "")
                {
                    sqlstr += "  and contestArea like '%" + Request["contestArea"].ToString() + "%'";
                    contestArea.Text = Request["contestArea"].ToString();
                }
                if (Request["teamObj"] != null && Request["teamObj"].ToString() != "0")
                {
                    sqlstr += "  and teamObj=" + Request["teamObj"].ToString();
                    teamObj.SelectedValue = Request["teamObj"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindteamObj()
        {
            ListItem li = new ListItem("不限制", "0");
            teamObj.Items.Add(li);
            DataSet teamObjDs = BLL.bllTeam.getAllTeam();
            for (int i = 0; i < teamObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = teamObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["teamName"].ToString(), dr["teamName"].ToString());
                teamObj.Items.Add(li);
            }
            teamObj.SelectedValue = "0";
        }

        protected void BtnRecordAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecordEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllRecord.DelRecord(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "RecordList.aspx");
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
            DataTable dsLog = BLL.bllRecord.GetRecord(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpRecord.DataSource = dsLog;
            RpRecord.DataBind();
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
        protected void RpRecord_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllRecord.DelRecord((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "RecordList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "RecordList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "RecordList.aspx");
                }
            }
        }
        public string GetTeamteamObj(string teamObj)
        {
            return BLL.bllTeam.getSomeTeam(int.Parse(teamObj)).teamName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecordList.aspx?contestArea=" + contestArea.Text.Trim()  + "&&teamObj=" + teamObj.SelectedValue.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet recordDataSet = BLL.bllRecord.GetRecord(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>球队战绩记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>记录id</th>");
            sb.Append("<th>所在赛区</th>");
            sb.Append("<th>球队名称</th>");
            sb.Append("<th>胜利场数</th>");
            sb.Append("<th>失败场数</th>");
            sb.Append("<th>胜率</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < recordDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = recordDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["recordId"].ToString() + "</td>");
                sb.Append("<td>" + dr["contestArea"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllTeam.getSomeTeam(Convert.ToInt32(dr["teamObj"])).teamName + "</td>");
                sb.Append("<td>" + dr["successNum"].ToString() + "</td>");
                sb.Append("<td>" + dr["failNum"].ToString() + "</td>");
                sb.Append("<td>" + dr["successRate"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "球队战绩记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
