using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class DLog
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<Log> INTERSECTION(IList<Log> temp1, IList<Log> temp2)
        {
            try
            {
                List<Log> list = new List<Log>();
                var temp0 = temp1.GetEnumerator();
                while (temp0.MoveNext())
                {
                    var temp = temp2.GetEnumerator();
                    while (temp.MoveNext())
                    {
                        if (temp0.Current.Id == temp.Current.Id)
                        {
                            list.Add(temp.Current);
                        }
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 插入函数
        /// </summary>
        /// <param name="info">Model</param>
        /// <returns>影响数据物理ID</returns>
        public long INSERT(Log info)
        {
            try
            {
                if (SELECT_BY_EVID_MID_DATETIME(info.Tablename, info.Tableid, info.Mid, info.Datetime) != null)
                {
                    return -1;
                }

                S_log temp = new S_log();
                //temp.id = info.Id;
                temp.tablename = info.Tablename;
                temp.tableid = info.Tableid;
                temp.mid = info.Mid;
                temp.datetime = info.Datetime;
                temp.discription = info.Discription;

                Table<S_log> table = db.GetTable<S_log>();
                table.InsertOnSubmit(temp);
                db.SubmitChanges();
                return temp.id;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 更新函数
        /// </summary>
        /// <param name="info">Model</param>
        /// <returns>影响数据物理ID，已存在逻辑主码返回-1</returns>
        public long UPDATE(Log info)
        {
            try
            {
                if (SELECT_BY_EVID_MID_DATETIME(info.Tablename, info.Tableid, info.Mid, info.Datetime) == null)
                {
                    return -1;
                }

                S_log temp = new S_log();
                Table<S_log> table = db.GetTable<S_log>();
                temp = (from row in db.S_log where row.id == info.Id select row).First();

                //temp.id = info.Id;
                temp.tablename = info.Tablename;
                temp.tableid = info.Tableid;
                temp.mid = info.Mid;
                temp.datetime = info.Datetime;
                temp.discription = info.Discription;

                db.SubmitChanges();
                return temp.id;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 获取整张列表
        /// </summary>
        /// <returns>结果列表</returns>
        public IList<Log> SELECT_ALL()
        {
            try
            {
                IList<Log> result = new List<Log>();
                var temp = (from row in db.S_log orderby row.datetime ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Log element = new Log();

                    element.Id = temp.Current.id;
                    element.Tablename = temp.Current.tablename;
                    element.Tableid = temp.Current.tableid;
                    element.Mid = temp.Current.mid;
                    element.Datetime = temp.Current.datetime;
                    element.Discription = temp.Current.discription;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据物理主码查询
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>结果</returns>
        public Log SELECT_BY_ID(long id)
        {
            try
            {
                Log rd = new Log();
                S_log temp = (from row in db.S_log where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Tablename = temp.tablename;
                rd.Tableid = temp.tableid;
                rd.Mid = temp.mid;
                rd.Datetime = temp.datetime;
                rd.Discription = temp.discription;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据逻辑主码查询
        /// </summary>
        /// <param name="tablename">被操作表名</param>
        /// <param name="tableid">被操作表数据主码ID</param>
        /// <param name="mid">操作人ID</param>
        /// <param name="datetime">操作时间</param>
        /// <returns>结果</returns>
        public Log SELECT_BY_EVID_MID_DATETIME(string tablename, long tableid, int mid, DateTime datetime)
        {
            try
            {
                Log rd = new Log();
                S_log temp = (from row in db.S_log where row.tablename == tablename && row.tableid == tableid && row.mid == mid && row.datetime == datetime select row).First();

                rd.Id = temp.id;
                rd.Tablename = temp.tablename;
                rd.Tableid = temp.tableid;
                rd.Mid = temp.mid;
                rd.Datetime = temp.datetime;
                rd.Discription = temp.discription;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据事件ID查询日志
        /// </summary>
        /// <param name="tablename">被操作表名</param>
        /// <param name="tableid">被操作数据主码ID</param>
        /// <returns>结果列表</returns>
        public IList<Log> SELECT_BY_EVID(string tablename, long tableid)
        {
            try
            {
                IList<Log> result = new List<Log>();
                var temp = (from row in db.S_log where row.tablename == tablename && row.tableid == tableid orderby row.datetime ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Log element = new Log();

                    element.Id = temp.Current.id;
                    element.Tablename = temp.Current.tablename;
                    element.Tableid = temp.Current.tableid;
                    element.Mid = temp.Current.mid;
                    element.Datetime = temp.Current.datetime;
                    element.Discription = temp.Current.discription;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据操作人ID查询日志
        /// </summary>
        /// <param name="mid">操作人ID</param>
        /// <returns>结果列表</returns>
        public IList<Log> SELECT_BY_MID(short mid)
        {
            try
            {
                IList<Log> result = new List<Log>();
                var temp = (from row in db.S_log where row.mid == mid orderby row.datetime ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Log element = new Log();

                    element.Id = temp.Current.id;
                    element.Tablename = temp.Current.tablename;
                    element.Tableid = temp.Current.tableid;
                    element.Mid = temp.Current.mid;
                    element.Datetime = temp.Current.datetime;
                    element.Discription = temp.Current.discription;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}