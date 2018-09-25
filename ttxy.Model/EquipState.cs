using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class EquipState
    {
        private long _Id;
        /// <summary>
        /// 监控表设备物理主码，与EquipData物理主码相同
        /// </summary>
        public long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private short _State;
        /// <summary>
        /// 当前状态编码
        /// </summary>
        public short State
        {
            get { return _State; }
            set { _State = value; }
        }

        private string _Logicid;
        /// <summary>
        /// 逻辑ID，与EquipData设备编码相同
        /// </summary>
        public string Logicid
        {
            get { return _Logicid; }
            set { _Logicid = value; }
        }
    }
}
