using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ѷ����ҵ���߼���*/
    public class bllNewsComment{
        /*�����Ѷ����*/
        public static bool AddNewsComment(ENTITY.NewsComment newsComment)
        {
            return DAL.dalNewsComment.AddNewsComment(newsComment);
        }

        /*����commentId��ȡĳ����Ѷ���ۼ�¼*/
        public static ENTITY.NewsComment getSomeNewsComment(int commentId)
        {
            return DAL.dalNewsComment.getSomeNewsComment(commentId);
        }

        /*������Ѷ����*/
        public static bool EditNewsComment(ENTITY.NewsComment newsComment)
        {
            return DAL.dalNewsComment.EditNewsComment(newsComment);
        }

        /*ɾ����Ѷ����*/
        public static bool DelNewsComment(string p)
        {
            return DAL.dalNewsComment.DelNewsComment(p);
        }

        /*��ѯ��Ѷ����*/
        public static System.Data.DataSet GetNewsComment(string strWhere)
        {
            return DAL.dalNewsComment.GetNewsComment(strWhere);
        }

        /*����������ҳ��ѯ��Ѷ����*/
        public static System.Data.DataTable GetNewsComment(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNewsComment.GetNewsComment(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ѷ����*/
        public static System.Data.DataSet getAllNewsComment()
        {
            return DAL.dalNewsComment.getAllNewsComment();
        }
    }
}
