using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class City
    {
        private short _Id;
        /// <summary>
        /// 城市编码，自动生成ID
        /// </summary>
        public short Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _CityName;
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
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
    }
}
