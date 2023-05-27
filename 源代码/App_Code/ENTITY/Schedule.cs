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
    ///Schedule 的摘要说明：赛程实体
    /// </summary>

    public class Schedule
    {
        /*赛程id*/
        private int _scheduleId;
        public int scheduleId
        {
            get { return _scheduleId; }
            set { _scheduleId = value; }
        }

        /*对阵日期*/
        private DateTime _scheduleDate;
        public DateTime scheduleDate
        {
            get { return _scheduleDate; }
            set { _scheduleDate = value; }
        }

        /*对阵时间*/
        private string _scheduleTime;
        public string scheduleTime
        {
            get { return _scheduleTime; }
            set { _scheduleTime = value; }
        }

        /*状态*/
        private string _contestState;
        public string contestState
        {
            get { return _contestState; }
            set { _contestState = value; }
        }

        /*对阵球队1*/
        private int _team1;
        public int team1
        {
            get { return _team1; }
            set { _team1 = value; }
        }

        /*对阵球队2*/
        private int _team2;
        public int team2
        {
            get { return _team2; }
            set { _team2 = value; }
        }

        /*比赛结果*/
        private string _contestResult;
        public string contestResult
        {
            get { return _contestResult; }
            set { _contestResult = value; }
        }

    }
}
