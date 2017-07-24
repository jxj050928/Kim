using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbHeapPer;
using System.Data;

namespace dal
{
    /// <summary>
    /// 消费明细表
    /// </summary>
    public class ProUsers
    {
        IDBHelper idb = DbHeapPer.DbHelPerFactory.GetSqlControl();

        public bool IsExists(string where)
        {
            where = "where 1=1 " + where;
            return idb.IsExists("select count(*) from ProUsers " + where);
        }

        public string getScalar(string zd, string where)
        {
            where = "where 1=1 " + where;
            object result = idb.GetScalar("select " + zd + " from ProUsers " + where);
            if (result == DBNull.Value || result == null)
            {
                return "";
            }
            else
            {
                return result.ToString();
            }
        }

        public int Update(string ID, string Username, string Userpwd)
        {
            return idb.Update("update ProUsers set Username='" + Username + "',Userpwd='" + Userpwd + "' where ID='" + ID + "'");
        }
    }
}
