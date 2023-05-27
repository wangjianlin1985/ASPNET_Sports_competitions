using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*资讯评论业务逻辑层实现*/
    public class dalNewsComment
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加资讯评论实现*/
        public static bool AddNewsComment(ENTITY.NewsComment newsComment)
        {
            string sql = "insert into NewsComment(newsObj,content,userObj,commentTime) values(@newsObj,@content,@userObj,@commentTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = newsComment.newsObj; //被评资讯
            parm[1].Value = newsComment.content; //评论内容
            parm[2].Value = newsComment.userObj; //评论用户
            parm[3].Value = newsComment.commentTime; //评论时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据commentId获取某条资讯评论记录*/
        public static ENTITY.NewsComment getSomeNewsComment(int commentId)
        {
            /*构建查询sql*/
            string sql = "select * from NewsComment where commentId=" + commentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.NewsComment newsComment = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                newsComment = new ENTITY.NewsComment();
                newsComment.commentId = Convert.ToInt32(DataRead["commentId"]);
                newsComment.newsObj = Convert.ToInt32(DataRead["newsObj"]);
                newsComment.content = DataRead["content"].ToString();
                newsComment.userObj = DataRead["userObj"].ToString();
                newsComment.commentTime = DataRead["commentTime"].ToString();
            }
            return newsComment;
        }

        /*更新资讯评论实现*/
        public static bool EditNewsComment(ENTITY.NewsComment newsComment)
        {
            string sql = "update NewsComment set newsObj=@newsObj,content=@content,userObj=@userObj,commentTime=@commentTime where commentId=@commentId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar),
             new SqlParameter("@commentId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = newsComment.newsObj;
            parm[1].Value = newsComment.content;
            parm[2].Value = newsComment.userObj;
            parm[3].Value = newsComment.commentTime;
            parm[4].Value = newsComment.commentId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除资讯评论*/
        public static bool DelNewsComment(string p)
        {
            string sql = "delete from NewsComment where commentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询资讯评论*/
        public static DataSet GetNewsComment(string strWhere)
        {
            try
            {
                string strSql = "select * from NewsComment" + strWhere + " order by commentId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询资讯评论*/
        public static System.Data.DataTable GetNewsComment(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from NewsComment";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "commentId", strShow, strSql, strWhere, " commentId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllNewsComment()
        {
            try
            {
                string strSql = "select * from NewsComment";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
