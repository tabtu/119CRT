using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DAccessType
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 获取整张列表
        /// </summary>
        /// <returns>结果列表</returns>
        public IList<AccessType> SELECT_ALL()
        {
            try
            {
                IList<AccessType> result = new List<AccessType>();
                var temp = (from row in db.S_accesstype orderby row.id ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    AccessType element = new AccessType();

                    element.Id = temp.Current.id;
                    element.Des = temp.Current.jrfs;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}