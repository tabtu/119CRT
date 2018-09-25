using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class Log
    {
        private long _Id;
        /// <summary>
        /// 日志ID
        /// </summary>
        public long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Tablename;
        /// <summary>
        /// 表名称
        /// </summary>
        public string Tablename
        {
            get { return _Tablename; }
            set { _Tablename = value; }
        }

        private long _Tableid;
        /// <summary>
        /// 被操作表主码ID
        /// </summary>
        public long Tableid
        {
            get { return _Tableid; }
            set { _Tableid = value; }
        }

        private int _Mid;
        /// <summary>
        /// 操作人员ID
        /// </summary>
        public int Mid
        {
            get { return _Mid; }
            set { _Mid = value; }
        }

        private DateTime _Datetime;
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime Datetime
        {
            get { return _Datetime; }
            set { _Datetime = value; }
        }

        private string _Discription;
        /// <summary>
        /// 操作描述
        /// </summary>
        public string Discription
        {
            get { return _Discription; }
            set { _Discription = value; }
        }
    }
}
