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
    /// 2015.8.14
    /// 系统数据操作库
    /// </summary>
    public class SysFunc
    {
        public Property GetOrgan(short id)
        {
            DProperty dor = new DProperty();
            return dor.SELECT_BY_ID(id);
        }

// ---------------------------权限相关列表---------------------------
        /// <summary>
        /// 获取战斗部队列表
        /// </summary>
        /// <returns></returns>
        public IList<FireHouse> GetFireHouseList()
        {
            try
            {
                DFireHouse dfh = new DFireHouse();
                return dfh.SELECT_BY_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取管理部门列表
        /// </summary>
        /// <returns></returns>
        public IList<FireManage> GetFireManageList()
        {
            try
            {
                DFireManage dfh = new DFireManage();
                return dfh.SELECT_BY_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取监控中心列表
        /// </summary>
        /// <returns></returns>
        public IList<ControlCenter> GetControlCenterList()
        {
            try
            {
                DControlCenter dfh = new DControlCenter();
                return dfh.SELECT_BY_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 战斗部队信息
        /// </summary>
        /// <param name="id">战斗部队ID</param>
        /// <returns></returns>
        public FireHouse GetFireHouse(short id)
        {
            try
            {
                DFireHouse dfh = new DFireHouse();
                return dfh.SELECT_BY_ID(id);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public IList<FireHouse> GetFireHouseList(short aid)
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

        /// <summary>
        /// 管理部门信息
        /// </summary>
        /// <param name="id">管理部门ID</param>
        /// <returns></returns>
        public FireManage GetFireManage(short id)
        {
            try
            {
                DFireManage dfh = new DFireManage();
                return dfh.SELECT_BY_ID(id);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 监控中心信息
        /// </summary>
        /// <param name="id">监控中心ID</param>
        /// <returns></returns>
        public ControlCenter GetControlCenter(short id)
        {
            try
            {
                DControlCenter dfh = new DControlCenter();
                return dfh.SELECT_BY_ID(id);
            }
            catch
            {
                return null;
            }
        }

// ---------------------------区域控制函数---------------------------
        /// <summary>
        /// 获取全部区域列表
        /// </summary>
        /// <returns></returns>
        public IList<Area> GetAreaList()
        {
            try
            {
                DArea da = new DArea();
                return da.SELECT_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <param name="cid">城市编码</param>
        /// <param name="type">true市/false区</param>
        /// <returns></returns>
        public IList<Area> GetAreaList(short cid, bool type)
        {
            try
            {
                DArea da = new DArea();
                return da.SELECT_BY_CID_TYPE(cid, type, true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <param name="cid">城市编码</param>
        /// <returns></returns>
        public IList<Area> GetAreaList(short cid)
        {
            try
            {
                DArea da = new DArea();
                return da.SELECT_BY_CID(cid, true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <param name="type">true市/false区</param>
        /// <returns></returns>
        public IList<Area> GetAreaList(bool type)
        {
            try
            {
                DArea da = new DArea();
                return da.SELECT_BY_TYPE(type, true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <param name="id">区域ID</param>
        /// <returns></returns>
        public Area GetArea(short id)
        {
            try
            {
                DArea da = new DArea();
                return da.SELECT_BY_ID(id);
            }
            catch
            {
                return null;
            }
        }

// ---------------------------属性列表函数---------------------------
        /// <summary>
        /// 获取在用建筑分类列表
        /// </summary>
        /// <returns></returns>
        public IList<LanCate> GetLanCate()
        {
            try
            {
                DLanCate dlc = new DLanCate();
                return dlc.SELECT_BY_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取在用建筑属性列表
        /// </summary>
        /// <returns></returns>
        public IList<LanType> GetLanType()
        {
            try
            {
                DLanType dlt = new DLanType();
                return dlt.SELECT_BY_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取在用设备类型列表
        /// </summary>
        /// <returns></returns>
        public IList<EquipType> GetEquipType()
        {
            try
            {
                DEquipType det = new DEquipType();
                return det.SELECT_BY_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取设备状态列表
        /// </summary>
        /// <returns></returns>
        public IList<EquipStatus> GetEquipStatus()
        {
            try
            {
                DEquipStatus des = new DEquipStatus();
                return des.SELECT_BY_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取设备状态
        /// </summary>
        /// <param name="id">状态ID</param>
        /// <returns></returns>
        public EquipType GetEquipType(short id)
        {
            try
            {
                DEquipType det = new DEquipType();
                return det.SELECT_BY_ID(id);
            }
            catch
            {
                return null;
            }
        }

// ---------------------------物业维护列表函数---------------------------
        /// <summary>
        /// 获取在用维护公司列表
        /// </summary>
        /// <returns></returns>
        public IList<Maintenance> GetMaintenance()
        {
            try
            {
                DMaintenance dm = new DMaintenance();
                return dm.SELECT_BY_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取在用物业公司列表
        /// </summary>
        /// <returns></returns>
        public IList<Property> GetProperty()
        {
            try
            {
                DProperty dp = new DProperty();
                return dp.SELECT_BY_ISUSED(true);
            }
            catch
            {
                return null;
            }
        }
    }
}
