using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ѷ���ҵ���߼���*/
    public class bllNewsType{
        /*�����Ѷ���*/
        public static bool AddNewsType(ENTITY.NewsType newsType)
        {
            return DAL.dalNewsType.AddNewsType(newsType);
        }

        /*����typeId��ȡĳ����Ѷ����¼*/
        public static ENTITY.NewsType getSomeNewsType(int typeId)
        {
            return DAL.dalNewsType.getSomeNewsType(typeId);
        }

        /*������Ѷ���*/
        public static bool EditNewsType(ENTITY.NewsType newsType)
        {
            return DAL.dalNewsType.EditNewsType(newsType);
        }

        /*ɾ����Ѷ���*/
        public static bool DelNewsType(string p)
        {
            return DAL.dalNewsType.DelNewsType(p);
        }

        /*��ѯ��Ѷ���*/
        public static System.Data.DataSet GetNewsType(string strWhere)
        {
            return DAL.dalNewsType.GetNewsType(strWhere);
        }

        /*����������ҳ��ѯ��Ѷ���*/
        public static System.Data.DataTable GetNewsType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNewsType.GetNewsType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ѷ���*/
        public static System.Data.DataSet getAllNewsType()
        {
            return DAL.dalNewsType.getAllNewsType();
        }
    }
}
