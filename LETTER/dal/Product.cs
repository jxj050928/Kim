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
    public class Product
    {
        IDBHelper idb = DbHeapPer.DbHelPerFactory.GetSqlControl();

        /// <summary>
        /// 获取最大流水号(从0001)
        /// </summary>
        /// <returns>返回string</returns>
        public string AutoID()
        {
            string str = "";
            Object obj = idb.GetScalar("select max(ID) from Product");
            if (obj != null && obj != DBNull.Value)
            {
                str = obj.ToString();
            }
            if (str == "")
            {
                str = "0001";
            }
            else
            {
                int i = int.Parse(str) + 1;
                if (i < 10000)
                {
                    str = i.ToString("0000");
                }
                else
                {
                    str = i.ToString();
                }
            }
            return str;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件,查询时有条件的话，需要在条件前加and</param>
        /// <returns>返回DataTable的值</returns>
        public DataTable Fill(string where)
        {
            where = "where 1=1 " + where;
            DataTable dt = idb.Select("select * from Product " + where);
            return dt;
        }

        public bool IsExists(string where)
        {
            where = "where 1=1 " + where;
            return idb.IsExists("select count(*) from Product " + where);
        }

        public string getScalar(string zd, string where)
        {
            where = "where 1=1 " + where;
            object result = idb.GetScalar("select " + zd + " from Product " + where);
            if (result == DBNull.Value || result == null)
            {
                return "";
            }
            else
            {
                return result.ToString();
            }
        }

        public int Insert(string ID, string ProName, string ProPrice, string ProRemake)
        {
            return idb.Insert("insert into Product(ID,ProName,ProPrice,ProRemake) values('" + ID + "','" + ProName + "','" + ProPrice + "','" + ProRemake + "')");
        }

        public int Update(string ID, string ProName, string ProPrice, string ProRemake)
        {
            return idb.Update("update Product set ProName='" + ProName + "',ProPrice='" + ProPrice + "',ProRemake='" + ProRemake + "' where ID='" + ID + "'");
        }

        public int Delete(string ID)
        {
            return idb.Delete("delete from Product where ID='" + ID + "'");
        }
    }
}
