using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Աҵ���߼���*/
    public class bllPlayer{
        /*�����Ա*/
        public static bool AddPlayer(ENTITY.Player player)
        {
            return DAL.dalPlayer.AddPlayer(player);
        }

        /*����playerId��ȡĳ����Ա��¼*/
        public static ENTITY.Player getSomePlayer(int playerId)
        {
            return DAL.dalPlayer.getSomePlayer(playerId);
        }

        /*������Ա*/
        public static bool EditPlayer(ENTITY.Player player)
        {
            return DAL.dalPlayer.EditPlayer(player);
        }

        /*ɾ����Ա*/
        public static bool DelPlayer(string p)
        {
            return DAL.dalPlayer.DelPlayer(p);
        }

        /*��ѯ��Ա*/
        public static System.Data.DataSet GetPlayer(string strWhere)
        {
            return DAL.dalPlayer.GetPlayer(strWhere);
        }

        /*����������ҳ��ѯ��Ա*/
        public static System.Data.DataTable GetPlayer(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPlayer.GetPlayer(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ա*/
        public static System.Data.DataSet getAllPlayer()
        {
            return DAL.dalPlayer.getAllPlayer();
        }
    }
}
