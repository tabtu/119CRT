using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DFireHouse
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 插入函数
        /// </summary>
        /// <param name="info">Model</param>
        /// <returns>影响数据物理ID，已存在逻辑主码项返-1</returns>
        public short INSERT(FireHouse info)
        {
            try
            {
                if (SELECT_BY_NAME_ISUSED(info.Name, true) != null)
                {
                    return -1;
                }

                U_firehouse temp = new U_firehouse();
                //temp.id = info.Id;
                temp.name = info.Name;
                temp.aid = info.Aid;
                temp.lng = info.Lng;
                temp.lat = info.Lat;
                temp.description = info.Description;
                temp.isused = info.Isused;

                Table<U_firehouse> table = db.GetTable<U_firehouse>();
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
        public short UPDATE(FireHouse info)
        {
            try
            {
                //if (SELECT_BY_NAME_ISUSED(info.Name, true) != null)
                //{
                //    return -1;
                //}

                U_firehouse temp = new U_firehouse();
                Table<U_firehouse> table = db.GetTable<U_firehouse>();
                temp = (from row in db.U_firehouse where row.id == info.Id select row).First();

                //temp.id = info.Id;
                temp.name = info.Name;
                temp.aid = info.Aid;
                temp.lng = info.Lng;
                temp.lat = info.Lat;
                temp.description = info.Description;
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
        /// 逻辑删除
        /// </summary>
        /// <param name="id">物理主码</param>
        /// <returns>影响数据物理ID</returns>
        public int DELETE(short id)
        {
            try
            {
                U_firehouse temp = new U_firehouse();
                Table<U_firehouse> table = db.GetTable<U_firehouse>();
                temp = (from row in db.U_firehouse where row.id == id select row).First();

                //temp.id = info.Id;
                temp.isused = false;

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
        public IList<FireHouse> SELECT_ALL()
        {
            try
            {
                IList<FireHouse> result = new List<FireHouse>();
                var temp = (from row in db.U_firehouse orderby row.id, row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    FireHouse element = new FireHouse();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Aid = temp.Current.aid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Description = temp.Current.description;
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
        public FireHouse SELECT_BY_ID(short id)
        {
            try
            {
                FireHouse rd = new FireHouse();
                U_firehouse temp = (from row in db.U_firehouse where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Name = temp.name;
                rd.Aid = temp.aid;
                rd.Lng = temp.lng;
                rd.Lat = temp.lat;
                rd.Description = temp.description;
                rd.Isused = temp.isused;

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
        /// <param name="name">名称</param>
        /// <param name="isused">在用</param>
        /// <returns>结果</returns>
        public FireHouse SELECT_BY_NAME_ISUSED(string name, bool isused)
        {
            try
            {
                FireHouse rd = new FireHouse();
                U_firehouse temp = (from row in db.U_firehouse where row.name == name && row.isused == isused select row).First();

                rd.Id = temp.id;
                rd.Name = temp.name;
                rd.Aid = temp.aid;
                rd.Lng = temp.lng;
                rd.Lat = temp.lat;
                rd.Description = temp.description;
                rd.Isused = temp.isused;
                
                rd.Isused = temp.isused;

                return rd;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 根据区域ID获取列表
        /// </summary>
        /// <returns>结果列表</returns>
        public IList<FireHouse> SELECT_BY_AID(short aid)
        {
            try
            {
                IList<FireHouse> result = new List<FireHouse>();
                var temp = (from row in db.U_firehouse where row.aid == aid orderby row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    FireHouse element = new FireHouse();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Aid = temp.Current.aid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Description = temp.Current.description;
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
        /// 获取 在用/不在用 列表
        /// </summary>
        /// <param name="isused">在用状态</param>
        /// <returns>结果列表</returns>
        public IList<FireHouse> SELECT_BY_ISUSED(bool isused)
        {
            try
            {
                IList<FireHouse> result = new List<FireHouse>();
                var temp = (from row in db.U_firehouse where row.isused == isused orderby row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    FireHouse element = new FireHouse();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Aid = temp.Current.aid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Description = temp.Current.description;
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
