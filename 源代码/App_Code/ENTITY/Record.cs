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
    ///Record 的摘要说明：球队战绩实体
    /// </summary>

    public class Record
    {
        /*记录id*/
        private int _recordId;
        public int recordId
        {
            get { return _recordId; }
            set { _recordId = value; }
        }

        /*所在赛区*/
        private string _contestArea;
        public string contestArea
        {
            get { return _contestArea; }
            set { _contestArea = value; }
        }

        /*球队名称*/
        private int _teamObj;
        public int teamObj
        {
            get { return _teamObj; }
            set { _teamObj = value; }
        }

        /*胜利场数*/
        private int _successNum;
        public int successNum
        {
            get { return _successNum; }
            set { _successNum = value; }
        }

        /*失败场数*/
        private int _failNum;
        public int failNum
        {
            get { return _failNum; }
            set { _failNum = value; }
        }

        /*胜率*/
        private string _successRate;
        public string successRate
        {
            get { return _successRate; }
            set { _successRate = value; }
        }

    }
}
