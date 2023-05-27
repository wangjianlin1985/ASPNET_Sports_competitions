using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*资讯类别业务逻辑层实现*/
    public class dalNewsType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加资讯类别实现*/
        public static bool AddNewsType(ENTITY.NewsType newsType)
        {
            string sql = "insert into NewsType(typeName) values(@typeName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = newsType.typeName; //资讯类别名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据typeId获取某条资讯类别记录*/
        public static ENTITY.NewsType getSomeNewsType(int typeId)
        {
            /*构建查询sql*/
            string sql = "select * from NewsType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.NewsType newsType = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                newsType = new ENTITY.NewsType();
                newsType.typeId = Convert.ToInt32(DataRead["typeId"]);
                newsType.typeName = DataRead["typeName"].ToString();
            }
            return newsType;
        }

        /*更新资讯类别实现*/
        public static bool EditNewsType(ENTITY.NewsType newsType)
        {
            string sql = "update NewsType set typeName=@typeName where typeId=@typeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = newsType.typeName;
            parm[1].Value = newsType.typeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除资讯类别*/
        public static bool DelNewsType(string p)
        {
            string sql = "delete from NewsType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询资讯类别*/
        public static DataSet GetNewsType(string strWhere)
        {
            try
            {
                string strSql = "select * from NewsType" + strWhere + " order by typeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询资讯类别*/
        public static System.Data.DataTable GetNewsType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from NewsType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "typeId", strShow, strSql, strWhere, " typeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllNewsType()
        {
            try
            {
                string strSql = "select * from NewsType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
