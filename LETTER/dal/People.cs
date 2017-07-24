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
    public class People
    {
        IDBHelper idb = DbHeapPer.DbHelPerFactory.GetSqlControl();

        /// <summary>
        /// 获取最大流水号(从000001)
        /// </summary>
        /// <returns>返回string</returns>
        public string AutoID()
        {
            string str = "";
            Object obj = idb.GetScalar("select max(ID) from People");
            if (obj != null && obj != DBNull.Value)
            {
                str = obj.ToString();
            }
            if (str == "")
            {
                str = "000001";
            }
            else
            {
                int i = int.Parse(str) + 1;
                if (i < 1000000)
                {
                    str = i.ToString("000000");
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
            DataTable dt = idb.Select("select * from People " + where);
            return dt;
        }

        public bool IsExists(string where)
        {
            where = "where 1=1 " + where;
            return idb.IsExists("select count(*) from People " + where);
        }

        public DataTable FillPage(string tsql)
        {
            DataTable dt = idb.Select(tsql);
            return dt;
        }

        public string getScalar(string zd, string where)
        {
            where = "where 1=1 " + where;
            object result = idb.GetScalar("select " + zd + " from People " + where);
            if (result == DBNull.Value || result == null)
            {
                return "";
            }
            else
            {
                return result.ToString();
            }
        }

        public string getPageCount(string tsql)
        {
            object result = idb.GetScalar(tsql);
            if (result == DBNull.Value || result == null)
            {
                return "";
            }
            else
            {
                return result.ToString();
            }
        }

        public int Insert(string ID, string PeoName, string PeoPhone, string PeoSex, string PeoBirthday, string PeoAddress
            , string PeoIDCard, string PeoICard, string PeoICardDate, string PeoBalance)
        {
            return idb.Insert("insert into People(ID,PeoName,PeoPhone,PeoSex,PeoBirthday,PeoAddress,PeoIDCard,PeoICard,PeoICardDate,PeoBalance) values" +
                            "('" + ID + "','" + PeoName + "','" + PeoPhone + "','" + PeoSex + "','" + PeoBirthday + "','" + PeoAddress + "'" +
                            ",'" + PeoIDCard + "','" + PeoICard + "','" + PeoICardDate + "','" + PeoBalance + "')");
        }

        public int Update(string ID, string PeoName, string PeoPhone, string PeoSex, string PeoBirthday, string PeoAddress, string PeoIDCard)
        {
            return idb.Update("update People set PeoName='" + PeoName + "',PeoPhone='" + PeoPhone + "',PeoSex='" + PeoSex + "',PeoBirthday='" + PeoBirthday + "',PeoAddress='" + PeoAddress + "',PeoIDCard='" + PeoIDCard + "' where ID='" + ID + "'");
        }

        public int Delete(string ID)
        {
            return idb.Delete("delete from People where ID='" + ID + "'");
        }

        public int UpdateCharge(string ID, decimal CharteMoney)
        {
            decimal PeoBalance = decimal.Parse(getScalar("PeoBalance", "and ID='" + ID + "'"));
            idb.Update("update People set PeoBalance='" + (PeoBalance + CharteMoney) + "' where ID='" + ID + "'");
            string chargeID = new Charge().AutoID(DateTime.Now.ToString("yyyyMMdd"));
            return idb.Insert("insert into Charge(ID,PeoID,ChargeDate,CharteMoney) values('" + chargeID + "','" + ID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + CharteMoney + ")");
        }

        public int UpdateICard(string ID, string snrstr, string pDate)
        {
            return idb.Update("update People set PeoICard='" + snrstr + "',PeoICardDate='" + pDate + "' where ID='" + ID + "'");
        }

        public int DeleteCard(string ID)
        {
            return idb.Update("update People set PeoICard='',PeoICardDate='' where ID='" + ID + "'");
        }
    }
}
