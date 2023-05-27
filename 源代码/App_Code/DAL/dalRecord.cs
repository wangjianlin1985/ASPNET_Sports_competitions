using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*球队战绩业务逻辑层实现*/
    public class dalRecord
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加球队战绩实现*/
        public static bool AddRecord(ENTITY.Record record)
        {
            string sql = "insert into Record(contestArea,teamObj,successNum,failNum,successRate) values(@contestArea,@teamObj,@successNum,@failNum,@successRate)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@contestArea",SqlDbType.VarChar),
             new SqlParameter("@teamObj",SqlDbType.Int),
             new SqlParameter("@successNum",SqlDbType.Int),
             new SqlParameter("@failNum",SqlDbType.Int),
             new SqlParameter("@successRate",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = record.contestArea; //所在赛区
            parm[1].Value = record.teamObj; //球队名称
            parm[2].Value = record.successNum; //胜利场数
            parm[3].Value = record.failNum; //失败场数
            parm[4].Value = record.successRate; //胜率

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据recordId获取某条球队战绩记录*/
        public static ENTITY.Record getSomeRecord(int recordId)
        {
            /*构建查询sql*/
            string sql = "select * from Record where recordId=" + recordId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Record record = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                record = new ENTITY.Record();
                record.recordId = Convert.ToInt32(DataRead["recordId"]);
                record.contestArea = DataRead["contestArea"].ToString();
                record.teamObj = Convert.ToInt32(DataRead["teamObj"]);
                record.successNum = Convert.ToInt32(DataRead["successNum"]);
                record.failNum = Convert.ToInt32(DataRead["failNum"]);
                record.successRate = DataRead["successRate"].ToString();
            }
            return record;
        }

        /*更新球队战绩实现*/
        public static bool EditRecord(ENTITY.Record record)
        {
            string sql = "update Record set contestArea=@contestArea,teamObj=@teamObj,successNum=@successNum,failNum=@failNum,successRate=@successRate where recordId=@recordId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@contestArea",SqlDbType.VarChar),
             new SqlParameter("@teamObj",SqlDbType.Int),
             new SqlParameter("@successNum",SqlDbType.Int),
             new SqlParameter("@failNum",SqlDbType.Int),
             new SqlParameter("@successRate",SqlDbType.VarChar),
             new SqlParameter("@recordId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = record.contestArea;
            parm[1].Value = record.teamObj;
            parm[2].Value = record.successNum;
            parm[3].Value = record.failNum;
            parm[4].Value = record.successRate;
            parm[5].Value = record.recordId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除球队战绩*/
        public static bool DelRecord(string p)
        {
            string sql = "delete from Record where recordId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询球队战绩*/
        public static DataSet GetRecord(string strWhere)
        {
            try
            {
                string strSql = "select * from Record" + strWhere + " order by recordId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询球队战绩*/
        public static System.Data.DataTable GetRecord(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Record";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "recordId", strShow, strSql, strWhere, " recordId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllRecord()
        {
            try
            {
                string strSql = "select * from Record";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
