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
    public partial class ScheduleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                Bindteam1();
                Bindteam2();
                string sqlstr = " where 1=1 ";
                if (Request["scheduleDate"] != null && Request["scheduleDate"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,scheduleDate,120) like '" + Request["scheduleDate"].ToString() + "%'";
                    scheduleDate.Text = Request["scheduleDate"].ToString();
                }
                if (Request["contestState"] != null && Request["contestState"].ToString() != "")
                {
                    sqlstr += "  and contestState like '%" + Request["contestState"].ToString() + "%'";
                    contestState.Text = Request["contestState"].ToString();
                }
                if (Request["team1"] != null && Request["team1"].ToString() != "0")
                {
                    sqlstr += "  and team1=" + Request["team1"].ToString();
                    team1.SelectedValue = Request["team1"].ToString();
                }
                if (Request["team2"] != null && Request["team2"].ToString() != "0")
                {
                    sqlstr += "  and team2=" + Request["team2"].ToString();
                    team2.SelectedValue = Request["team2"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void Bindteam1()
        {
            ListItem li = new ListItem("不限制", "0");
            team1.Items.Add(li);
            DataSet team1Ds = BLL.bllTeam.getAllTeam();
            for (int i = 0; i < team1Ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = team1Ds.Tables[0].Rows[i];
                li = new ListItem(dr["teamName"].ToString(), dr["teamName"].ToString());
                team1.Items.Add(li);
            }
            team1.SelectedValue = "0";
        }

        private void Bindteam2()
        {
            ListItem li = new ListItem("不限制", "0");
            team2.Items.Add(li);
            DataSet team2Ds = BLL.bllTeam.getAllTeam();
            for (int i = 0; i < team2Ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = team2Ds.Tables[0].Rows[i];
                li = new ListItem(dr["teamName"].ToString(), dr["teamName"].ToString());
                team2.Items.Add(li);
            }
            team2.SelectedValue = "0";
        }

        protected void BtnScheduleAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScheduleEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllSchedule.DelSchedule(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "ScheduleList.aspx");
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
            DataTable dsLog = BLL.bllSchedule.GetSchedule(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpSchedule.DataSource = dsLog;
            RpSchedule.DataBind();
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
        protected void RpSchedule_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllSchedule.DelSchedule((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "ScheduleList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "ScheduleList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "ScheduleList.aspx");
                }
            }
        }
        public string GetTeamteam1(string team1)
        {
            return BLL.bllTeam.getSomeTeam(int.Parse(team1)).teamName;
        }

        public string GetTeamteam2(string team2)
        {
            return BLL.bllTeam.getSomeTeam(int.Parse(team2)).teamName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScheduleList.aspx?scheduleDate=" + scheduleDate.Text.Trim() + "&&contestState=" + contestState.Text.Trim() + "&&team1=" + team1.SelectedValue.Trim() + "&&team2=" + team2.SelectedValue.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet scheduleDataSet = BLL.bllSchedule.GetSchedule(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='7'>赛程记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>赛程id</th>");
            sb.Append("<th>对阵日期</th>");
            sb.Append("<th>对阵时间</th>");
            sb.Append("<th>状态</th>");
            sb.Append("<th>对阵球队1</th>");
            sb.Append("<th>对阵球队2</th>");
            sb.Append("<th>比赛结果</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < scheduleDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = scheduleDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["scheduleId"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["scheduleDate"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["scheduleTime"].ToString() + "</td>");
                sb.Append("<td>" + dr["contestState"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllTeam.getSomeTeam(Convert.ToInt32(dr["team1"])).teamName + "</td>");
                sb.Append("<td>" + BLL.bllTeam.getSomeTeam(Convert.ToInt32(dr["team2"])).teamName + "</td>");
                sb.Append("<td>" + dr["contestResult"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "赛程记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
