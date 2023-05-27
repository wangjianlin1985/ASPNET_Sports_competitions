using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*球队战绩业务逻辑层*/
    public class bllRecord{
        /*添加球队战绩*/
        public static bool AddRecord(ENTITY.Record record)
        {
            return DAL.dalRecord.AddRecord(record);
        }

        /*根据recordId获取某条球队战绩记录*/
        public static ENTITY.Record getSomeRecord(int recordId)
        {
            return DAL.dalRecord.getSomeRecord(recordId);
        }

        /*更新球队战绩*/
        public static bool EditRecord(ENTITY.Record record)
        {
            return DAL.dalRecord.EditRecord(record);
        }

        /*删除球队战绩*/
        public static bool DelRecord(string p)
        {
            return DAL.dalRecord.DelRecord(p);
        }

        /*查询球队战绩*/
        public static System.Data.DataSet GetRecord(string strWhere)
        {
            return DAL.dalRecord.GetRecord(strWhere);
        }

        /*根据条件分页查询球队战绩*/
        public static System.Data.DataTable GetRecord(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalRecord.GetRecord(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的球队战绩*/
        public static System.Data.DataSet getAllRecord()
        {
            return DAL.dalRecord.getAllRecord();
        }
    }
}
