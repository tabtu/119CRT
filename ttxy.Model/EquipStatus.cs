using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class EquipStatus
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
