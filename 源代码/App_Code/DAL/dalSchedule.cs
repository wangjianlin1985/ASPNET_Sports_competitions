using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*����ҵ���߼���ʵ��*/
    public class dalSchedule
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�������ʵ��*/
        public static bool AddSchedule(ENTITY.Schedule schedule)
        {
            string sql = "insert into Schedule(scheduleDate,scheduleTime,contestState,team1,team2,contestResult) values(@scheduleDate,@scheduleTime,@contestState,@team1,@team2,@contestResult)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@scheduleDate",SqlDbType.DateTime),
             new SqlParameter("@scheduleTime",SqlDbType.VarChar),
             new SqlParameter("@contestState",SqlDbType.VarChar),
             new SqlParameter("@team1",SqlDbType.Int),
             new SqlParameter("@team2",SqlDbType.Int),
             new SqlParameter("@contestResult",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = schedule.scheduleDate; //��������
            parm[1].Value = schedule.scheduleTime; //����ʱ��
            parm[2].Value = schedule.contestState; //״̬
            parm[3].Value = schedule.team1; //�������1
            parm[4].Value = schedule.team2; //�������2
            parm[5].Value = schedule.contestResult; //�������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����scheduleId��ȡĳ�����̼�¼*/
        public static ENTITY.Schedule getSomeSchedule(int scheduleId)
        {
            /*������ѯsql*/
            string sql = "select * from Schedule where scheduleId=" + scheduleId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Schedule schedule = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                schedule = new ENTITY.Schedule();
                schedule.scheduleId = Convert.ToInt32(DataRead["scheduleId"]);
                schedule.scheduleDate = Convert.ToDateTime(DataRead["scheduleDate"].ToString());
                schedule.scheduleTime = DataRead["scheduleTime"].ToString();
                schedule.contestState = DataRead["contestState"].ToString();
                schedule.team1 = Convert.ToInt32(DataRead["team1"]);
                schedule.team2 = Convert.ToInt32(DataRead["team2"]);
                schedule.contestResult = DataRead["contestResult"].ToString();
            }
            return schedule;
        }

        /*��������ʵ��*/
        public static bool EditSchedule(ENTITY.Schedule schedule)
        {
            string sql = "update Schedule set scheduleDate=@scheduleDate,scheduleTime=@scheduleTime,contestState=@contestState,team1=@team1,team2=@team2,contestResult=@contestResult where scheduleId=@scheduleId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@scheduleDate",SqlDbType.DateTime),
             new SqlParameter("@scheduleTime",SqlDbType.VarChar),
             new SqlParameter("@contestState",SqlDbType.VarChar),
             new SqlParameter("@team1",SqlDbType.Int),
             new SqlParameter("@team2",SqlDbType.Int),
             new SqlParameter("@contestResult",SqlDbType.VarChar),
             new SqlParameter("@scheduleId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = schedule.scheduleDate;
            parm[1].Value = schedule.scheduleTime;
            parm[2].Value = schedule.contestState;
            parm[3].Value = schedule.team1;
            parm[4].Value = schedule.team2;
            parm[5].Value = schedule.contestResult;
            parm[6].Value = schedule.scheduleId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelSchedule(string p)
        {
            string sql = "delete from Schedule where scheduleId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
        public static DataSet GetSchedule(string strWhere)
        {
            try
            {
                string strSql = "select * from Schedule" + strWhere + " order by scheduleId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ����*/
        public static System.Data.DataTable GetSchedule(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Schedule";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "scheduleId", strShow, strSql, strWhere, " scheduleId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllSchedule()
        {
            try
            {
                string strSql = "select * from Schedule";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
