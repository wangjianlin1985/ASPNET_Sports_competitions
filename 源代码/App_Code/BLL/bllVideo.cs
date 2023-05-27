using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*视频业务逻辑层*/
    public class bllVideo{
        /*添加视频*/
        public static bool AddVideo(ENTITY.Video video)
        {
            return DAL.dalVideo.AddVideo(video);
        }

        /*根据videoId获取某条视频记录*/
        public static ENTITY.Video getSomeVideo(int videoId)
        {
            return DAL.dalVideo.getSomeVideo(videoId);
        }

        /*更新视频*/
        public static bool EditVideo(ENTITY.Video video)
        {
            return DAL.dalVideo.EditVideo(video);
        }

        /*删除视频*/
        public static bool DelVideo(string p)
        {
            return DAL.dalVideo.DelVideo(p);
        }

        /*查询视频*/
        public static System.Data.DataSet GetVideo(string strWhere)
        {
            return DAL.dalVideo.GetVideo(strWhere);
        }

        /*根据条件分页查询视频*/
        public static System.Data.DataTable GetVideo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalVideo.GetVideo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的视频*/
        public static System.Data.DataSet getAllVideo()
        {
            return DAL.dalVideo.getAllVideo();
        }
    }
}
