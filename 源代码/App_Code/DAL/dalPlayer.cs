using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Աҵ���߼���ʵ��*/
    public class dalPlayer
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Աʵ��*/
        public static bool AddPlayer(ENTITY.Player player)
        {
            string sql = "insert into Player(playerName,playerEnglishName,teamObj,playerPhoto,playerNumber,position,hight,weight,age,salary,superStarFlag,playerDesc,addTime) values(@playerName,@playerEnglishName,@teamObj,@playerPhoto,@playerNumber,@position,@hight,@weight,@age,@salary,@superStarFlag,@playerDesc,@addTime)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = player.playerName; //��Ա����
            parm[1].Value = player.playerEnglishName; //Ӣ��
            parm[2].Value = player.teamObj; //�������
            parm[3].Value = player.playerPhoto; //��Ա��Ƭ
            parm[4].Value = player.playerNumber; //��Ա����
            parm[5].Value = player.position; //��Աλ��
            parm[6].Value = player.hight; //���(cm)
            parm[7].Value = player.weight; //����(Kg)
            parm[8].Value = player.age; //����
            parm[9].Value = player.salary; //н��(����Ԫ)
            parm[10].Value = player.superStarFlag; //�Ƿ��Ǿ���
            parm[11].Value = player.playerDesc; //��Ա����
            parm[12].Value = player.addTime; //¼��ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����playerId��ȡĳ����Ա��¼*/
        public static ENTITY.Player getSomePlayer(int playerId)
        {
            /*������ѯsql*/
            string sql = "select * from Player where playerId=" + playerId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Player player = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*������Աʵ��*/
        public static bool EditPlayer(ENTITY.Player player)
        {
            string sql = "update Player set playerName=@playerName,playerEnglishName=@playerEnglishName,teamObj=@teamObj,playerPhoto=@playerPhoto,playerNumber=@playerNumber,position=@position,hight=@hight,weight=@weight,age=@age,salary=@salary,superStarFlag=@superStarFlag,playerDesc=@playerDesc,addTime=@addTime where playerId=@playerId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
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
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ա*/
        public static bool DelPlayer(string p)
        {
            string sql = "delete from Player where playerId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ա*/
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

        /*��ѯ��Ա*/
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
