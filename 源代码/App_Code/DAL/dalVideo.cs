using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*视频业务逻辑层实现*/
    public class dalVideo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加视频实现*/
        public static bool AddVideo(ENTITY.Video video)
        {
            string sql = "insert into Video(title,videoPhoto,videoDesc,videoFile,addTime) values(@title,@videoPhoto,@videoDesc,@videoFile,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@videoPhoto",SqlDbType.VarChar),
             new SqlParameter("@videoDesc",SqlDbType.VarChar),
             new SqlParameter("@videoFile",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = video.title; //视频标题
            parm[1].Value = video.videoPhoto; //视频主图
            parm[2].Value = video.videoDesc; //视频介绍
            parm[3].Value = video.videoFile; //视频文件
            parm[4].Value = video.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据videoId获取某条视频记录*/
        public static ENTITY.Video getSomeVideo(int videoId)
        {
            /*构建查询sql*/
            string sql = "select * from Video where videoId=" + videoId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Video video = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新视频实现*/
        public static bool EditVideo(ENTITY.Video video)
        {
            string sql = "update Video set title=@title,videoPhoto=@videoPhoto,videoDesc=@videoDesc,videoFile=@videoFile,addTime=@addTime where videoId=@videoId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@videoPhoto",SqlDbType.VarChar),
             new SqlParameter("@videoDesc",SqlDbType.VarChar),
             new SqlParameter("@videoFile",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@videoId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = video.title;
            parm[1].Value = video.videoPhoto;
            parm[2].Value = video.videoDesc;
            parm[3].Value = video.videoFile;
            parm[4].Value = video.addTime;
            parm[5].Value = video.videoId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除视频*/
        public static bool DelVideo(string p)
        {
            string sql = "delete from Video where videoId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询视频*/
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

        /*查询视频*/
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
