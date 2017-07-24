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
    public class SellProduct
    {
        IDBHelper idb = DbHeapPer.DbHelPerFactory.GetSqlControl();


        public bool SellAdd(List<string> _zhi)
        {
            return idb.Transaction(_zhi);
        }

        public string getSum(string where)
        {
            where = "where 1=1 " + where;
            object result = idb.GetScalar("select sum(SellMoney) from View_SellProduct " + where);
            if (result == DBNull.Value || result == null)
            {
                return "0.00";
            }
            else
            {
                return Convert.ToDecimal(result).ToString("N2");
            }
        }
    }
}
