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
    ///Schedule ��ժҪ˵��������ʵ��
    /// </summary>

    public class Schedule
    {
        /*����id*/
        private int _scheduleId;
        public int scheduleId
        {
            get { return _scheduleId; }
            set { _scheduleId = value; }
        }

        /*��������*/
        private DateTime _scheduleDate;
        public DateTime scheduleDate
        {
            get { return _scheduleDate; }
            set { _scheduleDate = value; }
        }

        /*����ʱ��*/
        private string _scheduleTime;
        public string scheduleTime
        {
            get { return _scheduleTime; }
            set { _scheduleTime = value; }
        }

        /*״̬*/
        private string _contestState;
        public string contestState
        {
            get { return _contestState; }
            set { _contestState = value; }
        }

        /*�������1*/
        private int _team1;
        public int team1
        {
            get { return _team1; }
            set { _team1 = value; }
        }

        /*�������2*/
        private int _team2;
        public int team2
        {
            get { return _team2; }
            set { _team2 = value; }
        }

        /*�������*/
        private string _contestResult;
        public string contestResult
        {
            get { return _contestResult; }
            set { _contestResult = value; }
        }

    }
}
