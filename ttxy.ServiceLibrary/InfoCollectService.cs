using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using ttxy.Model;
using ttxy.BLL;

namespace ttxy.Host
{
    public class ttxyService : IttxyServiceJson, IttxyServiceXml
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public string echo (string Message)
        {
            return Message + Message;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public Members login(string username, string password)
        {
            UseFunc uf = new UseFunc();
            Members mb = new Members();
            mb.Account = username;
            mb.Password = password;
            return uf.userLogin(mb);
        }

        /// <summary>
        /// 获取可见大楼信息
        /// </summary>
        /// <param name="mb">用户信息</param>
        /// <returns></returns>
        public IList<LanData> getbuildings(string mid)
        {
            SysFunc sf = new SysFunc();
            UseFunc uf = new UseFunc();
            Members mb = uf.GetMembers(int.Parse(mid));
            IList<LanData> landatalist = new List<LanData>();
            if (mb.Type == 0)  // 超级权限
            {
                landatalist = uf.GetLandataList();
            }
            else if (mb.Type == 1)
            {
                Area curArea = sf.GetArea((short)sf.GetFireManage((short)mb.LinkId).Aid);
                if (curArea.Type == true)
                {
                    IList<Area> areas = sf.GetAreaList(curArea.Cid, false);
                    for (int i = 0; i < areas.Count; i++)
                    {
                        IList<LanData> tmp = uf.GetLandataList(areas[i].ID);
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            landatalist.Add(tmp[j]);
                        }
                    }
                }
                else
                {
                    landatalist = uf.GetLandataList(curArea.ID);
                }
            }
            else if (mb.Type == 2)
            {
                Area curArea = sf.GetArea((short)sf.GetFireHouse((short)mb.LinkId).Aid);
                if (curArea.Type == true)
                {
                    IList<Area> areas = sf.GetAreaList(curArea.Cid, false);
                    for (int i = 0; i < areas.Count; i++)
                    {
                        IList<LanData> tmp = uf.GetLandataList(areas[i].ID);
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            landatalist.Add(tmp[j]);
                        }
                    }
                }
                else
                {
                    landatalist = uf.GetLandataList(curArea.ID);
                }
            }
            else if (mb.Type == 3)
            {
                Area curArea = sf.GetArea((short)sf.GetControlCenter((short)mb.LinkId).Aid);
                if (curArea.Type == true)
                {
                    IList<Area> areas = sf.GetAreaList(curArea.Cid, false);
                    for (int i = 0; i < areas.Count; i++)
                    {
                        IList<LanData> tmp = uf.GetLandataList(areas[i].ID);
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            landatalist.Add(tmp[j]);
                        }
                    }
                }
                else
                {
                    landatalist = uf.GetLandataList(curArea.ID);
                }
            }
            else if (mb.Type == 6)
            {
                landatalist.Add(uf.GetLandata((int)mb.LinkId));
            }
            else if (mb.Type == 5)
            {
                landatalist = uf.GetLandataListPt((short)mb.LinkId);
            }
            else if (mb.Type == 4)
            {
                landatalist = uf.GetLandataListMt((short)mb.LinkId);
            }
            else
            {
                landatalist = null;
            }
            return landatalist;
        }

        /// <summary>
        /// 获取大楼楼层信息
        /// </summary>
        /// <param name="lanid">大楼id</param>
        /// <returns></returns>
        public IList<NodeData> getlevels(string lid)
        {
            UseFunc uf = new UseFunc();
            IList<NodeData> nodelist = uf.GetNodedataList(int.Parse(lid));
            return nodelist;
        }

        /// <summary>
        /// 获取楼层设备列表
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        public IList<EquipData> getequips(string nid)
        {
            UseFunc uf = new UseFunc();
            IList<EquipData> eqlist = uf.GetEquipdataList(int.Parse(nid));
            return eqlist;
        }
    }
}
