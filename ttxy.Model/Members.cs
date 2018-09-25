using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    /// <summary>
    /// 逻辑主码：Account + Isused
    /// </summary>
    public class Members
    {
        private int _Id;
        /// <summary>
        /// 成员ID
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Account;
        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        private string _Password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Tel;
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }

        private short _Type;
        /// <summary>
        /// 账号类型
        /// 0超级权限
        /// 1管理部门
        /// 2战斗部队
        /// 3监控中心
        /// 4维护公司
        /// 5物业公司
        /// 6消防主机
        /// </summary>
        public short Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private long _LinkId;
        /// <summary>
        /// 外连接ID，根据type连接
        /// </summary>
        public long LinkId
        {
            get { return _LinkId; }
            set { _LinkId = value; }
        }

        private bool _Isused;
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool Isused
        {
            get { return _Isused; }
            set { _Isused = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Members newMembers(int id)
        {
            Members tmp = new Members();
            tmp.Id = id;
            return tmp;
        }
    }
}
