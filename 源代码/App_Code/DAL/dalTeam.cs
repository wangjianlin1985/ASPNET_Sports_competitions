using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*球队业务逻辑层实现*/
    public class dalTeam
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加球队实现*/
        public static bool AddTeam(ENTITY.Team team)
        {
            string sql = "insert into Team(teamName,teamLogo,contestArea,bornDate,teamDesc) values(@teamName,@teamLogo,@contestArea,@bornDate,@teamDesc)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teamName",SqlDbType.VarChar),
             new SqlParameter("@teamLogo",SqlDbType.VarChar),
             new SqlParameter("@contestArea",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@teamDesc",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = team.teamName; //球队名称
            parm[1].Value = team.teamLogo; //球队logo
            parm[2].Value = team.contestArea; //所在赛区
            parm[3].Value = team.bornDate; //成立日期
            parm[4].Value = team.teamDesc; //球队介绍

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据teamId获取某条球队记录*/
        public static ENTITY.Team getSomeTeam(int teamId)
        {
            /*构建查询sql*/
            string sql = "select * from Team where teamId=" + teamId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Team team = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                team = new ENTITY.Team();
                team.teamId = Convert.ToInt32(DataRead["teamId"]);
                team.teamName = DataRead["teamName"].ToString();
                team.teamLogo = DataRead["teamLogo"].ToString();
                team.contestArea = DataRead["contestArea"].ToString();
                team.bornDate = Convert.ToDateTime(DataRead["bornDate"].ToString());
                team.teamDesc = DataRead["teamDesc"].ToString();
            }
            return team;
        }

        /*更新球队实现*/
        public static bool EditTeam(ENTITY.Team team)
        {
            string sql = "update Team set teamName=@teamName,teamLogo=@teamLogo,contestArea=@contestArea,bornDate=@bornDate,teamDesc=@teamDesc where teamId=@teamId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teamName",SqlDbType.VarChar),
             new SqlParameter("@teamLogo",SqlDbType.VarChar),
             new SqlParameter("@contestArea",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@teamDesc",SqlDbType.VarChar),
             new SqlParameter("@teamId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = team.teamName;
            parm[1].Value = team.teamLogo;
            parm[2].Value = team.contestArea;
            parm[3].Value = team.bornDate;
            parm[4].Value = team.teamDesc;
            parm[5].Value = team.teamId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除球队*/
        public static bool DelTeam(string p)
        {
            string sql = "delete from Team where teamId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询球队*/
        public static DataSet GetTeam(string strWhere)
        {
            try
            {
                string strSql = "select * from Team" + strWhere + " order by teamId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询球队*/
        public static System.Data.DataTable GetTeam(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Team";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "teamId", strShow, strSql, strWhere, " teamId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTeam()
        {
            try
            {
                string strSql = "select * from Team";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
