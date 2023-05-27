using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*球员业务逻辑层实现*/
    public class dalPlayer
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加球员实现*/
        public static bool AddPlayer(ENTITY.Player player)
        {
            string sql = "insert into Player(playerName,playerEnglishName,teamObj,playerPhoto,playerNumber,position,hight,weight,age,salary,superStarFlag,playerDesc,addTime) values(@playerName,@playerEnglishName,@teamObj,@playerPhoto,@playerNumber,@position,@hight,@weight,@age,@salary,@superStarFlag,@playerDesc,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@playerName",SqlDbType.VarChar),
             new SqlParameter("@playerEnglishName",SqlDbType.VarChar),
             new SqlParameter("@teamObj",SqlDbType.Int),
             new SqlParameter("@playerPhoto",SqlDbType.VarChar),
             new SqlParameter("@playerNumber",SqlDbType.VarChar),
             new SqlParameter("@position",SqlDbType.VarChar),
             new SqlParameter("@hight",SqlDbType.Int),
             new SqlParameter("@weight",SqlDbType.Float),
             new SqlParameter("@age",SqlDbType.Int),
             new SqlParameter("@salary",SqlDbType.Float),
             new SqlParameter("@superStarFlag",SqlDbType.VarChar),
             new SqlParameter("@playerDesc",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = player.playerName; //球员姓名
            parm[1].Value = player.playerEnglishName; //英文
            parm[2].Value = player.teamObj; //所在球队
            parm[3].Value = player.playerPhoto; //球员照片
            parm[4].Value = player.playerNumber; //球员号码
            parm[5].Value = player.position; //球员位置
            parm[6].Value = player.hight; //身高(cm)
            parm[7].Value = player.weight; //体重(Kg)
            parm[8].Value = player.age; //年龄
            parm[9].Value = player.salary; //薪资(万美元)
            parm[10].Value = player.superStarFlag; //是否是巨星
            parm[11].Value = player.playerDesc; //球员介绍
            parm[12].Value = player.addTime; //录入时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据playerId获取某条球员记录*/
        public static ENTITY.Player getSomePlayer(int playerId)
        {
            /*构建查询sql*/
            string sql = "select * from Player where playerId=" + playerId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Player player = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                player = new ENTITY.Player();
                player.playerId = Convert.ToInt32(DataRead["playerId"]);
                player.playerName = DataRead["playerName"].ToString();
                player.playerEnglishName = DataRead["playerEnglishName"].ToString();
                player.teamObj = Convert.ToInt32(DataRead["teamObj"]);
                player.playerPhoto = DataRead["playerPhoto"].ToString();
                player.playerNumber = DataRead["playerNumber"].ToString();
                player.position = DataRead["position"].ToString();
                player.hight = Convert.ToInt32(DataRead["hight"]);
                player.weight = float.Parse(DataRead["weight"].ToString());
                player.age = Convert.ToInt32(DataRead["age"]);
                player.salary = float.Parse(DataRead["salary"].ToString());
                player.superStarFlag = DataRead["superStarFlag"].ToString();
                player.playerDesc = DataRead["playerDesc"].ToString();
                player.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return player;
        }

        /*更新球员实现*/
        public static bool EditPlayer(ENTITY.Player player)
        {
            string sql = "update Player set playerName=@playerName,playerEnglishName=@playerEnglishName,teamObj=@teamObj,playerPhoto=@playerPhoto,playerNumber=@playerNumber,position=@position,hight=@hight,weight=@weight,age=@age,salary=@salary,superStarFlag=@superStarFlag,playerDesc=@playerDesc,addTime=@addTime where playerId=@playerId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@playerName",SqlDbType.VarChar),
             new SqlParameter("@playerEnglishName",SqlDbType.VarChar),
             new SqlParameter("@teamObj",SqlDbType.Int),
             new SqlParameter("@playerPhoto",SqlDbType.VarChar),
             new SqlParameter("@playerNumber",SqlDbType.VarChar),
             new SqlParameter("@position",SqlDbType.VarChar),
             new SqlParameter("@hight",SqlDbType.Int),
             new SqlParameter("@weight",SqlDbType.Float),
             new SqlParameter("@age",SqlDbType.Int),
             new SqlParameter("@salary",SqlDbType.Float),
             new SqlParameter("@superStarFlag",SqlDbType.VarChar),
             new SqlParameter("@playerDesc",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@playerId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = player.playerName;
            parm[1].Value = player.playerEnglishName;
            parm[2].Value = player.teamObj;
            parm[3].Value = player.playerPhoto;
            parm[4].Value = player.playerNumber;
            parm[5].Value = player.position;
            parm[6].Value = player.hight;
            parm[7].Value = player.weight;
            parm[8].Value = player.age;
            parm[9].Value = player.salary;
            parm[10].Value = player.superStarFlag;
            parm[11].Value = player.playerDesc;
            parm[12].Value = player.addTime;
            parm[13].Value = player.playerId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除球员*/
        public static bool DelPlayer(string p)
        {
            string sql = "delete from Player where playerId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询球员*/
        public static DataSet GetPlayer(string strWhere)
        {
            try
            {
                string strSql = "select * from Player" + strWhere + " order by playerId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询球员*/
        public static System.Data.DataTable GetPlayer(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Player";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "playerId", strShow, strSql, strWhere, " playerId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllPlayer()
        {
            try
            {
                string strSql = "select * from Player";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
