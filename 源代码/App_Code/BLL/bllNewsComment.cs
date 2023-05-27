using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*资讯评论业务逻辑层*/
    public class bllNewsComment{
        /*添加资讯评论*/
        public static bool AddNewsComment(ENTITY.NewsComment newsComment)
        {
            return DAL.dalNewsComment.AddNewsComment(newsComment);
        }

        /*根据commentId获取某条资讯评论记录*/
        public static ENTITY.NewsComment getSomeNewsComment(int commentId)
        {
            return DAL.dalNewsComment.getSomeNewsComment(commentId);
        }

        /*更新资讯评论*/
        public static bool EditNewsComment(ENTITY.NewsComment newsComment)
        {
            return DAL.dalNewsComment.EditNewsComment(newsComment);
        }

        /*删除资讯评论*/
        public static bool DelNewsComment(string p)
        {
            return DAL.dalNewsComment.DelNewsComment(p);
        }

        /*查询资讯评论*/
        public static System.Data.DataSet GetNewsComment(string strWhere)
        {
            return DAL.dalNewsComment.GetNewsComment(strWhere);
        }

        /*根据条件分页查询资讯评论*/
        public static System.Data.DataTable GetNewsComment(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNewsComment.GetNewsComment(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的资讯评论*/
        public static System.Data.DataSet getAllNewsComment()
        {
            return DAL.dalNewsComment.getAllNewsComment();
        }
    }
}
