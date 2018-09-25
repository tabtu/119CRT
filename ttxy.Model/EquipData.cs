using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class EquipData
    {
        private long _Id;
        /// <summary>
        /// 物理主码
        /// </summary>
        public long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _Nid;
        /// <summary>
        /// 节点ID，外键
        /// </summary>
        public int Nid
        {
            get { return _Nid; }
            set { _Nid = value; }
        }

        private short _X;
        /// <summary>
        /// X坐标
        /// </summary>
        public short X
        {
            get { return _X; }
            set { _X = value; }
        }

        private short _Y;
        /// <summary>
        /// Y坐标
        /// </summary>
        public short Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        private string _Description;
        /// <summary>
        /// 描述（备注）
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private bool _Isused;
        /// <summary>
        /// 标记可用
        /// </summary>
        public bool Isused
        {
            get { return _Isused; }
            set { _Isused = value; }
        }

        private short _Type;
        /// <summary>
        /// 设备类型，外键
        /// </summary>
        public short Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private short _Status;
        /// <summary>
        /// 设备状态，外键
        /// </summary>
        public short Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Logicid;
        /// <summary>
        /// 7位数字或字符组成的字符串.（仅当设备类型为消防主机时编码为“000000”）
        /// </summary>
        public string Logicid
        {
            get { return _Logicid; }
            set { _Logicid = value; }
        }

        private string _Url;
        /// <summary>
        /// 设备超链接
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
    }
}
