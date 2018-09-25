using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class FireHouse
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

        private string _Name;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private short _Aid;
        /// <summary>
        /// 
        /// </summary>
        public short Aid
        {
            get { return _Aid; }
            set { _Aid = value; }
        }

        private double _Lng;
        /// <summary>
        /// 
        /// </summary>
        public double Lng
        {
            get { return _Lng; }
            set { _Lng = value; }
        }

        private double _Lat;
        /// <summary>
        /// 
        /// </summary>
        public double Lat
        {
            get { return _Lat; }
            set { _Lat = value; }
        }

        private string _Description;
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private bool _Isused;
        /// <summary>
        /// 
        /// </summary>
        public bool Isused
        {
            get { return _Isused; }
            set { _Isused = value; }
        }
    }
}
