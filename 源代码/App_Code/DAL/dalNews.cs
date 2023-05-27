using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*新闻资讯业务逻辑层实现*/
    public class dalNews
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加新闻资讯实现*/
        public static bool AddNews(ENTITY.News news)
        {
            string sql = "insert into News(newsPhoto,title,newsTypeObj,content,showFlag,publishDate) values(@newsPhoto,@title,@newsTypeObj,@content,@showFlag,@publishDate)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsPhoto",SqlDbType.VarChar),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@newsTypeObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@showFlag",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = news.newsPhoto; //资讯图片
            parm[1].Value = news.title; //资讯标题
            parm[2].Value = news.newsTypeObj; //资讯类别
            parm[3].Value = news.content; //资讯内容
            parm[4].Value = news.showFlag; //是否显示
            parm[5].Value = news.publishDate; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据newsId获取某条新闻资讯记录*/
        public static ENTITY.News getSomeNews(int newsId)
        {
            /*构建查询sql*/
            string sql = "select * from News where newsId=" + newsId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.News news = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                news = new ENTITY.News();
                news.newsId = Convert.ToInt32(DataRead["newsId"]);
                news.newsPhoto = DataRead["newsPhoto"].ToString();
                news.title = DataRead["title"].ToString();
                news.newsTypeObj = Convert.ToInt32(DataRead["newsTypeObj"]);
                news.content = DataRead["content"].ToString();
                news.showFlag = DataRead["showFlag"].ToString();
                news.publishDate = Convert.ToDateTime(DataRead["publishDate"].ToString());
            }
            return news;
        }

        /*更新新闻资讯实现*/
        public static bool EditNews(ENTITY.News news)
        {
            string sql = "update News set newsPhoto=@newsPhoto,title=@title,newsTypeObj=@newsTypeObj,content=@content,showFlag=@showFlag,publishDate=@publishDate where newsId=@newsId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsPhoto",SqlDbType.VarChar),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@newsTypeObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@showFlag",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@newsId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = news.newsPhoto;
            parm[1].Value = news.title;
            parm[2].Value = news.newsTypeObj;
            parm[3].Value = news.content;
            parm[4].Value = news.showFlag;
            parm[5].Value = news.publishDate;
            parm[6].Value = news.newsId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除新闻资讯*/
        public static bool DelNews(string p)
        {
            string sql = "delete from News where newsId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询新闻资讯*/
        public static DataSet GetNews(string strWhere)
        {
            try
            {
                string strSql = "select * from News" + strWhere + " order by newsId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询新闻资讯*/
        public static System.Data.DataTable GetNews(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from News";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "newsId", strShow, strSql, strWhere, " newsId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllNews()
        {
            try
            {
                string strSql = "select * from News";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
