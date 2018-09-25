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
    public class DNews
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<News> INTERSECTION(IList<News> temp1, IList<News> temp2)
        {
            try
            {
                List<News> list = new List<News>();
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
        public long INSERT(News info)
        {
            try
            {
                U_news temp = new U_news();
                //temp.id = info.Id;
                temp.mid = info.Mid;
                temp.title = info.Title;
                temp.context = info.Context;
                temp.datetime = info.Datetime;
                temp.cn = info.Cn;
                temp.isused = info.Isused;

                Table<U_news> table = db.GetTable<U_news>();
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
        public long UPDATE(News info)
        {
            try
            {
                U_news temp = new U_news();
                Table<U_news> table = db.GetTable<U_news>();
                temp = (from row in db.U_news where row.id == info.Id select row).First();

                //temp.id = info.Id;
                temp.mid = info.Mid;
                temp.title = info.Title;
                temp.context = info.Context;
                temp.datetime = info.Datetime;
                temp.cn = info.Cn;
                temp.isused = info.Isused;

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
        public IList<News> SELECT_ALL()
        {
            try
            {
                IList<News> result = new List<News>();
                var temp = (from row in db.U_news select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    News element = new News();

                    element.Id = temp.Current.id;
                    element.Mid = temp.Current.mid;
                    element.Title = temp.Current.title;
                    element.Context = temp.Current.context;
                    element.Datetime = temp.Current.datetime;
                    element.Cn = temp.Current.cn;
                    element.Isused = temp.Current.isused;

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
        /// 
        /// </summary>
        /// <param name="isused"></param>
        /// <param name="cn"></param>
        /// <returns></returns>
        public IList<News> SELECT_ISUSED_CN(bool isused, bool cn)
        {
            try
            {
                IList<News> result = new List<News>();
                var temp = (from row in db.U_news where row.isused == isused && row.cn == cn orderby row.datetime ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    News element = new News();

                    element.Id = temp.Current.id;
                    element.Mid = temp.Current.mid;
                    element.Title = temp.Current.title;
                    element.Context = temp.Current.context;
                    element.Datetime = temp.Current.datetime;
                    element.Cn = temp.Current.cn;
                    element.Isused = temp.Current.isused;

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
        public News SELECT_BY_ID(long id)
        {
            try
            {
                News rd = new News();
                U_news temp = (from row in db.U_news where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Mid = temp.mid;
                rd.Title = temp.title;
                rd.Context = temp.context;
                rd.Datetime = temp.datetime;
                rd.Cn = temp.cn;
                rd.Isused = temp.isused;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据使用状态查询
        /// </summary>
        /// <param name="isused">是否使用</param>
        /// <returns>结果列表</returns>
        public IList<News> SELECT_BY_ISUSED(bool isused)
        {
            try
            {
                IList<News> result = new List<News>();
                var temp = (from row in db.U_news where row.isused == isused select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    News element = new News();

                    element.Id = temp.Current.id;
                    element.Mid = temp.Current.mid;
                    element.Title = temp.Current.title;
                    element.Context = temp.Current.context;
                    element.Datetime = temp.Current.datetime;
                    element.Cn = temp.Current.cn;
                    element.Isused = temp.Current.isused;

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
        /// 按姓名模糊搜索
        /// </summary>
        /// <param name="name">关键字</param>//汤妞子
        /// <returns>结果列表</returns>
        public IList<News> LIKE_BY_NAME(string name)
        {
            try
            {
                IList<News> result = new List<News>();
                var temp = (from row in db.U_news where row.title.Contains(name) orderby row.id ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    News element = new News();

                    element.Id = temp.Current.id;
                    element.Mid = temp.Current.mid;
                    element.Title = temp.Current.title;
                    element.Context = temp.Current.context;
                    element.Datetime = temp.Current.datetime;
                    element.Cn = temp.Current.cn;
                    element.Isused = temp.Current.isused;

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
