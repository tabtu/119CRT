using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DLanType
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<LanType> INTERSECTION(IList<LanType> temp1, IList<LanType> temp2)
        {
            try
            {
                List<LanType> list = new List<LanType>();
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
        public long INSERT(LanType info)
        {
            try
            {
                S_lantype temp = new S_lantype();
                //temp.id = info.Id;
                temp.name = info.Name;
                temp.sort = info.Sort;
                temp.isused = info.Isused;

                Table<S_lantype> table = db.GetTable<S_lantype>();
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
        public long UPDATE(LanType info)
        {
            try
            {
                S_lantype temp = new S_lantype();
                Table<S_lantype> table = db.GetTable<S_lantype>();
                temp = (from row in db.S_lantype where row.id == info.Id select row).First();

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
        public IList<LanType> SELECT_ALL()
        {
            try
            {
                IList<LanType> result = new List<LanType>();
                var temp = (from row in db.S_lantype orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanType element = new LanType();

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
        public LanType SELECT_BY_ID(long id)
        {
            try
            {
                LanType rd = new LanType();
                S_lantype temp = (from row in db.S_lantype where row.id == id select row).First();

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
        public IList<LanType> SELECT_BY_ISUSED(bool isused)
        {
            try
            {
                IList<LanType> result = new List<LanType>();
                var temp = (from row in db.S_lantype where row.isused == isused orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanType element = new LanType();

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
