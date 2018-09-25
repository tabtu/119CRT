using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DEquipStatus
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<EquipStatus> INTERSECTION(IList<EquipStatus> temp1, IList<EquipStatus> temp2)
        {
            try
            {
                List<EquipStatus> list = new List<EquipStatus>();
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
        public long INSERT(EquipStatus info)
        {
            try
            {
                S_equipstatus temp = new S_equipstatus();
                //temp.id = info.Id;
                temp.name = info.Name;
                temp.isused = info.Isused;

                Table<S_equipstatus> table = db.GetTable<S_equipstatus>();
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
        public long UPDATE(EquipStatus info)
        {
            try
            {
                S_equipstatus temp = new S_equipstatus();
                Table<S_equipstatus> table = db.GetTable<S_equipstatus>();
                temp = (from row in db.S_equipstatus where row.id == info.Id select row).First();

                //temp.id = info.Id;
                temp.name = info.Name;
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
        public IList<EquipStatus> SELECT_ALL()
        {
            try
            {
                IList<EquipStatus> result = new List<EquipStatus>();
                var temp = (from row in db.S_equipstatus select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    EquipStatus element = new EquipStatus();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
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
        public EquipStatus SELECT_BY_ID(long id)
        {
            try
            {
                EquipStatus rd = new EquipStatus();
                S_equipstatus temp = (from row in db.S_equipstatus where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Name = temp.name;
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
        public IList<EquipStatus> SELECT_BY_ISUSED(bool isused)
        {
            try
            {
                IList<EquipStatus> result = new List<EquipStatus>();
                var temp = (from row in db.S_equipstatus where row.isused == isused select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    EquipStatus element = new EquipStatus();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
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
