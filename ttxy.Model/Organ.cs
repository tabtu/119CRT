using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class Organ
    {
        private short _Id;
        /// <summary>
        /// 机构ID
        /// </summary>
        public short Id
        {
            get { return _Id; }
            set { _Id = value; }
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

        private string _Description;
        /// <summary>
        /// 描述ID
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _Type;
        /// <summary>
        /// 机构类型
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
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

        // 为完成函数配置及数据库更改
        private short _Aid;
        /// <summary>
        /// 管理区域ID
        /// </summary>
        public short Aid
        {
            get { return _Aid; }
            set { _Aid = value; }
        }

        /// <summary>
        /// 制造实例，只包含ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public static Organ NewOrgan(short id)
        {
            Organ tmp = new Organ();
            tmp.Id = id;
            return tmp;
        }
    }
}
