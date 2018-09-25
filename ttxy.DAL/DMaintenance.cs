using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DMaintenance
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 插入函数
        /// </summary>
        /// <param name="info">Model</param>
        /// <returns>影响数据物理ID，已存在逻辑主码项返-1</returns>
        public int INSERT(Maintenance info)
        {
            try
            {
                if (SELECT_BY_NAME_ISUSED(info.Name, true) != null)
                {
                    return -1;
                }

                U_maintenance temp = new U_maintenance();
                //temp.id = info.Id;
                temp.name = info.Name;
                temp.isused = info.Isused;
                
                Table<U_maintenance> table = db.GetTable<U_maintenance>();
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
        public int UPDATE(Maintenance info)
        {
            try
            {
                if (SELECT_BY_NAME_ISUSED(info.Name, true) != null)
                {
                    return -1;
                }

                U_maintenance temp = new U_maintenance();
                Table<U_maintenance> table = db.GetTable<U_maintenance>();
                temp = (from row in db.U_maintenance where row.id == info.Id select row).First();

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
        /// 逻辑删除
        /// </summary>
        /// <param name="id">物理主码</param>
        /// <returns>影响数据物理ID</returns>
        public int DELETE(short id)
        {
            try
            {
                U_maintenance temp = new U_maintenance();
                Table<U_maintenance> table = db.GetTable<U_maintenance>();
                temp = (from row in db.U_maintenance where row.id == id select row).First();

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
        public IList<Maintenance> SELECT_ALL()
        {
            try
            {
                IList<Maintenance> result = new List<Maintenance>();
                var temp = (from row in db.U_maintenance select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Maintenance element = new Maintenance();

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
        public Maintenance SELECT_BY_ID(short id)
        {
            try
            {
                Maintenance rd = new Maintenance();
                U_maintenance temp = (from row in db.U_maintenance where row.id == id select row).First();

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
        /// 根据逻辑主码查询
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="isused">在用</param>
        /// <returns>结果</returns>
        public Maintenance SELECT_BY_NAME_ISUSED(string name, bool isused)
        {
            try
            {
                Maintenance rd = new Maintenance();
                U_maintenance temp = (from row in db.U_maintenance where row.name == name && row.isused == isused select row).First();

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
        /// 获取 在用/不在用 列表
        /// </summary>
        /// <param name="isused">在用状态</param>
        /// <returns>结果列表</returns>
        public IList<Maintenance> SELECT_BY_ISUSED(bool isused)
        {
            try
            {
                IList<Maintenance> result = new List<Maintenance>();
                var temp = (from row in db.U_maintenance where row.isused == isused select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Maintenance element = new Maintenance();

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