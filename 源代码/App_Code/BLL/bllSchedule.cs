using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*赛程业务逻辑层*/
    public class bllSchedule{
        /*添加赛程*/
        public static bool AddSchedule(ENTITY.Schedule schedule)
        {
            return DAL.dalSchedule.AddSchedule(schedule);
        }

        /*根据scheduleId获取某条赛程记录*/
        public static ENTITY.Schedule getSomeSchedule(int scheduleId)
        {
            return DAL.dalSchedule.getSomeSchedule(scheduleId);
        }

        /*更新赛程*/
        public static bool EditSchedule(ENTITY.Schedule schedule)
        {
            return DAL.dalSchedule.EditSchedule(schedule);
        }

        /*删除赛程*/
        public static bool DelSchedule(string p)
        {
            return DAL.dalSchedule.DelSchedule(p);
        }

        /*查询赛程*/
        public static System.Data.DataSet GetSchedule(string strWhere)
        {
            return DAL.dalSchedule.GetSchedule(strWhere);
        }

        /*根据条件分页查询赛程*/
        public static System.Data.DataTable GetSchedule(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSchedule.GetSchedule(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的赛程*/
        public static System.Data.DataSet getAllSchedule()
        {
            return DAL.dalSchedule.getAllSchedule();
        }
    }
}
