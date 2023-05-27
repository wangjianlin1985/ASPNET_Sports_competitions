using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*球队业务逻辑层*/
    public class bllTeam{
        /*添加球队*/
        public static bool AddTeam(ENTITY.Team team)
        {
            return DAL.dalTeam.AddTeam(team);
        }

        /*根据teamId获取某条球队记录*/
        public static ENTITY.Team getSomeTeam(int teamId)
        {
            return DAL.dalTeam.getSomeTeam(teamId);
        }

        /*更新球队*/
        public static bool EditTeam(ENTITY.Team team)
        {
            return DAL.dalTeam.EditTeam(team);
        }

        /*删除球队*/
        public static bool DelTeam(string p)
        {
            return DAL.dalTeam.DelTeam(p);
        }

        /*查询球队*/
        public static System.Data.DataSet GetTeam(string strWhere)
        {
            return DAL.dalTeam.GetTeam(strWhere);
        }

        /*根据条件分页查询球队*/
        public static System.Data.DataTable GetTeam(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTeam.GetTeam(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的球队*/
        public static System.Data.DataSet getAllTeam()
        {
            return DAL.dalTeam.getAllTeam();
        }
    }
}
