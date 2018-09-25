using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DArea
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<Area> INTERSECTION(IList<Area> temp1, IList<Area> temp2)
        {
            try
            {
                List<Area> list = new List<Area>();
                var temp0 = temp1.GetEnumerator();
                while (temp0.MoveNext())
                {
                    var temp = temp2.GetEnumerator();
                    while (temp.MoveNext())
                    {
                        if (temp0.Current.ID == temp.Current.ID)
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
        public long INSERT(Area info)
        {
            try
            {
                S_area temp = new S_area();
                if (SELECT_BY_NAME_ISUSED(info.Name, true) != null) return -1;

                //temp.id = info.ID;
                temp.name = info.Name;
                temp.cid = info.Cid;
                temp.lng = info.Lng;
                temp.lat = info.Lat;
                temp.zoom = info.Zoom;
                temp.type = info.Type;
                temp.isused = info.Isused;

                Table<S_area> table = db.GetTable<S_area>();
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
        public long UPDATE(Area info)
        {
            try
            {
                S_area temp = new S_area();
                Table<S_area> table = db.GetTable<S_area>();
                temp = (from row in db.S_area where row.id == info.ID select row).First();

                //temp.id = info.ID;
                temp.cid = info.Cid;
                temp.name = info.Name;
                temp.lng = info.Lng;
                temp.lat = info.Lat;
                temp.zoom = info.Zoom;
                temp.type = info.Type;
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
        public IList<Area> SELECT_ALL()
        {
            try
            {
                IList<Area> result = new List<Area>();
                var temp = (from row in db.S_area orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Area element = new Area();

                    element.ID = temp.Current.id;
                    element.Cid = temp.Current.cid;
                    element.Name = temp.Current.name;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Zoom = temp.Current.zoom;
                    element.Type = temp.Current.type;
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
        public Area SELECT_BY_ID(short id)
        {
            try
            {
                Area rd = new Area();
                S_area temp = (from row in db.S_area where row.id == id select row).First();

                rd.ID = temp.id;
                rd.Cid = temp.cid;
                rd.Name = temp.name;
                rd.Lng = temp.lng;
                rd.Lat = temp.lat;
                rd.Zoom = temp.zoom;
                rd.Type = temp.type;
                rd.Isused = temp.isused;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据逻辑使用主码查询，true状态下name不可重复，不包含ID为0条目
        /// </summary>
        /// <param name="name">区域名字</param>
        /// <returns>结果</returns>
        public Area SELECT_BY_NAME_ISUSED(string name, bool isused)
        {
            try
            {
                Area rd = new Area();
                S_area temp = (from row in db.S_area where row.name == name && row.isused == isused && row.id != 0 select row).First();

                rd.ID = temp.id;
                rd.Cid = temp.cid;
                rd.Name = temp.name;
                rd.Lng = temp.lng;
                rd.Lat = temp.lat;
                rd.Zoom = temp.zoom;
                rd.Type = temp.type;
                rd.Isused = temp.isused;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取使用/未使用列表，不包含ID为0条目
        /// </summary>
        /// <param name="isused">是否使用</param>
        /// <returns>结果</returns>
        public IList<Area> SELECT_ISUSED(bool isused)
        {
            try
            {
                IList<Area> result = new List<Area>();
                var temp = (from row in db.S_area where row.isused == isused && row.id != 0 orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Area element = new Area();

                    element.ID = temp.Current.id;
                    element.Cid = temp.Current.cid;
                    element.Name = temp.Current.name;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Zoom = temp.Current.zoom;
                    element.Type = temp.Current.type;
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
        /// 根据区域属性查询，不包含ID为0条目
        /// </summary>
        /// <param name="type"></param>
        /// <param name="isused"></param>
        /// <returns></returns>
        public IList<Area> SELECT_BY_TYPE(bool type, bool isused)
        {
            try
            {
                IList<Area> result = new List<Area>();
                var temp = (from row in db.S_area where row.type == type && row.isused == isused && row.id != 0 orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Area element = new Area();

                    element.ID = temp.Current.id;
                    element.Cid = temp.Current.cid;
                    element.Name = temp.Current.name;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Zoom = temp.Current.zoom;
                    element.Type = temp.Current.type;
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
        /// 根据城市编码查询，不包含ID为0条目
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="type"></param>
        /// <param name="isused"></param>
        /// <returns></returns>
        public IList<Area> SELECT_BY_CID(short cid, bool isused)
        {
            try
            {
                IList<Area> result = new List<Area>();
                var temp = (from row in db.S_area where row.cid == cid && row.isused == isused && row.id != 0 orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Area element = new Area();

                    element.ID = temp.Current.id;
                    element.Cid = temp.Current.cid;
                    element.Name = temp.Current.name;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Zoom = temp.Current.zoom;
                    element.Type = temp.Current.type;
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
        /// 根据城市编码及区域属性查询，不包含ID为0条目
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="type"></param>
        /// <param name="isused"></param>
        /// <returns></returns>
        public IList<Area> SELECT_BY_CID_TYPE(short cid, bool type, bool isused)
        {
            try
            {
                IList<Area> result = new List<Area>();
                var temp = (from row in db.S_area where row.cid == cid && row.type == type && row.isused == isused && row.id != 0 orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Area element = new Area();

                    element.ID = temp.Current.id;
                    element.Cid = temp.Current.cid;
                    element.Name = temp.Current.name;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Zoom = temp.Current.zoom;
                    element.Type = temp.Current.type;
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
