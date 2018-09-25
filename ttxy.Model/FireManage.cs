using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class FireManage
    {
        private short _Id;
        /// <summary>
        /// 
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

        private short _Aid;
        /// <summary>
        /// 
        /// </summary>
        public short Aid
        {
            get { return _Aid; }
            set { _Aid = value; }
        }

        private string _Description;
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private bool _Isused;
        /// <summary>
        /// 
        /// </summary>
        public bool Isused
        {
            get { return _Isused; }
            set { _Isused = value; }
        }
    }
}
