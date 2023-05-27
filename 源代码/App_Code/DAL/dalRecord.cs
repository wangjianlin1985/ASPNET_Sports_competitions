using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ս��ҵ���߼���ʵ��*/
    public class dalRecord
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������ս��ʵ��*/
        public static bool AddRecord(ENTITY.Record record)
        {
            string sql = "insert into Record(contestArea,teamObj,successNum,failNum,successRate) values(@contestArea,@teamObj,@successNum,@failNum,@successRate)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@contestArea",SqlDbType.VarChar),
             new SqlParameter("@teamObj",SqlDbType.Int),
             new SqlParameter("@successNum",SqlDbType.Int),
             new SqlParameter("@failNum",SqlDbType.Int),
             new SqlParameter("@successRate",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = record.contestArea; //��������
            parm[1].Value = record.teamObj; //�������
            parm[2].Value = record.successNum; //ʤ������
            parm[3].Value = record.failNum; //ʧ�ܳ���
            parm[4].Value = record.successRate; //ʤ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����recordId��ȡĳ�����ս����¼*/
        public static ENTITY.Record getSomeRecord(int recordId)
        {
            /*������ѯsql*/
            string sql = "select * from Record where recordId=" + recordId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Record record = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                record = new ENTITY.Record();
                record.recordId = Convert.ToInt32(DataRead["recordId"]);
                record.contestArea = DataRead["contestArea"].ToString();
                record.teamObj = Convert.ToInt32(DataRead["teamObj"]);
                record.successNum = Convert.ToInt32(DataRead["successNum"]);
                record.failNum = Convert.ToInt32(DataRead["failNum"]);
                record.successRate = DataRead["successRate"].ToString();
            }
            return record;
        }

        /*�������ս��ʵ��*/
        public static bool EditRecord(ENTITY.Record record)
        {
            string sql = "update Record set contestArea=@contestArea,teamObj=@teamObj,successNum=@successNum,failNum=@failNum,successRate=@successRate where recordId=@recordId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@contestArea",SqlDbType.VarChar),
             new SqlParameter("@teamObj",SqlDbType.Int),
             new SqlParameter("@successNum",SqlDbType.Int),
             new SqlParameter("@failNum",SqlDbType.Int),
             new SqlParameter("@successRate",SqlDbType.VarChar),
             new SqlParameter("@recordId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = record.contestArea;
            parm[1].Value = record.teamObj;
            parm[2].Value = record.successNum;
            parm[3].Value = record.failNum;
            parm[4].Value = record.successRate;
            parm[5].Value = record.recordId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����ս��*/
        public static bool DelRecord(string p)
        {
            string sql = "delete from Record where recordId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���ս��*/
        public static DataSet GetRecord(string strWhere)
        {
            try
            {
                string strSql = "select * from Record" + strWhere + " order by recordId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ���ս��*/
        public static System.Data.DataTable GetRecord(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Record";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "recordId", strShow, strSql, strWhere, " recordId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllRecord()
        {
            try
            {
                string strSql = "select * from Record";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
