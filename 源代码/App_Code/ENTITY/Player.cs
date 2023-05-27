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
    ///Player ��ժҪ˵������Աʵ��
    /// </summary>

    public class Player
    {
        /*��Աid*/
        private int _playerId;
        public int playerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }

        /*��Ա����*/
        private string _playerName;
        public string playerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        /*Ӣ��*/
        private string _playerEnglishName;
        public string playerEnglishName
        {
            get { return _playerEnglishName; }
            set { _playerEnglishName = value; }
        }

        /*�������*/
        private int _teamObj;
        public int teamObj
        {
            get { return _teamObj; }
            set { _teamObj = value; }
        }

        /*��Ա��Ƭ*/
        private string _playerPhoto;
        public string playerPhoto
        {
            get { return _playerPhoto; }
            set { _playerPhoto = value; }
        }

        /*��Ա����*/
        private string _playerNumber;
        public string playerNumber
        {
            get { return _playerNumber; }
            set { _playerNumber = value; }
        }

        /*��Աλ��*/
        private string _position;
        public string position
        {
            get { return _position; }
            set { _position = value; }
        }

        /*���(cm)*/
        private int _hight;
        public int hight
        {
            get { return _hight; }
            set { _hight = value; }
        }

        /*����(Kg)*/
        private float _weight;
        public float weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        /*����*/
        private int _age;
        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

        /*н��(����Ԫ)*/
        private float _salary;
        public float salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        /*�Ƿ��Ǿ���*/
        private string _superStarFlag;
        public string superStarFlag
        {
            get { return _superStarFlag; }
            set { _superStarFlag = value; }
        }

        /*��Ա����*/
        private string _playerDesc;
        public string playerDesc
        {
            get { return _playerDesc; }
            set { _playerDesc = value; }
        }

        /*¼��ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
