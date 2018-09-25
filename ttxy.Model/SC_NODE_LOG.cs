using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class SC_NODE_LOG
    {
        private int _LOG_ID;
        /// <summary>
        /// 日志ID
        /// </summary>
        public int LOG_ID
        {
            get { return _LOG_ID; }
            set { _LOG_ID = value; }
        }

        private int _HOST_ID;
        /// <summary>
        /// 主机ID
        /// </summary>
        public int HOST_ID
        {
            get { return _HOST_ID; }
            set { _HOST_ID = value; }
        }

        private string _ADDR_ID;
        /// <summary>
        /// 地址ID(与主机ID联合主键)
        /// </summary>
        public string ADDR_ID
        {
            get { return _ADDR_ID; }
            set { _ADDR_ID = value; }
        }

        private char _STATE;
        /// <summary>
        /// 状态：0=正常，1=故障，2=警告
        /// </summary>
        public char STATE
        {
            get { return _STATE; }
            set { _STATE = value; }
        }

        private DateTime _STATE_DATE;
        /// <summary>
        /// 状态时间
        /// </summary>
        public DateTime STATE_DATE
        {
            get { return _STATE_DATE; }
            set { _STATE_DATE = value; }
        }
    }
}
