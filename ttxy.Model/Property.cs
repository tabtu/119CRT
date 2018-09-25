using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class Property
    {
        private short _Id;
        /// <summary>
        /// 物业公司ID
        /// </summary>
        public short Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Name;
        /// <summary>
        /// 物业公司名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Description;
        /// <summary>
        /// 物业公司描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
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
