using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class EquipType
    {
        private short _Id;
        /// <summary>
        /// 物理主码
        /// </summary>
        public short Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Name;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private short _Sort;
        /// <summary>
        /// 排序
        /// </summary>
        public short Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }

        private string _Icon;
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
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
    }
}
