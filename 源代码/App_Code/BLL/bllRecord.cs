using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ս��ҵ���߼���*/
    public class bllRecord{
        /*������ս��*/
        public static bool AddRecord(ENTITY.Record record)
        {
            return DAL.dalRecord.AddRecord(record);
        }

        /*����recordId��ȡĳ�����ս����¼*/
        public static ENTITY.Record getSomeRecord(int recordId)
        {
            return DAL.dalRecord.getSomeRecord(recordId);
        }

        /*�������ս��*/
        public static bool EditRecord(ENTITY.Record record)
        {
            return DAL.dalRecord.EditRecord(record);
        }

        /*ɾ�����ս��*/
        public static bool DelRecord(string p)
        {
            return DAL.dalRecord.DelRecord(p);
        }

        /*��ѯ���ս��*/
        public static System.Data.DataSet GetRecord(string strWhere)
        {
            return DAL.dalRecord.GetRecord(strWhere);
        }

        /*����������ҳ��ѯ���ս��*/
        public static System.Data.DataTable GetRecord(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalRecord.GetRecord(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����ս��*/
        public static System.Data.DataSet getAllRecord()
        {
            return DAL.dalRecord.getAllRecord();
        }
    }
}
