using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DEquipType
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<EquipType> INTERSECTION(IList<EquipType> temp1, IList<EquipType> temp2)
        {
            try
            {
                List<EquipType> list = new List<EquipType>();
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
        public long INSERT(EquipType info)
        {
            try
            {
                U_equiptype temp = new U_equiptype();
                //temp.id = info.Id;
                temp.name = info.Name;
                temp.sort = info.Sort;
                temp.icon = info.Icon;
                temp.isused = info.Isused;

                Table<U_equiptype> table = db.GetTable<U_equiptype>();
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
        public long UPDATE(EquipType info)
        {
            try
            {
                U_equiptype temp = new U_equiptype();
                Table<U_equiptype> table = db.GetTable<U_equiptype>();
                temp = (from row in db.U_equiptype where row.id == info.Id select row).First();

                //temp.id = info.Id;
                temp.name = info.Name;
                temp.sort = info.Sort;
                temp.icon = info.Icon;
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
        public IList<EquipType> SELECT_ALL()
        {
            try
            {
                IList<EquipType> result = new List<EquipType>();
                var temp = (from row in db.U_equiptype orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    EquipType element = new EquipType();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Sort = temp.Current.sort;
                    element.Icon = temp.Current.icon;
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
        public EquipType SELECT_BY_ID(long id)
        {
            try
            {
                EquipType rd = new EquipType();
                U_equiptype temp = (from row in db.U_equiptype where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Name = temp.name;
                rd.Sort = temp.sort;
                rd.Icon = temp.icon;
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
        public IList<EquipType> SELECT_BY_ISUSED(bool isused)
        {
            try
            {
                IList<EquipType> result = new List<EquipType>();
                var temp = (from row in db.U_equiptype where row.isused == isused orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    EquipType element = new EquipType();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Sort = temp.Current.sort;
                    element.Icon = temp.Current.icon;
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
