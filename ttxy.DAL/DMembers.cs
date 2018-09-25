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
    public class DMembers
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        private DProperty dorgan = new DProperty();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<Members> INTERSECTION(IList<Members> temp1, IList<Members> temp2)
        {
            try
            {
                List<Members> list = new List<Members>();
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
        /// <returns>影响数据物理ID，已存在逻辑主码项返-1</returns>
        public int INSERT(Members info)
        {
            try
            {
                U_members temp = new U_members();

                //temp.id = info.Id;
                temp.account = info.Account;
                temp.password = info.Password;
                temp.name = info.Name;
                temp.tel = info.Tel;
                temp.isused = info.Isused;
                temp.type = info.Type;
                temp.linkid = info.LinkId;

                Table<U_members> table = db.GetTable<U_members>();

                if (SELECT_BY_ACCOUNT_ISUSED(info.Account, true) != null)
                {
                    return -1;
                }
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
        public int UPDATE(Members info)
        {
            try
            {
                U_members temp = new U_members();
                Table<U_members> table = db.GetTable<U_members>();
                Members existtemp = SELECT_BY_ACCOUNT_ISUSED(info.Account, true);
                if (existtemp != null && existtemp.Id != info.Id)
                {
                    return -1;
                }

                temp = (from row in db.U_members where row.id == info.Id select row).First();

                //temp.id = info.Id;
                temp.account = info.Account;
                temp.password = info.Password;
                temp.name = info.Name;
                temp.tel = info.Tel;
                temp.isused = info.Isused;
                temp.type = info.Type;
                temp.linkid = info.LinkId;

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
                U_members temp = new U_members();
                Table<U_members> table = db.GetTable<U_members>();
                temp = (from row in db.U_members where row.id == id select row).First();

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
        public IList<Members> SELECT_ALL()
        {
            try
            {
                IList<Members> result = new List<Members>();
                var temp = (from row in db.U_members orderby row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Members element = new Members();

                    element.Id = temp.Current.id;
                    element.Account = temp.Current.account;
                    element.Password = temp.Current.password;
                    element.Name = temp.Current.name;
                    element.Tel = temp.Current.tel;
                    element.Isused = temp.Current.isused;
                    element.Type = temp.Current.type;
                    element.LinkId = temp.Current.linkid;

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
        /// 根据物理主码获取
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>结果</returns>
        public Members SELECT_BY_ID(int id)
        {
            try
            {
                Members rd = new Members();
                U_members temp = (from row in db.U_members where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Account = temp.account;
                rd.Password = temp.password;
                rd.Name = temp.name;
                rd.Tel = temp.tel;
                rd.Isused = temp.isused;
                rd.Type = temp.type;
                rd.LinkId = temp.linkid;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 按姓名模糊搜索
        /// </summary>
        /// <param name="name">关键字</param>
        /// <returns>结果列表</returns>
        public IList<Members> LIKE_BY_NAME(string name)
        {
            try
            {
                IList<Members> result = new List<Members>();
                var temp = (from row in db.U_members where row.name.Contains(name) orderby row.linkid ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Members element = new Members();

                    element.Id = temp.Current.id;
                    element.Account = temp.Current.account;
                    element.Password = temp.Current.password;
                    element.Name = temp.Current.name;
                    element.Tel = temp.Current.tel;
                    element.Isused = temp.Current.isused;
                    element.Type = temp.Current.type;
                    element.LinkId = temp.Current.linkid;

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
        /// 根据逻辑主码查询
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="isused">在用</param>
        /// <returns>结果</returns>
        public Members SELECT_BY_ACCOUNT_ISUSED(string account, bool isused)
        {
            try
            {
                Members rd = new Members();
                U_members temp = (from row in db.U_members where row.account == account && row.isused == isused select row).First();

                rd.Id = temp.id;
                rd.Account = temp.account;
                rd.Password = temp.password;
                rd.Name = temp.name;
                rd.Tel = temp.tel;
                rd.Isused = temp.isused;
                rd.Type = temp.type;
                rd.LinkId = temp.linkid;

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
        public IList<Members> SELECT_BY_ISUSED(bool isused)
        {
            try
            {
                IList<Members> result = new List<Members>();
                var temp = (from row in db.U_members where row.isused == isused orderby row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Members element = new Members();

                    element.Id = temp.Current.id;
                    element.Account = temp.Current.account;
                    element.Password = temp.Current.password;
                    element.Name = temp.Current.name;
                    element.Tel = temp.Current.tel;
                    element.Isused = temp.Current.isused;
                    element.Type = temp.Current.type;
                    element.LinkId = temp.Current.linkid;

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
        /// 获取某个部门人员列表
        /// </summary>
        /// <param name="oid">部门ID</param>
        /// <returns>结果列表</returns>
        public IList<Members> SELECT_BY_OID(short oid)
        {
            try
            {
                IList<Members> result = new List<Members>();
                var temp = (from row in db.U_members where row.linkid == oid orderby row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Members element = new Members();

                    element.Id = temp.Current.id;
                    element.Account = temp.Current.account;
                    element.Password = temp.Current.password;
                    element.Name = temp.Current.name;
                    element.Tel = temp.Current.tel;
                    element.Isused = temp.Current.isused;
                    element.Type = temp.Current.type;
                    element.LinkId = temp.Current.linkid;

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
        /// 获取某权值下人员列表
        /// </summary>
        /// <param name="limit">权值字符</param>
        /// <returns>结果列表</returns>
        public IList<Members> SELECT_BY_LIMIT(short limit)
        {
            try
            {
                IList<Members> result = new List<Members>();
                var temp = (from row in db.U_members where row.type == limit orderby row.name ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    Members element = new Members();

                    element.Id = temp.Current.id;
                    element.Account = temp.Current.account;
                    element.Password = temp.Current.password;
                    element.Name = temp.Current.name;
                    element.Tel = temp.Current.tel;
                    element.Isused = temp.Current.isused;
                    element.Type = temp.Current.type;
                    element.LinkId = temp.Current.linkid;

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
        /// 获取某权值及链接ID
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="linkid"></param>
        /// <returns></returns>
        public Members SELECT_BY_TYPE_LINK(short limit, long linkid)
        {
            try
            {
                Members rd = new Members();
                U_members temp = (from row in db.U_members where row.type == limit && row.linkid == linkid select row).First();

                rd.Id = temp.id;
                rd.Account = temp.account;
                rd.Password = temp.password;
                rd.Name = temp.name;
                rd.Tel = temp.tel;
                rd.Isused = temp.isused;
                rd.Type = temp.type;
                rd.LinkId = temp.linkid;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="id">物理主码</param>
        /// <returns>影响数据物理ID</returns>
        public int Xqx_DELETE(Members info)
        {

            try
            {
                U_members temp = new U_members();
                Table<U_members> table = db.GetTable<U_members>();
                temp = (from row in db.U_members where row.id == info.Id select row).First();
                table.DeleteOnSubmit(temp);
                db.SubmitChanges();
                return temp.id;
            }
            catch
            {
                return -2;
            }
        }

    }
}
