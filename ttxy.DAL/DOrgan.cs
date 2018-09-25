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
    public class DOrgan
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 插入函数
        /// </summary>
        /// <param name="info">Model</param>
        /// <returns>影响数据物理ID，已存在逻辑主码项返-1</returns>
        public int INSERT(Organ info)
        {
            try
            {
                if (SELECT_BY_NAME_ISUSED(info.Name, true) != null)
                {
                    return -1;
                }

                S_organ temp = new S_organ();
                //temp.id = info.Id;
                temp.name = info.Name;
                temp.description = info.Description;
                temp.type = info.Type;
                temp.isused = info.Isused;
                
                Table<S_organ> table = db.GetTable<S_organ>();
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
        public int UPDATE(Organ info)
        {
            try
            {
                if (SELECT_BY_NAME_ISUSED(info.Name, true) != null)
                {
                    return -1;
                }

                S_organ temp = new S_organ();
                Table<S_organ> table = db.GetTable<S_organ>();
                temp = (from row in db.S_organ where row.id == info.Id select row).First();

                //temp.id = info.Id;
                temp.name = info.Name;
                temp.description = info.Description;
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
        /// 逻辑删除
        /// </summary>
        /// <param name="id">物理主码</param>
        /// <returns>影响数据物理ID</returns>
        public int DELETE(short id)
        {
            try
            {
                S_organ temp = new S_organ();
                Table<S_organ> table = db.GetTable<S_organ>();
                temp = (from row in db.S_organ where row.id == id select row).First();

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
        public IList<Organ> SELECT_ALL()
        {
            try
            {
                IList<Organ> result = new List<Organ>();
                var temp = (from row in db.S_organ orderby row.id, row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Organ element = new Organ();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Description = temp.Current.description;
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
        public Organ SELECT_BY_ID(short id)
        {
            try
            {
                Organ rd = new Organ();
                S_organ temp = (from row in db.S_organ where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Name = temp.name;
                rd.Description = temp.description;
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
        /// 根据逻辑主码查询
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="isused">在用</param>
        /// <returns>结果</returns>
        public Organ SELECT_BY_NAME_ISUSED(string name, bool isused)
        {
            try
            {
                Organ rd = new Organ();
                S_organ temp = (from row in db.S_organ where row.name == name && row.isused == isused select row).First();

                rd.Id = temp.id;
                rd.Name = temp.name;
                rd.Description = temp.description;
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
        /// 获取 在用/不在用 列表
        /// </summary>
        /// <param name="isused">在用状态</param>
        /// <returns>结果列表</returns>
        public IList<Organ> SELECT_BY_ISUSED(bool isused)
        {
            try
            {
                IList<Organ> result = new List<Organ>();
                var temp = (from row in db.S_organ where row.isused == isused orderby row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Organ element = new Organ();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Description = temp.Current.description;
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
        /// 获取某个类型标识部门列表
        /// </summary>
        /// <param name="type">类型标识</param>
        /// <returns>结果列表</returns>
        public IList<Organ> SELECT_BY_TYPE(string type)
        {
            try
            {
                IList<Organ> result = new List<Organ>();
                var temp = (from row in db.S_organ where row.type == type orderby row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Organ element = new Organ();

                    element.Id = temp.Current.id;
                    element.Name = temp.Current.name;
                    element.Description = temp.Current.description;
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