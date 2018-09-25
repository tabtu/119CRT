using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DEquipData
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<EquipData> INTERSECTION(IList<EquipData> temp1, IList<EquipData> temp2)
        {
            try
            {
                List<EquipData> list = new List<EquipData>();
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
        public long INSERT(EquipData info)
        {
            try
            {
                U_equipdata temp = new U_equipdata();
                //temp.id = info.Id;
                temp.nid = info.Nid;
                temp.x = info.X;
                temp.y = info.Y;
                temp.description = info.Description;
                temp.type = info.Type;
                temp.isused = info.Isused;
                temp.status = info.Status;
                temp.logicid = info.Logicid;
                temp.url = info.Url;

                Table<U_equipdata> table = db.GetTable<U_equipdata>();
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
        public long UPDATE(EquipData info)
        {
            try
            {
                U_equipdata temp = new U_equipdata();
                Table<U_equipdata> table = db.GetTable<U_equipdata>();
                temp = (from row in db.U_equipdata where row.id == info.Id select row).First();

                //temp.id = info.Id;
                temp.nid = info.Nid;
                temp.x = info.X;
                temp.y = info.Y;
                temp.description = info.Description;
                temp.type = info.Type;
                temp.isused = info.Isused;
                temp.status = info.Status;
                temp.logicid = info.Logicid;
                temp.url = info.Url;

                db.SubmitChanges();
                return temp.id;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 根据物理主码查询
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>结果</returns>
        public EquipData SELECT_BY_ID(long id)
        {
            try
            {
                EquipData rd = new EquipData();
                U_equipdata temp = (from row in db.U_equipdata where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Nid = temp.nid;
                rd.X = temp.x;
                rd.Y = temp.y;
                rd.Description = temp.description;
                rd.Type = temp.type;
                rd.Isused = temp.isused;
                rd.Status = temp.status;
                rd.Logicid = temp.logicid;
                rd.Url = temp.url;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取整张列表
        /// </summary>
        /// <returns>结果列表</returns>
        public IList<EquipData> SELECT_ALL()
        {
            try
            {
                IList<EquipData> result = new List<EquipData>();
                var temp = (from row in db.U_equipdata orderby row.nid ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    EquipData element = new EquipData();

                    element.Id = temp.Current.id;
                    element.Nid = temp.Current.nid;
                    element.X = temp.Current.x;
                    element.Y = temp.Current.y;
                    element.Description = temp.Current.description;
                    element.Type = temp.Current.type;
                    element.Isused = temp.Current.isused;
                    element.Status = temp.Current.status;
                    element.Logicid = temp.Current.logicid;
                    element.Url = temp.Current.url;

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
        /// <param name="nid"></param>
        /// <returns></returns>
        public IList<EquipData> SELECT_BY_NID(int nid)
        {
            try
            {
                IList<EquipData> result = new List<EquipData>();
                var temp = (from row in db.U_equipdata where row.nid == nid orderby row.x ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    EquipData element = new EquipData();

                    element.Id = temp.Current.id;
                    element.Nid = temp.Current.nid;
                    element.X = temp.Current.x;
                    element.Y = temp.Current.y;
                    element.Description = temp.Current.description;
                    element.Type = temp.Current.type;
                    element.Isused = temp.Current.isused;
                    element.Status = temp.Current.status;
                    element.Logicid = temp.Current.logicid;
                    element.Url = temp.Current.url;

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
