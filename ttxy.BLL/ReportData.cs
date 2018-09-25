using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using ttxy.Model;
using ttxy.DAL;

namespace ttxy.BLL
{
    /// <summary>
    /// Powered by Tab Tu
    /// 报表制造函数
    /// </summary>
    public class ReportData
    {
        private DLanData dld = new DLanData();
        private DArea da = new DArea();
        public IList<LanData> ResultDate(short areaid, string jzpj, double rzllow, double rzlhigh)
        {

            //IList<LanData> result0 = dld.SELECT_BY_AREAID(areaid, true);
            //IList<LanData> result1 = dld.SELECT_BY_JZPJ(jzpj, true);
            //IList<LanData> result2 = dld.SELECT_BY_RZL(rzllow, rzlhigh, true);

            try
            {
                return dld.SELECT_ALL();
                //if (jzpj == "-1" && areaid == 1)
                //{
                //    return dld.SELECT_BY_RZL(rzllow, rzlhigh, true);
                //}
                //else if (areaid == 1)
                //{
                //    return dld.INTERSECTION(dld.SELECT_BY_JZPJ(jzpj, true), dld.SELECT_BY_RZL(rzllow, rzlhigh, true));
                //}
                //else if (jzpj == "-1")
                //{
                //    return dld.INTERSECTION(dld.SELECT_BY_AREAID(areaid, true), dld.SELECT_BY_RZL(rzllow, rzlhigh, true));
                //}
                //else
                //{
                //    return dld.INTERSECTION(dld.INTERSECTION(dld.SELECT_BY_AREAID(areaid, true), dld.SELECT_BY_JZPJ(jzpj, true)), dld.SELECT_BY_RZL(rzllow, rzlhigh, true));
                //}
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 导出报表
        /// </summary>
        /// <param name="list">list数据</param>
        /// <returns>报表</returns>
        public DataTable Show_Report(IList<LanData> list)
        {
            try
            {
                string s0 = "区域";
                string s1 = "小区名称";
                string s2 = "住户量";
                string s3 = "入住数量";
                string s4 = "选择项1（演示）";
                string s5 = "选择项2（演示）";
                string s6 = "选择项3（演示）";
                string s7 = "数据项1（演示）";
                string s8 = "数据项2（演示）";
                string s9 = "选择项3（演示）";
                string s10 = "选择项4（演示）";
                DataTable dt = new DataTable();

                dt.Columns.Add(new DataColumn(s0, typeof(string)));
                dt.Columns.Add(new DataColumn(s2, typeof(string)));
                dt.Columns.Add(new DataColumn(s1, typeof(string)));
                dt.Columns.Add(new DataColumn(s3, typeof(string)));
                dt.Columns.Add(new DataColumn(s4, typeof(string)));
                dt.Columns.Add(new DataColumn(s5, typeof(string)));
                dt.Columns.Add(new DataColumn(s6, typeof(string)));
                dt.Columns.Add(new DataColumn(s7, typeof(string)));
                dt.Columns.Add(new DataColumn(s8, typeof(string)));
                dt.Columns.Add(new DataColumn(s9, typeof(string)));
                dt.Columns.Add(new DataColumn(s10, typeof(string)));

                for (int k = 0; k < list.Count; k++)
                {
                    DataRow row = dt.NewRow();
                    row[s0] = da.SELECT_BY_ID(list[k].AreaData).Name;
                    row[s1] = list[k].Building;
                    row[s2] = list[k].Building;
                    row[s3] = list[k].Building + "%";
                    //row[4] = list[k].JX_DianXin;
                    if (list[k].Isused == true)
                    {
                        row[s4] = "已完成（演示）";
                    }
                    else
                    {
                        row[s4] = "未完成（演示）";
                    }
                    //row[s5] = list[k].JX_LianTong;
                    if (list[k].Isused == true)
                    {
                        row[s5] = "已勾选（演示）";
                    }
                    else
                    {
                        row[s5] = "未勾选（演示）";
                    }
                    //row[s6] = list[k].JX_YiDong;
                    if (list[k].Isused == true)
                    {
                        row[s6] = "成功（演示）";
                    }
                    else
                    {
                        row[s6] = "失败（演示）";
                    }
                    row[s7] = list[k].Isused;
                    row[s8] = list[k].Isused;
                    row[s9] = list[k].Isused;
                    if (list[k].Isused == true)
                    {
                        row[10] = "较差";
                    }
                    else if (list[k].Isused == false)
                    {
                        row[s10] = "合格";
                    }
                    else
                    {
                        row[s10] = "优秀";
                    }
                    row[s10] = list[k].Building;
                    dt.Rows.Add(row);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }


        public DataTable Show_Report_1(Area area)
        {
            try
            {
                string s0 = "区域";
                string s1 = "完成联网总数";
                string s2 = "当前在线总数";
                string s3 = "入住数量";
                string s4 = "在线率";
                string s5 = "上月增加数";
                DataTable dt = new DataTable();

                dt.Columns.Add(new DataColumn(s0, typeof(string)));
                dt.Columns.Add(new DataColumn(s2, typeof(string)));
                dt.Columns.Add(new DataColumn(s1, typeof(string)));
                dt.Columns.Add(new DataColumn(s3, typeof(string)));
                dt.Columns.Add(new DataColumn(s4, typeof(string)));
                dt.Columns.Add(new DataColumn(s5, typeof(string)));

                SysFunc sf = new SysFunc();
                IList<Area> areas = new List<Area>();
                if (area.ID == 0)
                {
                    areas = sf.GetAreaList(1, false);
                    IList<Area> ta = sf.GetAreaList(2, false);
                    for (int k = 0; k < ta.Count; k++)
                    {
                        areas.Add(ta[k]);
                    }
                }
                //IList<Area> listarea = sf.GetAreaList(area, false);
                else
                {
                    if (area.Type == true)
                    {
                        areas = sf.GetAreaList(area.Cid, false);
                    }
                    else
                    {
                        areas = sf.GetAreaList(area.Cid, true);
                    }
                }
                for (int k = 0; k < areas.Count; k++)
                {
                    DataRow row = dt.NewRow();
                    row[s0] = areas[k].Name;
                    row[s1] = "*";
                    row[s2] = "*";
                    row[s3] = "*";
                    row[s4] = "*";
                    row[s5] = "*";
                    dt.Rows.Add(row);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable Show_Report_2(short area)
        {
            try
            {
                string s0 = "维护单位名称";
                string s1 = "完成联网总数";
                string s2 = "目前在线总数";
                string s3 = "入住数量";
                string s4 = "在线率";
                string s5 = "上月增加数";
                string s6 = "上月维护记录数量";
                string s7 = "维护保证率";

                DataTable dt = new DataTable();

                dt.Columns.Add(new DataColumn(s0, typeof(string)));
                dt.Columns.Add(new DataColumn(s2, typeof(string)));
                dt.Columns.Add(new DataColumn(s1, typeof(string)));
                dt.Columns.Add(new DataColumn(s3, typeof(string)));
                dt.Columns.Add(new DataColumn(s4, typeof(string)));
                dt.Columns.Add(new DataColumn(s5, typeof(string)));
                dt.Columns.Add(new DataColumn(s6, typeof(string)));
                dt.Columns.Add(new DataColumn(s7, typeof(string)));


                string[] ss = { "贵州科盾消防事务有限公司", "贵州荣亚自控工程有限公司" };
                
                for (int k = 0; k < 2; k++)
                {
                    DataRow row = dt.NewRow();
                    row[s0] = ss[k];
                    row[s1] = "*";
                    row[s2] = "*";
                    row[s3] = "*";
                    row[s4] = "*";
                    row[s5] = "*";
                    row[s6] = "*";
                    row[s7] = "*";
                    dt.Rows.Add(row);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable Show_Report_3(short area)
        {
            try
            {
                string s0 = "系统名称";
                string s1 = "设备总数";
                string s2 = "火警报警次数";
                string s3 = "故障报警次数";
                string s4 = "故障总时长";
                string s5 = "故障时间比";
                string s6 = "系统安全分析";
                string s7 = "设备追溯信息";
                DataTable dt = new DataTable();

                dt.Columns.Add(new DataColumn(s0, typeof(string)));
                dt.Columns.Add(new DataColumn(s2, typeof(string)));
                dt.Columns.Add(new DataColumn(s1, typeof(string)));
                dt.Columns.Add(new DataColumn(s3, typeof(string)));
                dt.Columns.Add(new DataColumn(s4, typeof(string)));
                dt.Columns.Add(new DataColumn(s5, typeof(string)));
                dt.Columns.Add(new DataColumn(s6, typeof(string)));
                dt.Columns.Add(new DataColumn(s7, typeof(string)));


                string[] ss = {"火灾自动报警系统", "消防给水系统", "自动喷水灭火系统", "气体灭火系统", "消火栓系统", "消防电源", "消防电源", "防火分隔", "其它"};


                for (int k = 0; k < 9; k++)
                {
                    DataRow row = dt.NewRow();
                    row[s0] = ss[k];
                    row[s1] = "*";
                    row[s2] = "*";
                    row[s3] = "*";
                    row[s4] = "*";
                    row[s5] = "*";
                    row[s6] = "中级";
                    row[s7] = "查看";
                    dt.Rows.Add(row);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
