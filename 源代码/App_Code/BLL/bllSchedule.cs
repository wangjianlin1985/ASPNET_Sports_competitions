using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����ҵ���߼���*/
    public class bllSchedule{
        /*�������*/
        public static bool AddSchedule(ENTITY.Schedule schedule)
        {
            return DAL.dalSchedule.AddSchedule(schedule);
        }

        /*����scheduleId��ȡĳ�����̼�¼*/
        public static ENTITY.Schedule getSomeSchedule(int scheduleId)
        {
            return DAL.dalSchedule.getSomeSchedule(scheduleId);
        }

        /*��������*/
        public static bool EditSchedule(ENTITY.Schedule schedule)
        {
            return DAL.dalSchedule.EditSchedule(schedule);
        }

        /*ɾ������*/
        public static bool DelSchedule(string p)
        {
            return DAL.dalSchedule.DelSchedule(p);
        }

        /*��ѯ����*/
        public static System.Data.DataSet GetSchedule(string strWhere)
        {
            return DAL.dalSchedule.GetSchedule(strWhere);
        }

        /*����������ҳ��ѯ����*/
        public static System.Data.DataTable GetSchedule(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSchedule.GetSchedule(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�����*/
        public static System.Data.DataSet getAllSchedule()
        {
            return DAL.dalSchedule.getAllSchedule();
        }
    }
}
