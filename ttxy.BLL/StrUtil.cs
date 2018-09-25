using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.BLL
{
    /// <summary>
    /// Powered by Tab Tu
    /// 系统数据连接字符串
    /// </summary>
    public class StrUtil
    {
        /// <summary>
        /// 主数据库连接字符串
        /// </summary>
        public const string sqlcon = DAL.MyDataContext.db_resourse;

        // 测试点
        public const string upload = @"h:\users\ttxy\desktop\lanmap\website\upload\map\";
        public const string mainurl = "http://localhost:11281/website/";

        // 正式点
        //public const string upload = @"D:\crt\119crt\Upload\map\";
        //public const string mainurl = "http://www.119crt.com/";
    }
}
