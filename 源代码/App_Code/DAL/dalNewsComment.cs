using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ѷ����ҵ���߼���ʵ��*/
    public class dalNewsComment
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ѷ����ʵ��*/
        public static bool AddNewsComment(ENTITY.NewsComment newsComment)
        {
            string sql = "insert into NewsComment(newsObj,content,userObj,commentTime) values(@newsObj,@content,@userObj,@commentTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = newsComment.newsObj; //������Ѷ
            parm[1].Value = newsComment.content; //��������
            parm[2].Value = newsComment.userObj; //�����û�
            parm[3].Value = newsComment.commentTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����commentId��ȡĳ����Ѷ���ۼ�¼*/
        public static ENTITY.NewsComment getSomeNewsComment(int commentId)
        {
            /*������ѯsql*/
            string sql = "select * from NewsComment where commentId=" + commentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.NewsComment newsComment = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*������Ѷ����ʵ��*/
        public static bool EditNewsComment(ENTITY.NewsComment newsComment)
        {
            string sql = "update NewsComment set newsObj=@newsObj,content=@content,userObj=@userObj,commentTime=@commentTime where commentId=@commentId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newsObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar),
             new SqlParameter("@commentId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = newsComment.newsObj;
            parm[1].Value = newsComment.content;
            parm[2].Value = newsComment.userObj;
            parm[3].Value = newsComment.commentTime;
            parm[4].Value = newsComment.commentId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ѷ����*/
        public static bool DelNewsComment(string p)
        {
            string sql = "delete from NewsComment where commentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ѷ����*/
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

        /*��ѯ��Ѷ����*/
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
