using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbHeapPer;
using System.Data;

namespace dal
{
    /// <summary>
    /// 折扣设置
    /// </summary>
    public class Backup
    {
        IDBHelper idb = DbHeapPer.DbHelPerFactory.GetSqlControl();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件,查询时有条件的话，需要在条件前加and</param>
        /// <returns>返回DataTable的值</returns>
        public DataTable Fill(string where)
        {
            where = "where 1=1 " + where;
            DataTable dt = idb.Select("select * from Backup " + where + " order by ID desc");
            return dt;
        }

        public string getScalar(string zd, string where)
        {
            where = "where 1=1 " + where;
            object result = idb.GetScalar("select " + zd + " from Backup " + where);
            if (result == DBNull.Value || result == null)
            {
                return "";
            }
            else
            {
                return result.ToString();
            }
        }

        public int Insert(string BackDate, string BackFile)
        {
            return idb.Insert("insert into Backup(BackDate,BackFile) values('" + BackDate + "','" + BackFile + "')");
        }

        public int Delete(int ID)
        {
            return idb.Delete("delete from Backup where ID=" + ID);
        }
    }
}
