using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ƶҵ���߼���ʵ��*/
    public class dalVideo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ƶʵ��*/
        public static bool AddVideo(ENTITY.Video video)
        {
            string sql = "insert into Video(title,videoPhoto,videoDesc,videoFile,addTime) values(@title,@videoPhoto,@videoDesc,@videoFile,@addTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@videoPhoto",SqlDbType.VarChar),
             new SqlParameter("@videoDesc",SqlDbType.VarChar),
             new SqlParameter("@videoFile",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = video.title; //��Ƶ����
            parm[1].Value = video.videoPhoto; //��Ƶ��ͼ
            parm[2].Value = video.videoDesc; //��Ƶ����
            parm[3].Value = video.videoFile; //��Ƶ�ļ�
            parm[4].Value = video.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����videoId��ȡĳ����Ƶ��¼*/
        public static ENTITY.Video getSomeVideo(int videoId)
        {
            /*������ѯsql*/
            string sql = "select * from Video where videoId=" + videoId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Video video = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                video = new ENTITY.Video();
                video.videoId = Convert.ToInt32(DataRead["videoId"]);
                video.title = DataRead["title"].ToString();
                video.videoPhoto = DataRead["videoPhoto"].ToString();
                video.videoDesc = DataRead["videoDesc"].ToString();
                video.videoFile = DataRead["videoFile"].ToString();
                video.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return video;
        }

        /*������Ƶʵ��*/
        public static bool EditVideo(ENTITY.Video video)
        {
            string sql = "update Video set title=@title,videoPhoto=@videoPhoto,videoDesc=@videoDesc,videoFile=@videoFile,addTime=@addTime where videoId=@videoId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@videoPhoto",SqlDbType.VarChar),
             new SqlParameter("@videoDesc",SqlDbType.VarChar),
             new SqlParameter("@videoFile",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@videoId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = video.title;
            parm[1].Value = video.videoPhoto;
            parm[2].Value = video.videoDesc;
            parm[3].Value = video.videoFile;
            parm[4].Value = video.addTime;
            parm[5].Value = video.videoId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ƶ*/
        public static bool DelVideo(string p)
        {
            string sql = "delete from Video where videoId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ƶ*/
        public static DataSet GetVideo(string strWhere)
        {
            try
            {
                string strSql = "select * from Video" + strWhere + " order by videoId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��Ƶ*/
        public static System.Data.DataTable GetVideo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Video";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "videoId", strShow, strSql, strWhere, " videoId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllVideo()
        {
            try
            {
                string strSql = "select * from Video";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
