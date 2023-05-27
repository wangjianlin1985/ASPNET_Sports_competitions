using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ҵ���߼���*/
    public class bllTeam{
        /*������*/
        public static bool AddTeam(ENTITY.Team team)
        {
            return DAL.dalTeam.AddTeam(team);
        }

        /*����teamId��ȡĳ����Ӽ�¼*/
        public static ENTITY.Team getSomeTeam(int teamId)
        {
            return DAL.dalTeam.getSomeTeam(teamId);
        }

        /*�������*/
        public static bool EditTeam(ENTITY.Team team)
        {
            return DAL.dalTeam.EditTeam(team);
        }

        /*ɾ�����*/
        public static bool DelTeam(string p)
        {
            return DAL.dalTeam.DelTeam(p);
        }

        /*��ѯ���*/
        public static System.Data.DataSet GetTeam(string strWhere)
        {
            return DAL.dalTeam.GetTeam(strWhere);
        }

        /*����������ҳ��ѯ���*/
        public static System.Data.DataTable GetTeam(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTeam.GetTeam(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����*/
        public static System.Data.DataSet getAllTeam()
        {
            return DAL.dalTeam.getAllTeam();
        }
    }
}
