using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*资讯类别业务逻辑层*/
    public class bllNewsType{
        /*添加资讯类别*/
        public static bool AddNewsType(ENTITY.NewsType newsType)
        {
            return DAL.dalNewsType.AddNewsType(newsType);
        }

        /*根据typeId获取某条资讯类别记录*/
        public static ENTITY.NewsType getSomeNewsType(int typeId)
        {
            return DAL.dalNewsType.getSomeNewsType(typeId);
        }

        /*更新资讯类别*/
        public static bool EditNewsType(ENTITY.NewsType newsType)
        {
            return DAL.dalNewsType.EditNewsType(newsType);
        }

        /*删除资讯类别*/
        public static bool DelNewsType(string p)
        {
            return DAL.dalNewsType.DelNewsType(p);
        }

        /*查询资讯类别*/
        public static System.Data.DataSet GetNewsType(string strWhere)
        {
            return DAL.dalNewsType.GetNewsType(strWhere);
        }

        /*根据条件分页查询资讯类别*/
        public static System.Data.DataTable GetNewsType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNewsType.GetNewsType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的资讯类别*/
        public static System.Data.DataSet getAllNewsType()
        {
            return DAL.dalNewsType.getAllNewsType();
        }
    }
}
