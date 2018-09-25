using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ttxy.Model;
using ttxy.DAL;

namespace ttxy.BLL
{
    /// <summary>
    /// Powered by Deng Ji
    /// 2015.8.9
    /// 用户数据操作库
    /// </summary>
    public class UseFunc
    {
// ---------------------------建筑数据获取---------------------------
        /// <summary>
        /// 获取在用建筑列表
        /// </summary>
        /// <returns></returns>
        public IList<LanData> GetLandataList()
        {
            try
            {
                DLanData dld = new DLanData();
                return dld.SELECT_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取建筑列表
        /// </summary>
        /// <param name="id">区域ID</param>
        /// <returns></returns>
        public IList<LanData> GetLandataList(short id)
        {
            try
            {
                DLanData dld = new DLanData();
                return dld.SELECT_BY_AREAID(id, true);;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取建筑列表
        /// </summary>
        /// <param name="id">模糊搜索名字关键字</param>
        /// <returns></returns>
        public IList<LanData> GetLandataList(string name)
        {
            try
            {
                DLanData dld = new DLanData();
                return dld.SELECT_LIKE_NAME(name, true); ;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取建筑列表
        /// </summary>
        /// <param name="id">模糊搜索名字关键字</param>
        /// <param name="aid">所属区域ID</param>
        /// <returns></returns>
        public IList<LanData> GetLandataList(string name, short aid)
        {
            try
            {
                DLanData dld = new DLanData();
                return dld.SELECT_LIKE_NAME_AID(name, aid, true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取建筑列表
        /// </summary>
        /// <param name="ptid">物业公司ID</param>
        /// <returns></returns>
        public IList<LanData> GetLandataListPt(short ptid)
        {
            try
            {
                DLanData dld = new DLanData();
                return dld.SELECT_BY_PTID(ptid, true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取建筑列表
        /// </summary>
        /// <param name="ptid">维护公司ID</param>
        /// <returns></returns>
        public IList<LanData> GetLandataListMt(short ptid)
        {
            try
            {
                DLanData dld = new DLanData();
                return dld.SELECT_BY_MTID(ptid, true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取建筑信息
        /// </summary>
        /// <param name="id">建筑ID</param>
        /// <returns></returns>
        public LanData GetLandata(int id)
        {
            try
            {
                DLanData dld = new DLanData();
                return dld.SELECT_BY_ID(id);
            }
            catch
            {
                return null;
            }
        }

// ---------------------------楼层数据获取---------------------------
        /// <summary>
        /// 获取建筑楼层列表
        /// </summary>
        /// <param name="lid">建筑ID</param>
        /// <returns></returns>
        public IList<NodeData> GetNodedataList(int lid)
        {
            try
            {
                DNodeData dnd = new DNodeData();
                return dnd.SELECT_BY_LID(lid);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取建筑楼层信息
        /// </summary>
        /// <param name="nid">楼层ID</param>
        /// <returns></returns>
        public NodeData GetNodedata(int nid)
        {
            try
            {
                DNodeData dnd = new DNodeData();
                return dnd.SELECT_BY_ID(nid);
            }
            catch
            {
                return null;
            }
        }

// ---------------------------设备数据获取---------------------------
        /// <summary>
        /// 获取某楼层设备信息
        /// </summary>
        /// <param name="nid">楼层ID</param>
        /// <returns></returns>
        public IList<EquipData> GetEquipdataList(int nid)
        {
            try
            {
                DEquipData ded = new DEquipData();
                return ded.SELECT_BY_NID(nid);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取某个设备信息
        /// </summary>
        /// <param name="id">设备ID</param>
        /// <returns></returns>
        public EquipData GetEquipdata(long id)
        {
            try
            {
                DEquipData ded = new DEquipData();
                return ded.SELECT_BY_ID(id);
            }
            catch
            {
                return null;
            }
        }

// ---------------------------设备数据获取---------------------------
        /// <summary>
        /// 获取所在区域在用消防部门列表
        /// </summary>
        /// <param name="aid">区域ID</param>
        /// <returns></returns>
        public IList<FireHouse> GetFirehouse(short aid)
        {
            try
            {
                DFireHouse dfh = new DFireHouse();
                return dfh.SELECT_BY_AID(aid);
            }
            catch
            {
                return null;
            }
        }

// ---------------------------新闻获取---------------------------
        /// <summary>
        /// 获取新闻信息//汤妞子
        /// </summary>
        /// <param name="id">模糊搜索新闻关键字</param>
        /// <returns></returns>
        public IList<News> GetNewsList(string name)
        {
            try
            {
                DNews ded = new DNews();
                return ded.LIKE_BY_NAME(name);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据新闻属性获取新闻列表
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public IList<News> GetNews(bool cn)
        {
            try
            {
                DNews dn = new DNews();
                return dn.SELECT_ISUSED_CN(true, cn);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据新闻ID获取具体新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public News GetNews(int id)
        {
            try
            {
                DNews ded = new DNews();
                return ded.SELECT_BY_ID(id);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据新闻是否显示属性获取新闻列表
        /// </summary>
        /// <param name="isused"></param>
        /// <returns></returns>
        public IList<News> GetNewsIsused(bool isused)// 添加tang
        {
            try
            {
                DNews ded = new DNews();
                return ded.SELECT_BY_ISUSED(isused);
            }
            catch
            {
                return null;
            }
        }
// ---------------------------用户资料获取---------------------------
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public Members userLogin(Members member)
        {
            try
            {
                DMembers dm = new DMembers();
                Members result = dm.SELECT_BY_ACCOUNT_ISUSED(member.Account, true);
                string pwdmd5 = Security.md5.Md5Encode(member.Password);
                if (result.Password == pwdmd5)
                {
                    //result.Account = pwdmd5;
                    result.Password = result.Account;
                    return result;
                }
                else
                {
                    member.Password = null;
                    return member;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 检查用户名是否可用
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool userCheck(string account)
        {
            try
            {
                DMembers dm = new DMembers();
                Members result = dm.SELECT_BY_ACCOUNT_ISUSED(account, true);
                if (result == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="isused">是否在用</param>
        /// <returns></returns>
        public IList<Members> GetMembers(bool isused)
        {
            try
            {
                DMembers dm = new DMembers();
                return dm.SELECT_BY_ISUSED(isused);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取具体用户
        /// </summary>
        /// <param name="type">权限类型</param>
        /// <param name="linkid">外连接ID</param>
        /// <returns></returns>
        public Members GetMembers(short type, long linkid)
        {
            try
            {
                DMembers dm = new DMembers();
                return dm.SELECT_BY_TYPE_LINK(type, linkid);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="id">用户主码</param>
        /// <returns></returns>
        public Members GetMembers(int id)
        {
            try
            {
                DMembers dm = new DMembers();
                return dm.SELECT_BY_ID(id);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>//tangniuzi
        /// 获取用户信息
        /// </summary>
        /// <param name="id">模糊搜索名字关键字</param>
        /// <returns></returns>
        public IList<Members> GetMembersList(string name)
        {
            try
            {
                DMembers dm = new DMembers();
                return dm.LIKE_BY_NAME(name);
            }
            catch
            {
                return null;
            }
        }
    }
}
