using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbHeapPer;

namespace dal
{
    /// <summary>
    /// 消费明细表
    /// </summary>
    public class Sell
    {
        IDBHelper idb = DbHeapPer.DbHelPerFactory.GetSqlControl();

        /// <summary>
        /// 获取最大流水号(从01)
        /// </summary>
        /// <returns>返回string</returns>
        public string AutoID(string _Date)
        {
            Object obj = idb.GetScalar("select max(ID) from Sell where ID like '" + _Date + "%'");
            string str = "";
            if (obj != null)
            {
                str = obj.ToString();
            }
            if (str == "")
            {
                str = _Date + "0001";
            }
            else
            {
                int ID = Convert.ToInt32(str.Substring(8)) + 1;
                if (ID < 1000)
                {
                    str = _Date + ID.ToString("0000");
                }
                else
                {
                    str = _Date + ID.ToString();
                }
            }
            return str;
        }
    }
}
