//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data.Linq;

//using ttxy.Model;

//namespace ttxy.DAL
//{
//    public class DLanDataHistory
//    {
//        private LinqDataContext db = MyDataContext.GetConnection();

//        /// <summary>
//        /// 交集函数
//        /// </summary>
//        /// <param name="temp1">列表1</param>
//        /// <param name="temp2">列表2</param>
//        /// <returns>交集列表</returns>
//        public IList<LanDataHistory> INTERSECTION(IList<LanDataHistory> temp1, IList<LanDataHistory> temp2)
//        {
//            try
//            {
//                List<LanDataHistory> list = new List<LanDataHistory>();
//                var temp0 = temp1.GetEnumerator();
//                while (temp0.MoveNext())
//                {
//                    var temp = temp2.GetEnumerator();
//                    while (temp.MoveNext())
//                    {
//                        if (temp0.Current.ID == temp.Current.ID)
//                        {
//                            list.Add(temp.Current);
//                        }
//                    }
//                }
//                return list;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        /// <summary>
//        /// 插入函数
//        /// </summary>
//        /// <param name="info">Model</param>
//        /// <returns>影响数据物理ID</returns>
//        public long INSERT(LanDataHistory info)
//        {
//            try
//            {
//                S_landatahistory temp = new S_landatahistory();

//                info.JieRuFangShi = "NONE";

//                //temp.id = info.ID;
//                temp.ldid = info.LanDataID;
//                temp.zhl = info.ZhuHuLiang;
//                temp.rzl = info.RuZhuLv;
//                temp.jxdx = info.JX_DianXin;
//                temp.jxlt = info.JX_LianTong;
//                temp.jxyd = info.JX_YiDong;
//                temp.dks = info.DuanKouShu;
//                temp.szs = info.ShiZhuangShu;
//                temp.jzpj = info.JingZhengPingJi;
//                temp.jrfs = info.JieRuFangShi;
//                temp.datetime = info.Datetime;

//                Table<S_landatahistory> table = db.GetTable<S_landatahistory>();
//                table.InsertOnSubmit(temp);
//                db.SubmitChanges();
//                return temp.id;
//            }
//            catch
//            {
//                return -2;
//            }
//        }

//        /// <summary>
//        /// 更新函数
//        /// </summary>
//        /// <param name="info">Model</param>
//        /// <returns>影响数据物理ID，已存在逻辑主码返回-1</returns>
//        public long UPDATE(LanDataHistory info)
//        {
//            try
//            {
//                S_landatahistory temp = new S_landatahistory();
//                Table<S_landatahistory> table = db.GetTable<S_landatahistory>();
//                temp = (from row in db.S_landatahistory where row.id == info.ID select row).First();

//                //temp.id = info.ID;
//                temp.ldid = info.LanDataID;
//                temp.zhl = info.ZhuHuLiang;
//                temp.rzl = info.RuZhuLv;
//                temp.jxdx = info.JX_DianXin;
//                temp.jxlt = info.JX_LianTong;
//                temp.jxyd = info.JX_YiDong;
//                temp.dks = info.DuanKouShu;
//                temp.szs = info.ShiZhuangShu;
//                temp.jzpj = info.JingZhengPingJi;
//                temp.jrfs = info.JieRuFangShi;
//                temp.datetime = info.Datetime;

//                db.SubmitChanges();
//                return temp.id;
//            }
//            catch
//            {
//                return -2;
//            }
//        }

//        /// <summary>
//        /// 获取整张列表
//        /// </summary>
//        /// <returns>结果列表</returns>
//        public IList<LanDataHistory> SELECT_ALL()
//        {
//            try
//            {
//                IList<LanDataHistory> result = new List<LanDataHistory>();
//                var temp = (from row in db.S_landatahistory orderby row.datetime ascending select row).GetEnumerator();
//                while (temp.MoveNext())
//                {
//                    LanDataHistory element = new LanDataHistory();

//                    element.ID = temp.Current.id;
//                    element.LanDataID = temp.Current.ldid;
//                    element.ZhuHuLiang = temp.Current.zhl;
//                    element.RuZhuLv = temp.Current.rzl;
//                    element.JX_DianXin = temp.Current.jxdx;
//                    element.JX_LianTong = temp.Current.jxlt;
//                    element.JX_YiDong = temp.Current.jxyd;
//                    element.DuanKouShu = temp.Current.dks;
//                    element.ShiZhuangShu = temp.Current.szs;
//                    element.JingZhengPingJi = temp.Current.jzpj;
//                    element.JieRuFangShi = temp.Current.jrfs;
//                    element.Datetime = temp.Current.datetime;


//                    result.Add(element);
//                }
//                return result;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        /// <summary>
//        /// 根据物理主码查询
//        /// </summary>
//        /// <param name="id">id</param>
//        /// <returns>结果</returns>
//        public LanDataHistory SELECT_BY_ID(long id)
//        {
//            try
//            {
//                LanDataHistory rd = new LanDataHistory();
//                S_landatahistory temp = (from row in db.S_landatahistory where row.id == id select row).First();

//                rd.ID = temp.id;
//                rd.LanDataID = temp.ldid;
//                rd.ZhuHuLiang = temp.zhl;
//                rd.RuZhuLv = temp.rzl;
//                rd.JX_DianXin = temp.jxdx;
//                rd.JX_LianTong = temp.jxlt;
//                rd.JX_YiDong = temp.jxyd;
//                rd.DuanKouShu = temp.dks;
//                rd.ShiZhuangShu = temp.szs;
//                rd.JingZhengPingJi = temp.jzpj;
//                rd.JieRuFangShi = temp.jrfs;
//                rd.Datetime = temp.datetime;

//                return rd;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        /// <summary>
//        /// 获取使用的列表
//        /// </summary>
//        /// <returns></returns>
//        public IList<LanDataHistory> SELECT_USED()
//        {
//            try
//            {
//                IList<LanDataHistory> result = new List<LanDataHistory>();
//                var temp = (from row in db.S_landatahistory orderby row.datetime ascending select row).GetEnumerator();
//                while (temp.MoveNext())
//                {
//                    LanDataHistory element = new LanDataHistory();

//                    element.ID = temp.Current.id;
//                    element.LanDataID = temp.Current.ldid;
//                    element.ZhuHuLiang = temp.Current.zhl;
//                    element.RuZhuLv = temp.Current.rzl;
//                    element.JX_DianXin = temp.Current.jxdx;
//                    element.JX_LianTong = temp.Current.jxlt;
//                    element.JX_YiDong = temp.Current.jxyd;
//                    element.DuanKouShu = temp.Current.dks;
//                    element.ShiZhuangShu = temp.Current.szs;
//                    element.JingZhengPingJi = temp.Current.jzpj;
//                    element.JieRuFangShi = temp.Current.jrfs;
//                    element.Datetime = temp.Current.datetime;

//                    result.Add(element);
//                }
//                return result;
//            }
//            catch
//            {
//                return null;
//            }
//        }
//    }
//}
