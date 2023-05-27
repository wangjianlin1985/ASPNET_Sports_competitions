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
    ///Player 的摘要说明：球员实体
    /// </summary>

    public class Player
    {
        /*球员id*/
        private int _playerId;
        public int playerId
        {
            get { return _playerId; }
            set { _playerId = value; }
        }

        /*球员姓名*/
        private string _playerName;
        public string playerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        /*英文*/
        private string _playerEnglishName;
        public string playerEnglishName
        {
            get { return _playerEnglishName; }
            set { _playerEnglishName = value; }
        }

        /*所在球队*/
        private int _teamObj;
        public int teamObj
        {
            get { return _teamObj; }
            set { _teamObj = value; }
        }

        /*球员照片*/
        private string _playerPhoto;
        public string playerPhoto
        {
            get { return _playerPhoto; }
            set { _playerPhoto = value; }
        }

        /*球员号码*/
        private string _playerNumber;
        public string playerNumber
        {
            get { return _playerNumber; }
            set { _playerNumber = value; }
        }

        /*球员位置*/
        private string _position;
        public string position
        {
            get { return _position; }
            set { _position = value; }
        }

        /*身高(cm)*/
        private int _hight;
        public int hight
        {
            get { return _hight; }
            set { _hight = value; }
        }

        /*体重(Kg)*/
        private float _weight;
        public float weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        /*年龄*/
        private int _age;
        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

        /*薪资(万美元)*/
        private float _salary;
        public float salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        /*是否是巨星*/
        private string _superStarFlag;
        public string superStarFlag
        {
            get { return _superStarFlag; }
            set { _superStarFlag = value; }
        }

        /*球员介绍*/
        private string _playerDesc;
        public string playerDesc
        {
            get { return _playerDesc; }
            set { _playerDesc = value; }
        }

        /*录入时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
