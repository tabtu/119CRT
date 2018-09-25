using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class LanData
    {
        private int _ID;
        /// <summary>
        /// 自动制造ID
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private short _AreaData;
        /// <summary>
        /// 地区，外键
        /// </summary>
        public short AreaData
        {
            get { return _AreaData; }
            set { _AreaData = value; }
        }

        private double _Lng;
        /// <summary>
        /// 坐标LNG
        /// </summary>
        public double Lng
        {
            get { return _Lng; }
            set { _Lng = value; }
        }

        private double _Lat;
        /// <summary>
        /// 坐标LAT
        /// </summary>
        public double Lat
        {
            get { return _Lat; }
            set { _Lat = value; }
        }

        private string _Building;
        /// <summary>
        /// 建筑名称
        /// </summary>
        public string Building
        {
            get { return _Building; }
            set { _Building = value; }
        }

        private string _Address;
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private short _Mtid;
        /// <summary>
        /// 所属维护公司，外键
        /// </summary>
        public short Mtid
        {
            get { return _Mtid; }
            set { _Mtid = value; }
        }

        private short _Ptid;
        /// <summary>
        /// 所属物业公司，外键
        /// </summary>
        public short Ptid
        {
            get { return _Ptid; }
            set { _Ptid = value; }
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

        private short _Cate;
        /// <summary>
        /// 建筑分类
        /// </summary>
        public short Cate
        {
            get { return _Cate; }
            set { _Cate = value; }
        }

        private short _Type;
        /// <summary>
        /// 使用性质
        /// </summary>
        public short Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _Manager;
        /// <summary>
        /// 管理部门
        /// </summary>
        public string Manager
        {
            get { return _Manager; }
            set { _Manager = value; }
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

        private short _Color;
        /// <summary>
        ///  节点显示颜色：0绿色，1蓝色，2红色
        /// </summary>
        public short Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
    }
}
