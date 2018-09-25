using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class AccessType
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

        private string _Des;
        /// <summary>
        /// 
        /// </summary>
        public string Des
        {
            get { return _Des; }
            set { _Des = value; }
        }
    }
}
