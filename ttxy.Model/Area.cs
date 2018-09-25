using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class Area
    {
        private short _ID;
        /// <summary>
        /// 自动制造ID
        /// </summary>
        public short ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private short _Cid;
        /// <summary>
        /// 所属城市
        /// </summary>
        public short Cid
        {
            get { return _Cid; }
            set { _Cid = value; }
        }

        private string _Name;
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private double _Lng;
        /// <summary>
        /// 中心点经度
        /// </summary>
        public double Lng
        {
            get { return _Lng; }
            set { _Lng = value; }
        }

        private double _Lat;
        /// <summary>
        /// 中心点纬度
        /// </summary>
        public double Lat
        {
            get { return _Lat; }
            set { _Lat = value; }
        }

        private short _Zoom;
        /// <summary>
        /// 地图放大等级
        /// </summary>
        public short Zoom
        {
            get { return _Zoom; }
            set { _Zoom = value; }
        }

        private bool _Type;
        /// <summary>
        /// 区域属性，True为城市，False为辖区
        /// </summary>
        public bool Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private bool _Isused;
        /// <summary>
        /// 标记是否使用
        /// </summary>
        public bool Isused
        {
            get { return _Isused; }
            set { _Isused = value; }
        }
    }
}
