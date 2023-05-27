using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*赛程业务逻辑层实现*/
    public class dalSchedule
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加赛程实现*/
        public static bool AddSchedule(ENTITY.Schedule schedule)
        {
            string sql = "insert into Schedule(scheduleDate,scheduleTime,contestState,team1,team2,contestResult) values(@scheduleDate,@scheduleTime,@contestState,@team1,@team2,@contestResult)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@scheduleDate",SqlDbType.DateTime),
             new SqlParameter("@scheduleTime",SqlDbType.VarChar),
             new SqlParameter("@contestState",SqlDbType.VarChar),
             new SqlParameter("@team1",SqlDbType.Int),
             new SqlParameter("@team2",SqlDbType.Int),
             new SqlParameter("@contestResult",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = schedule.scheduleDate; //对阵日期
            parm[1].Value = schedule.scheduleTime; //对阵时间
            parm[2].Value = schedule.contestState; //状态
            parm[3].Value = schedule.team1; //对阵球队1
            parm[4].Value = schedule.team2; //对阵球队2
            parm[5].Value = schedule.contestResult; //比赛结果

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据scheduleId获取某条赛程记录*/
        public static ENTITY.Schedule getSomeSchedule(int scheduleId)
        {
            /*构建查询sql*/
            string sql = "select * from Schedule where scheduleId=" + scheduleId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Schedule schedule = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                schedule = new ENTITY.Schedule();
                schedule.scheduleId = Convert.ToInt32(DataRead["scheduleId"]);
                schedule.scheduleDate = Convert.ToDateTime(DataRead["scheduleDate"].ToString());
                schedule.scheduleTime = DataRead["scheduleTime"].ToString();
                schedule.contestState = DataRead["contestState"].ToString();
                schedule.team1 = Convert.ToInt32(DataRead["team1"]);
                schedule.team2 = Convert.ToInt32(DataRead["team2"]);
                schedule.contestResult = DataRead["contestResult"].ToString();
            }
            return schedule;
        }

        /*更新赛程实现*/
        public static bool EditSchedule(ENTITY.Schedule schedule)
        {
            string sql = "update Schedule set scheduleDate=@scheduleDate,scheduleTime=@scheduleTime,contestState=@contestState,team1=@team1,team2=@team2,contestResult=@contestResult where scheduleId=@scheduleId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@scheduleDate",SqlDbType.DateTime),
             new SqlParameter("@scheduleTime",SqlDbType.VarChar),
             new SqlParameter("@contestState",SqlDbType.VarChar),
             new SqlParameter("@team1",SqlDbType.Int),
             new SqlParameter("@team2",SqlDbType.Int),
             new SqlParameter("@contestResult",SqlDbType.VarChar),
             new SqlParameter("@scheduleId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = schedule.scheduleDate;
            parm[1].Value = schedule.scheduleTime;
            parm[2].Value = schedule.contestState;
            parm[3].Value = schedule.team1;
            parm[4].Value = schedule.team2;
            parm[5].Value = schedule.contestResult;
            parm[6].Value = schedule.scheduleId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除赛程*/
        public static bool DelSchedule(string p)
        {
            string sql = "delete from Schedule where scheduleId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询赛程*/
        public static DataSet GetSchedule(string strWhere)
        {
            try
            {
                string strSql = "select * from Schedule" + strWhere + " order by scheduleId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询赛程*/
        public static System.Data.DataTable GetSchedule(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Schedule";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "scheduleId", strShow, strSql, strWhere, " scheduleId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllSchedule()
        {
            try
            {
                string strSql = "select * from Schedule";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
