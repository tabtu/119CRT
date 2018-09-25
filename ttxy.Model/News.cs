using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.Model
{
    public class News
    {
        private int _Id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _Mid;
        /// <summary>
        /// 
        /// </summary>
        public int Mid
        {
            get { return _Mid; }
            set { _Mid = value; }
        }

        private string _Title;
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Context;
        /// <summary>
        /// 
        /// </summary>
        public string Context
        {
            get { return _Context; }
            set { _Context = value; }
        }

        private DateTime _Datetime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Datetime
        {
            get { return _Datetime; }
            set { _Datetime = value; }
        }

        private bool _Cn;
        /// <summary>
        /// 
        /// </summary>
        public bool Cn
        {
            get { return _Cn; }
            set { _Cn = value; }
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
