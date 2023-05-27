using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ѷ���ҵ���߼���ʵ��*/
    public class dalNewsType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ѷ���ʵ��*/
        public static bool AddNewsType(ENTITY.NewsType newsType)
        {
            string sql = "insert into NewsType(typeName) values(@typeName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = newsType.typeName; //��Ѷ�������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����typeId��ȡĳ����Ѷ����¼*/
        public static ENTITY.NewsType getSomeNewsType(int typeId)
        {
            /*������ѯsql*/
            string sql = "select * from NewsType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.NewsType newsType = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                newsType = new ENTITY.NewsType();
                newsType.typeId = Convert.ToInt32(DataRead["typeId"]);
                newsType.typeName = DataRead["typeName"].ToString();
            }
            return newsType;
        }

        /*������Ѷ���ʵ��*/
        public static bool EditNewsType(ENTITY.NewsType newsType)
        {
            string sql = "update NewsType set typeName=@typeName where typeId=@typeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = newsType.typeName;
            parm[1].Value = newsType.typeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ѷ���*/
        public static bool DelNewsType(string p)
        {
            string sql = "delete from NewsType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ѷ���*/
        public static DataSet GetNewsType(string strWhere)
        {
            try
            {
                string strSql = "select * from NewsType" + strWhere + " order by typeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��Ѷ���*/
        public static System.Data.DataTable GetNewsType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from NewsType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "typeId", strShow, strSql, strWhere, " typeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllNewsType()
        {
            try
            {
                string strSql = "select * from NewsType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
