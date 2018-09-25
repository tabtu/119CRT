using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class SC_HOST
    {
        private int _HOST_ID;
        /// <summary>
        /// 主机ID,主键
        /// </summary>
        public int HOST_ID
        {
            get { return _HOST_ID; }
            set { _HOST_ID = value; }
        }

        private string _HOST_CODE;
        /// <summary>
        /// 代码，用于登录
        /// </summary>
        public string HOST_CODE
        {
            get { return _HOST_CODE; }
            set { _HOST_CODE = value; }
        }

        private string _PASSWD;
        /// <summary>
        /// 密码，用于登录，(md5-32小写)
        /// </summary>
        public string PASSWD
        {
            get { return _PASSWD; }
            set { _PASSWD = value; }
        }

        private char _ACTIVE;
        /// <summary>
        /// 帐号状态：0=失效，1=有效
        /// </summary>
        public char ACTIVE
        {
            get { return _ACTIVE; }
            set { _ACTIVE = value; }
        }

        private DateTime _COMM_DATE;
        /// <summary>
        /// 通信时间
        /// </summary>
        public DateTime COMM_DATE
        {
            get { return _COMM_DATE; }
            set { _COMM_DATE = value; }
        }

        private string _COMM_VARS;
        /// <summary>
        /// 通信参数
        /// </summary>
        public string COMM_VARS
        {
            get { return _COMM_VARS; }
            set { _COMM_VARS = value; }
        }

        private char _STATE;
        /// <summary>
        /// 在线状态：0=离线，1=在线
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

        private string _HostName;
        /// <summary>
        /// 主机对应建筑名称，提供显示使用
        /// </summary>
        public string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }
    }
}
