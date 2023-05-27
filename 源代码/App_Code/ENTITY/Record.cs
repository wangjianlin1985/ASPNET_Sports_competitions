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
    ///Record ��ժҪ˵�������ս��ʵ��
    /// </summary>

    public class Record
    {
        /*��¼id*/
        private int _recordId;
        public int recordId
        {
            get { return _recordId; }
            set { _recordId = value; }
        }

        /*��������*/
        private string _contestArea;
        public string contestArea
        {
            get { return _contestArea; }
            set { _contestArea = value; }
        }

        /*�������*/
        private int _teamObj;
        public int teamObj
        {
            get { return _teamObj; }
            set { _teamObj = value; }
        }

        /*ʤ������*/
        private int _successNum;
        public int successNum
        {
            get { return _successNum; }
            set { _successNum = value; }
        }

        /*ʧ�ܳ���*/
        private int _failNum;
        public int failNum
        {
            get { return _failNum; }
            set { _failNum = value; }
        }

        /*ʤ��*/
        private string _successRate;
        public string successRate
        {
            get { return _successRate; }
            set { _successRate = value; }
        }

    }
}
