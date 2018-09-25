using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using ttxy.Model;
using ttxy.DAL;
using ttxy.Security;

namespace ttxy.BLL
{
    /// <summary>
    /// Powered by Tab Tu
    /// 用户数据管理函数库
    /// </summary>
    public class ExcFunc
    {
// ---------------------------建筑楼层及设备---------------------------
        /// <summary>
        /// 添加建筑数据
        /// </summary>
        /// <param name="info">建筑数据</param>
        /// <param name="userid">操作ID</param>
        /// <returns></returns>
        public int AddLandata(LanData info, int userid)
        {
            try
            {
                DLanData dld = new DLanData();
                info.PASSWD = md5.Md5Encode(info.PASSWD);
                info.Isused = true;
                int result = dld.INSERT(info);

                if (result != 0)
                {
                    SC_HOST sch = new SC_HOST();
                    sch.HOST_ID = result;
                    sch.HOST_CODE = info.HOST_CODE;
                    sch.PASSWD = info.PASSWD;
                    sch.ACTIVE = info.ACTIVE;
                    sch.COMM_DATE = DateTime.Now;
                    sch.COMM_VARS = "0";
                    sch.STATE = '1';
                    sch.STATE_DATE = DateTime.Now;
                    DSCfunction dsc = new DSCfunction();
                    dsc.INSERT_HOST(sch);

                    NodeData nd = new NodeData();
                    nd.Lid = result;
                    nd.Sort = 0;
                    nd.Mainmap = true;
                    nd.Isused = true;
                    nd.PicName = "预案图";
                    nd.Description = "";
                    nd.PicDescription = "";
                    nd.PicPath = "";
                    DNodeData dnd = new DNodeData();
                    dnd.INSERT(nd);

                    Log log = new Log();
                    log.Tablename = "LanData";
                    log.Tableid = result;
                    log.Mid = userid;
                    log.Datetime = DateTime.Now;
                    log.Discription = "Insert";
                    DLog dl = new DLog();
                    dl.INSERT(log);
                }
                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新建筑数据
        /// </summary>
        /// <param name="info">建筑数据</param>
        /// <param name="userid">操作ID</param>
        /// <returns></returns>
        public int EditLandata(LanData info, int userid)
        {
            try
            {
                DLanData dld = new DLanData();
                if (info.PASSWD != "")
                {
                    info.PASSWD = md5.Md5Encode(info.PASSWD);
                }
                else
                {
                    info.PASSWD = dld.SELECT_BY_ID(info.ID).PASSWD;
                }
                info.Isused = true;
                int result = dld.UPDATE(info);


                DSCfunction dsc = new DSCfunction();
                SC_HOST sch = dsc.SELECT_HOST_ID(info.ID);
                sch.HOST_CODE = info.HOST_CODE;
                sch.PASSWD = info.PASSWD;
                sch.ACTIVE = info.ACTIVE;
                dsc.UPDATE_HOST(sch);

                Log log = new Log();
                log.Tablename = "LanData";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Update";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int DeleteLanData(int id, int userid)
        {
            try
            {
                DLanData dfh = new DLanData();
                LanData tmp = dfh.SELECT_BY_ID(id);
                tmp.Isused = false;
                int result = dfh.UPDATE(tmp);

                Log log = new Log();
                log.Tablename = "LanData";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Delete";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 添加楼层数据
        /// </summary>
        /// <param name="info">楼层数据</param>
        /// <param name="userid">操作ID</param>
        /// <returns></returns>
        public int AddNodedata(NodeData info, int userid)
        {
            try
            {
                DNodeData dnd = new DNodeData();
                info.Isused = true;
                int result = dnd.INSERT(info);

                Log log = new Log();
                log.Tablename = "NodeData";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Insert";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新楼层数据
        /// </summary>
        /// <param name="info">楼层数据</param>
        /// <param name="userid">操作ID</param>
        /// <returns></returns>
        public int EditNodedata(NodeData info, int userid)
        {
            try
            {
                DNodeData dnd = new DNodeData();
                info.Isused = true;
                int result = dnd.UPDATE(info);

                Log log = new Log();
                log.Tablename = "NodeData";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Update";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int DeleteNodeData(int id, int userid)
        {
            try
            {
                DNodeData dfh = new DNodeData();
                NodeData tmp = dfh.SELECT_BY_ID(id);
                tmp.Isused = false;
                int result = dfh.UPDATE(tmp);

                Log log = new Log();
                log.Tablename = "NodeData";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Delete";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 添加设备数据
        /// </summary>
        /// <param name="info">设备数据</param>
        /// <param name="userid">操作ID</param>
        /// <returns></returns>
        public long AddEquipdata(EquipData info, int userid)
        {
            try
            {
                DEquipData ded = new DEquipData();
                info.Isused = true;
                long result = ded.INSERT(info);

                Log log = new Log();
                log.Tablename = "EquipData";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Insert";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新楼层数据
        /// </summary>
        /// <param name="info">楼层数据</param>
        /// <param name="userid">操作ID</param>
        /// <returns></returns>
        public long EditEquipdata(EquipData info, int userid)
        {
            try
            {
                DEquipData ded = new DEquipData();
                info.Isused = true;
                long result = ded.UPDATE(info);

                Log log = new Log();
                log.Tablename = "EquipData";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Update";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public long DeleteEquipData(long id, int userid)
        {
            try
            {
                DEquipData dfh = new DEquipData();
                EquipData tmp = dfh.SELECT_BY_ID(id);
                tmp.Isused = false;
                long result = dfh.UPDATE(tmp);

                Log log = new Log();
                log.Tablename = "EquipData";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Delete";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

// ---------------------------消防队数据管理---------------------------
        /// <summary>
        /// 添加消防队信息
        /// </summary>
        /// <param name="info">消防队主体信息</param>
        /// <param name="userid">操作者ID</param>
        /// <returns></returns>
        public short Addfirehouse(FireHouse info, int userid)
        {
            try
            {
                DFireHouse dfh = new DFireHouse();
                info.Isused = true;
                short result = dfh.INSERT(info);

                Log log = new Log();
                log.Tablename = "FireHouse";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Insert";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新消防队信息
        /// </summary>
        /// <param name="info">消防队主体信息</param>
        /// <param name="userid">操作者ID</param>
        /// <returns></returns>
        public short EditFirehouse(FireHouse info, int userid)
        {
            try
            {
                DFireHouse dfh = new DFireHouse();
                info.Isused = true;
                short result = dfh.UPDATE(info);

                Log log = new Log();
                log.Tablename = "FireHouse";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Update";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public short DeleteFirehouse(short id, int userid)
        {
            try
            {
                DFireHouse dfh = new DFireHouse();
                FireHouse tmp = dfh.SELECT_BY_ID(id);
                tmp.Isused = false;
                short result = dfh.UPDATE(tmp);

                Log log = new Log();
                log.Tablename = "FireHouse";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Delete";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

// ---------------------------新闻消息维护---------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="news"></param>
        /// <param name="useid"></param>
        /// <returns></returns>
        public long AddNews(News info, int userid)
        {
            try
            {
                DNews dfh = new DNews();
                info.Isused = true;
                long result = dfh.INSERT(info);

                Log log = new Log();
                log.Tablename = "News";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Insert";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新新闻信息
        /// </summary>
        /// <param name="info">新闻主体信息</param>
        /// <param name="userid">操作者ID</param>
        /// <returns></returns>
        public long EditNews(News info, int userid)
        {
            try
            {
                DNews dfh = new DNews();
                info.Isused = true;
                long result = dfh.UPDATE(info);

                Log log = new Log();
                log.Tablename = "News";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Update";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public long DeleteNews(long id, int userid)
        {
            try
            {
                DNews dfh = new DNews();
                News tmp = dfh.SELECT_BY_ID(id);
                tmp.Isused = false;
                long result = dfh.UPDATE(tmp);

                Log log = new Log();
                log.Tablename = "News";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Delete";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

// ---------------------------用户资料维护---------------------------
        /// <summary>
        /// 初始化角色密码函数
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        public int InitePassword(int id)
        {
            try
            {
                DMembers dm = new DMembers();
                Members tmp = dm.SELECT_BY_ID(id);
                tmp.Password = Security.md5.Md5Encode("123456");
                int result = dm.UPDATE(tmp);

                DLog dl = new DLog();
                Log log = new Log();
                log.Tablename = "Members";
                log.Tableid = id;
                log.Mid = id;
                log.Datetime = DateTime.Now;
                log.Discription = "修改角色密码(初始化)";
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 插入用户帐号
        /// </summary>
        /// <param name="info">帐号信息</param>
        /// <param name="userid">操作者ID</param>
        /// <returns></returns>
        public int Addmembers(Members info, int userid)
        {
            try
            {
                DMembers dm = new DMembers();
                info.Password = Security.md5.Md5Encode(info.Password);
                info.Isused = true;
                int result = dm.INSERT(info);

                Log log = new Log();
                log.Tablename = "Members";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Insert";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新用户资料
        /// </summary>
        /// <param name="info">用户资料</param>
        /// <param name="userid">操作者ID</param>
        /// <returns></returns>
        public int Editmembers(Members info, int userid)
        {
            try
            {
                DMembers dm = new DMembers();
                info.Password = Security.md5.Md5Encode(info.Password);
                info.Isused = true;
                int result = dm.UPDATE(info);

                Log log = new Log();
                log.Tablename = "Members";
                log.Tableid = result;
                log.Mid = userid;
                log.Datetime = DateTime.Now;
                log.Discription = "Update";
                DLog dl = new DLog();
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

    }
}
