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
    ///Team ��ժҪ˵�������ʵ��
    /// </summary>

    public class Team
    {
        /*���id*/
        private int _teamId;
        public int teamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }

        /*�������*/
        private string _teamName;
        public string teamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        /*���logo*/
        private string _teamLogo;
        public string teamLogo
        {
            get { return _teamLogo; }
            set { _teamLogo = value; }
        }

        /*��������*/
        private string _contestArea;
        public string contestArea
        {
            get { return _contestArea; }
            set { _contestArea = value; }
        }

        /*��������*/
        private DateTime _bornDate;
        public DateTime bornDate
        {
            get { return _bornDate; }
            set { _bornDate = value; }
        }

        /*��ӽ���*/
        private string _teamDesc;
        public string teamDesc
        {
            get { return _teamDesc; }
            set { _teamDesc = value; }
        }

    }
}
