using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ҵ���߼���ʵ��*/
    public class dalTeam
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������ʵ��*/
        public static bool AddTeam(ENTITY.Team team)
        {
            string sql = "insert into Team(teamName,teamLogo,contestArea,bornDate,teamDesc) values(@teamName,@teamLogo,@contestArea,@bornDate,@teamDesc)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teamName",SqlDbType.VarChar),
             new SqlParameter("@teamLogo",SqlDbType.VarChar),
             new SqlParameter("@contestArea",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@teamDesc",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = team.teamName; //�������
            parm[1].Value = team.teamLogo; //���logo
            parm[2].Value = team.contestArea; //��������
            parm[3].Value = team.bornDate; //��������
            parm[4].Value = team.teamDesc; //��ӽ���

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����teamId��ȡĳ����Ӽ�¼*/
        public static ENTITY.Team getSomeTeam(int teamId)
        {
            /*������ѯsql*/
            string sql = "select * from Team where teamId=" + teamId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Team team = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                team = new ENTITY.Team();
                team.teamId = Convert.ToInt32(DataRead["teamId"]);
                team.teamName = DataRead["teamName"].ToString();
                team.teamLogo = DataRead["teamLogo"].ToString();
                team.contestArea = DataRead["contestArea"].ToString();
                team.bornDate = Convert.ToDateTime(DataRead["bornDate"].ToString());
                team.teamDesc = DataRead["teamDesc"].ToString();
            }
            return team;
        }

        /*�������ʵ��*/
        public static bool EditTeam(ENTITY.Team team)
        {
            string sql = "update Team set teamName=@teamName,teamLogo=@teamLogo,contestArea=@contestArea,bornDate=@bornDate,teamDesc=@teamDesc where teamId=@teamId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teamName",SqlDbType.VarChar),
             new SqlParameter("@teamLogo",SqlDbType.VarChar),
             new SqlParameter("@contestArea",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@teamDesc",SqlDbType.VarChar),
             new SqlParameter("@teamId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = team.teamName;
            parm[1].Value = team.teamLogo;
            parm[2].Value = team.contestArea;
            parm[3].Value = team.bornDate;
            parm[4].Value = team.teamDesc;
            parm[5].Value = team.teamId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����*/
        public static bool DelTeam(string p)
        {
            string sql = "delete from Team where teamId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���*/
        public static DataSet GetTeam(string strWhere)
        {
            try
            {
                string strSql = "select * from Team" + strWhere + " order by teamId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ���*/
        public static System.Data.DataTable GetTeam(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Team";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "teamId", strShow, strSql, strWhere, " teamId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTeam()
        {
            try
            {
                string strSql = "select * from Team";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
