using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*������Ѷҵ���߼���ʵ��*/
    public class dalNews
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���������Ѷʵ��*/
        public static bool AddNews(ENTITY.News news)
        {
            string sql = "insert into News(newsPhoto,title,newsTypeObj,content,showFlag,publishDate) values(@newsPhoto,@title,@newsTypeObj,@content,@showFlag,@publishDate)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsPhoto",SqlDbType.VarChar),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@newsTypeObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@showFlag",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = news.newsPhoto; //��ѶͼƬ
            parm[1].Value = news.title; //��Ѷ����
            parm[2].Value = news.newsTypeObj; //��Ѷ���
            parm[3].Value = news.content; //��Ѷ����
            parm[4].Value = news.showFlag; //�Ƿ���ʾ
            parm[5].Value = news.publishDate; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����newsId��ȡĳ��������Ѷ��¼*/
        public static ENTITY.News getSomeNews(int newsId)
        {
            /*������ѯsql*/
            string sql = "select * from News where newsId=" + newsId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.News news = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*����������Ѷʵ��*/
        public static bool EditNews(ENTITY.News news)
        {
            string sql = "update News set newsPhoto=@newsPhoto,title=@title,newsTypeObj=@newsTypeObj,content=@content,showFlag=@showFlag,publishDate=@publishDate where newsId=@newsId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsPhoto",SqlDbType.VarChar),
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@newsTypeObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@showFlag",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@newsId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = news.newsPhoto;
            parm[1].Value = news.title;
            parm[2].Value = news.newsTypeObj;
            parm[3].Value = news.content;
            parm[4].Value = news.showFlag;
            parm[5].Value = news.publishDate;
            parm[6].Value = news.newsId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��������Ѷ*/
        public static bool DelNews(string p)
        {
            string sql = "delete from News where newsId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ������Ѷ*/
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

        /*��ѯ������Ѷ*/
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
