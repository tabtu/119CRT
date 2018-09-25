using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DLanCate
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<LanCate> INTERSECTION(IList<LanCate> temp1, IList<LanCate> temp2)
        {
            try
            {
                List<LanCate> list = new List<LanCate>();
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
        public long INSERT(LanCate info)
        {
            try
            {
                S_lancate temp = new S_lancate();
                //temp.id = info.Id;
                temp.name = info.Name;
                temp.sort = info.Sort;
                temp.isused = info.Isused;

                Table<S_lancate> table = db.GetTable<S_lancate>();
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
        public long UPDATE(LanCate info)
        {
            try
            {
                S_lancate temp = new S_lancate();
                Table<S_lancate> table = db.GetTable<S_lancate>();
                temp = (from row in db.S_lancate where row.id == info.Id select row).First();

                //temp.id = info.Id;
                temp.name = info.Name;
                temp.sort = info.Sort;
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
        public IList<LanCate> SELECT_ALL()
        {
            try
            {
                IList<LanCate> result = new List<LanCate>();
                var temp = (from row in db.S_lancate orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanCate element = new LanCate();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Sort = temp.Current.sort;
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
        public LanCate SELECT_BY_ID(long id)
        {
            try
            {
                LanCate rd = new LanCate();
                S_lancate temp = (from row in db.S_lancate where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Name = temp.name;
                rd.Sort = temp.sort;
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
        public IList<LanCate> SELECT_BY_ISUSED(bool isused)
        {
            try
            {
                IList<LanCate> result = new List<LanCate>();
                var temp = (from row in db.S_lancate where row.isused == isused orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanCate element = new LanCate();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Sort = temp.Current.sort;
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
