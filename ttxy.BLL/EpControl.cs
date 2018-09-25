using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ttxy.Model;
using ttxy.DAL;

namespace ttxy.BLL
{
    /// <summary>
    /// Powered by Tab Tu
    /// 设备监控函数库
    /// </summary>
    public class EpControl
    {
        /// <summary>
        /// 获取当前主机个数
        /// </summary>
        /// <param name="state">0=离线，1=在线</param>
        /// <returns></returns>
        public int host_state_num(char state)
        {
            try
            {
                DSCfunction dsc = new DSCfunction();
                IList<SC_HOST> lsc = dsc.SELECT_HOST_STATE(state);
                return lsc.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取当前主机非状态值主机个数
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public int host_state_num_o(char state)
        {
            try
            {
                DSCfunction dsc = new DSCfunction();
                IList<SC_HOST> lsc = dsc.SELECT_HOST_STATE_O(state);
                return lsc.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取当前主机列表
        /// </summary>
        /// <param name="state">0=离线，1=在线</param>
        /// <returns></returns>
        public IList<SC_HOST> host_state_control(char state)
        {
            try
            {
                DSCfunction dsc = new DSCfunction();
                IList<SC_HOST> lsc = dsc.SELECT_HOST_STATE(state);
                DLanData dld = new DLanData();
                for (int i = 0; i < lsc.Count; i++)
                {
                    lsc[i].HostName = dld.SELECT_BY_ID(lsc[i].HOST_ID).Building;
                }
                return lsc;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取非状态当前主机列表
        /// </summary>
        /// <param name="state">0=离线，1=在线</param>
        /// <returns></returns>
        public IList<SC_HOST> host_state_control_o(char state)
        {
            try
            {
                DSCfunction dsc = new DSCfunction();
                IList<SC_HOST> lsc = dsc.SELECT_HOST_STATE_O(state);
                DLanData dld = new DLanData();
                for (int i = 0; i < lsc.Count; i++)
                {
                    lsc[i].HostName = dld.SELECT_BY_ID(lsc[i].HOST_ID).Building;
                }
                return lsc;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// 根据ID取得主机信息
        /// </summary>
        /// <param name="hostid">主机ID</param>
        /// <returns></returns>
        public SC_HOST gethost(int hostid)
        {
            try
            {
                DSCfunction dsc = new DSCfunction();
                return dsc.SELECT_HOST_ID(hostid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 更新主机信息
        /// </summary>
        /// <param name="sch"></param>
        /// <returns></returns>
        public int exchost(SC_HOST sch)
        {
            try
            {
                DSCfunction dsc = new DSCfunction();
                sch.STATE_DATE = DateTime.Now;
                return dsc.UPDATE_HOST(sch);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取HOST下设备
        /// </summary>
        /// <param name="hostid"></param>
        /// <returns></returns>
        public IList<SC_NODE> getnodelist(int hostid)
        {
            try
            {
                DSCfunction dsc = new DSCfunction();
                return dsc.SELECT_HOST_ID_NODELIST(hostid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
