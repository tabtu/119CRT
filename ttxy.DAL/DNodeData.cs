using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DNodeData
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        /// <summary>
        /// 交集函数
        /// </summary>
        /// <param name="temp1">列表1</param>
        /// <param name="temp2">列表2</param>
        /// <returns>交集列表</returns>
        public IList<NodeData> INTERSECTION(IList<NodeData> temp1, IList<NodeData> temp2)
        {
            try
            {
                List<NodeData> list = new List<NodeData>();
                var temp0 = temp1.GetEnumerator();
                while (temp0.MoveNext())
                {
                    var temp = temp2.GetEnumerator();
                    while (temp.MoveNext())
                    {
                        if (temp0.Current.Id == temp.Current.Id)
                        {
                            list.Add(temp.Current);
                        }
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 插入函数
        /// </summary>
        /// <param name="info">Model</param>
        /// <returns>影响数据物理ID</returns>
        public int INSERT(NodeData info)
        {
            try
            {
                U_nodedata temp = new U_nodedata();

                //temp.id = info.ID;
                temp.lanid = info.Lid;
                temp.picpath = info.PicPath;
                temp.picname = info.PicName;
                temp.picdesc = info.PicDescription;
                temp.description = info.Description;
                temp.sort = info.Sort;
                temp.mainmap = info.Mainmap;
                temp.isused = info.Isused;

                Table<U_nodedata> table = db.GetTable<U_nodedata>();
                table.InsertOnSubmit(temp);
                db.SubmitChanges();
                return temp.id;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 更新函数
        /// </summary>
        /// <param name="info">Model</param>
        /// <returns>影响数据物理ID，已存在逻辑主码返回-1</returns>
        public int UPDATE(NodeData info)
        {
            try
            {
                U_nodedata temp = new U_nodedata();
                Table<U_nodedata> table = db.GetTable<U_nodedata>();
                temp = (from row in db.U_nodedata where row.id == info.Id select row).First();

                //temp.id = info.ID;
                temp.lanid = info.Lid;
                temp.picpath = info.PicPath;
                temp.picname = info.PicName;
                temp.picdesc = info.PicDescription;
                temp.description = info.Description;
                temp.mainmap = info.Mainmap;
                temp.sort = info.Sort;
                temp.isused = info.Isused;

                db.SubmitChanges();
                return temp.id;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 获取整张列表
        /// </summary>
        /// <returns>结果列表</returns>
        public IList<NodeData> SELECT_ALL()
        {
            try
            {
                IList<NodeData> result = new List<NodeData>();
                var temp = (from row in db.U_nodedata orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    NodeData element = new NodeData();

                    element.Id = temp.Current.id;
                    element.Lid = temp.Current.lanid;
                    element.PicPath = temp.Current.picpath;
                    element.PicName = temp.Current.picname;
                    element.PicDescription = temp.Current.picdesc;
                    element.Description = temp.Current.description;
                    element.Mainmap = temp.Current.mainmap;
                    element.Sort = temp.Current.sort;
                    element.Isused = temp.Current.isused;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据物理主码查询
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>结果</returns>
        public NodeData SELECT_BY_ID(int id)
        {
            try
            {
                NodeData rd = new NodeData();
                U_nodedata temp = (from row in db.U_nodedata where row.id == id select row).First();

                rd.Id = temp.id;
                rd.Lid = temp.lanid;
                rd.PicPath = temp.picpath;
                rd.PicName = temp.picname;
                rd.PicDescription = temp.picdesc;
                rd.Description = temp.description;
                rd.Mainmap = temp.mainmap;
                rd.Sort = temp.sort;
                rd.Isused = temp.isused;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据楼宇ID查询
        /// </summary>
        /// <param name="lid"></param>
        /// <returns></returns>
        public IList<NodeData> SELECT_BY_LID(int lid)
        {
            try
            {
                IList<NodeData> result = new List<NodeData>();
                var temp = (from row in db.U_nodedata where row.lanid == lid orderby row.sort ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    NodeData element = new NodeData();

                    element.Id = temp.Current.id;
                    element.Lid = temp.Current.lanid;
                    element.PicPath = temp.Current.picpath;
                    element.PicName = temp.Current.picname;
                    element.PicDescription = temp.Current.picdesc;
                    element.Description = temp.Current.description;
                    element.Mainmap = temp.Current.mainmap;
                    element.Sort = temp.Current.sort;
                    element.Isused = temp.Current.isused;

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
