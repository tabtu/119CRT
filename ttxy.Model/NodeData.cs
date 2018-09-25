using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class NodeData
    {
        private int _Id;
        /// <summary>
        /// 物理主码
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _Lid;
        /// <summary>
        /// 所属楼宇，外键
        /// </summary>
        public int Lid
        {
            get { return _Lid; }
            set { _Lid = value; }
        }

        private string _PicPath;
        /// <summary>
        /// 背景图片
        /// </summary>
        public string PicPath
        {
            get { return _PicPath; }
            set { _PicPath = value; }
        }

        private string _PicName;
        /// <summary>
        /// 图片名称
        /// </summary>
        public string PicName
        {
            get { return _PicName; }
            set { _PicName = value; }
        }

        private string _PicDescription;
        /// <summary>
        /// 图片描述
        /// </summary>
        public string PicDescription
        {
            get { return _PicDescription; }
            set { _PicDescription = value; }
        }

        private string _Description;
        /// <summary>
        /// 备注描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private bool _Mainmap;
        /// <summary>
        /// 是否是预案图
        /// </summary>
        public bool Mainmap
        {
            get { return _Mainmap; }
            set { _Mainmap = value; }
        }

        private short _Sort;
        /// <summary>
        /// 逻辑排序
        /// </summary>
        public short Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
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
