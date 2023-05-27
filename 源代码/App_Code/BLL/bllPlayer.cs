using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*球员业务逻辑层*/
    public class bllPlayer{
        /*添加球员*/
        public static bool AddPlayer(ENTITY.Player player)
        {
            return DAL.dalPlayer.AddPlayer(player);
        }

        /*根据playerId获取某条球员记录*/
        public static ENTITY.Player getSomePlayer(int playerId)
        {
            return DAL.dalPlayer.getSomePlayer(playerId);
        }

        /*更新球员*/
        public static bool EditPlayer(ENTITY.Player player)
        {
            return DAL.dalPlayer.EditPlayer(player);
        }

        /*删除球员*/
        public static bool DelPlayer(string p)
        {
            return DAL.dalPlayer.DelPlayer(p);
        }

        /*查询球员*/
        public static System.Data.DataSet GetPlayer(string strWhere)
        {
            return DAL.dalPlayer.GetPlayer(strWhere);
        }

        /*根据条件分页查询球员*/
        public static System.Data.DataTable GetPlayer(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPlayer.GetPlayer(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的球员*/
        public static System.Data.DataSet getAllPlayer()
        {
            return DAL.dalPlayer.getAllPlayer();
        }
    }
}
