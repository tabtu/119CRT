using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DLanData
    {
        private LinqDataContext db = MyDataContext.GetConnection();

        public IList<LanData> INTERSECTION(IList<LanData> temp1, IList<LanData> temp2)
        {
            try
            {
                List<LanData> list = new List<LanData>();
                var temp0 = temp1.GetEnumerator();
                while (temp0.MoveNext())
                {
                    var temp = temp2.GetEnumerator();
                    while (temp.MoveNext())
                    {
                        if (temp0.Current.ID == temp.Current.ID)
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

        public int INSERT(LanData info)
        {
            try
            {
                U_landata temp = new U_landata();

                //temp.id = info.ID;
                temp.areaid = info.AreaData;
                temp.lng = info.Lng;
                temp.lat = info.Lat;
                temp.building = info.Building;
                temp.address = info.Address;
                temp.ptid = info.Ptid;
                temp.mtid = info.Mtid;
                temp.isused = info.Isused;
                temp.cate = info.Cate;
                temp.type = info.Type;
                temp.manager = info.Manager;
                temp.HOST_CODE = info.HOST_CODE;
                temp.PASSWD = info.PASSWD;
                temp.ACTIVE = info.ACTIVE;

                Table<U_landata> table = db.GetTable<U_landata>();
                table.InsertOnSubmit(temp);
                db.SubmitChanges();
                return temp.id;
            }
            catch
            {
                return -2;
            }
        }

        public int UPDATE(LanData info)
        {
            try
            {
                U_landata temp = new U_landata();
                Table<U_landata> table = db.GetTable<U_landata>();
                temp = (from row in db.U_landata where row.id == info.ID select row).First();

                //temp.id = info.ID;
                temp.areaid = info.AreaData;
                temp.lng = info.Lng;
                temp.lat = info.Lat;
                temp.building = info.Building;
                temp.address = info.Address;
                temp.ptid = info.Ptid;
                temp.mtid = info.Mtid; ;
                temp.isused = info.Isused;
                temp.cate = info.Cate;
                temp.type = info.Type;
                temp.manager = info.Manager;
                temp.HOST_CODE = info.HOST_CODE;
                temp.PASSWD = info.PASSWD;
                temp.ACTIVE = info.ACTIVE;

                db.SubmitChanges();
                return temp.id;
            }
            catch
            {
                return -2;
            }
        }


        public LanData SELECT_BY_ID(int id)
        {
            try
            {
                LanData rd = new LanData();
                U_landata temp = (from row in db.U_landata where row.id == id select row).First();

                rd.ID = temp.id;
                rd.AreaData = temp.areaid;
                rd.Lng = temp.lng;
                rd.Lat = temp.lat;
                rd.Building = temp.building;
                rd.Address = temp.address;
                rd.Ptid = temp.ptid;
                rd.Mtid = temp.mtid;
                rd.Isused = temp.isused;
                rd.Cate = temp.cate;
                rd.Type = temp.type;
                rd.Manager = temp.manager;
                rd.HOST_CODE = temp.HOST_CODE;
                rd.PASSWD = temp.PASSWD;
                rd.ACTIVE = temp.ACTIVE;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        public LanData SELECT_BY_NAME(string name)
        {
            try
            {
                LanData rd = new LanData();
                U_landata temp = (from row in db.U_landata where row.building == name && row.isused == true select row).First();

                rd.ID = temp.id;
                rd.AreaData = temp.areaid;
                rd.Lng = temp.lng;
                rd.Lat = temp.lat;
                rd.Building = temp.building;
                rd.Address = temp.address;
                rd.Ptid = temp.ptid;
                rd.Mtid = temp.mtid;
                rd.Isused = temp.isused;
                rd.Cate = temp.cate;
                rd.Type = temp.type;
                rd.Manager = temp.manager;
                rd.HOST_CODE = temp.HOST_CODE;
                rd.PASSWD = temp.PASSWD;
                rd.ACTIVE = temp.ACTIVE;

                return rd;
            }
            catch
            {
                return null;
            }
        }

        public IList<LanData> SELECT_ALL()
        {
            try
            {
                IList<LanData> result = new List<LanData>();
                var temp = (from row in db.U_landata orderby row.areaid ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanData element = new LanData();

                    element.ID = temp.Current.id;
                    element.AreaData = temp.Current.areaid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Building = temp.Current.building;
                    element.Address = temp.Current.address;
                    element.Ptid = temp.Current.ptid;
                    element.Mtid = temp.Current.mtid;
                    element.Isused = temp.Current.isused;
                    element.Cate = temp.Current.cate;
                    element.Type = temp.Current.type;
                    element.Manager = temp.Current.manager;
                    element.HOST_CODE = temp.Current.HOST_CODE;
                    element.PASSWD = temp.Current.PASSWD;
                    element.ACTIVE = temp.Current.ACTIVE;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public IList<LanData> SELECT_ISUSED(bool isused)
        {
            try
            {
                IList<LanData> result = new List<LanData>();
                var temp = (from row in db.U_landata where row.isused == isused orderby row.id ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanData element = new LanData();

                    element.ID = temp.Current.id;
                    element.AreaData = temp.Current.areaid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Building = temp.Current.building;
                    element.Address = temp.Current.address;
                    element.Ptid = temp.Current.ptid;
                    element.Mtid = temp.Current.mtid;
                    element.Isused = temp.Current.isused;
                    element.Cate = temp.Current.cate;
                    element.Type = temp.Current.type;
                    element.Manager = temp.Current.manager;
                    element.HOST_CODE = temp.Current.HOST_CODE;
                    element.PASSWD = temp.Current.PASSWD;
                    element.ACTIVE = temp.Current.ACTIVE;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public IList<LanData> SELECT_BY_AREAID(short areaid, bool isused)
        {
            try
            {
                IList<LanData> result = new List<LanData>();
                var temp = (from row in db.U_landata where row.areaid == areaid && row.isused == isused orderby row.id ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanData element = new LanData();

                    element.ID = temp.Current.id;
                    element.AreaData = temp.Current.areaid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Building = temp.Current.building;
                    element.Address = temp.Current.address;
                    element.Ptid = temp.Current.ptid;
                    element.Mtid = temp.Current.mtid;
                    element.Isused = temp.Current.isused;
                    element.Cate = temp.Current.cate;
                    element.Type = temp.Current.type;
                    element.Manager = temp.Current.manager;
                    element.HOST_CODE = temp.Current.HOST_CODE;
                    element.PASSWD = temp.Current.PASSWD;
                    element.ACTIVE = temp.Current.ACTIVE;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public IList<LanData> SELECT_LIKE_NAME_AID(string name, short aid, bool isused)
        {
            try
            {
                IList<LanData> result = new List<LanData>();
                var temp = (from row in db.U_landata where row.building.Contains(name) && row.areaid == aid && row.isused == isused orderby row.building ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanData element = new LanData();

                    element.ID = temp.Current.id;
                    element.AreaData = temp.Current.areaid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Building = temp.Current.building;
                    element.Address = temp.Current.address;
                    element.Ptid = temp.Current.ptid;
                    element.Mtid = temp.Current.mtid;
                    element.Isused = temp.Current.isused;
                    element.Cate = temp.Current.cate;
                    element.Type = temp.Current.type;
                    element.Manager = temp.Current.manager;
                    element.HOST_CODE = temp.Current.HOST_CODE;
                    element.PASSWD = temp.Current.PASSWD;
                    element.ACTIVE = temp.Current.ACTIVE;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public IList<LanData> SELECT_LIKE_NAME(string name, bool isused)
        {
            try
            {
                IList<LanData> result = new List<LanData>();
                var temp = (from row in db.U_landata where row.building.Contains(name) && row.isused == isused orderby row.building ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanData element = new LanData();

                    element.ID = temp.Current.id;
                    element.AreaData = temp.Current.areaid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Building = temp.Current.building;
                    element.Address = temp.Current.address;
                    element.Ptid = temp.Current.ptid;
                    element.Mtid = temp.Current.mtid;
                    element.Isused = temp.Current.isused;
                    element.Cate = temp.Current.cate;
                    element.Type = temp.Current.type;
                    element.Manager = temp.Current.manager;
                    element.HOST_CODE = temp.Current.HOST_CODE;
                    element.PASSWD = temp.Current.PASSWD;
                    element.ACTIVE = temp.Current.ACTIVE;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public IList<LanData> SELECT_BY_MTID(short mtid, bool isused)
        {
            try
            {
                IList<LanData> result = new List<LanData>();
                var temp = (from row in db.U_landata where row.mtid == mtid && row.isused == isused orderby row.building ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanData element = new LanData();

                    element.ID = temp.Current.id;
                    element.AreaData = temp.Current.areaid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Building = temp.Current.building;
                    element.Address = temp.Current.address;
                    element.Ptid = temp.Current.ptid;
                    element.Mtid = temp.Current.mtid;
                    element.Isused = temp.Current.isused;
                    element.Cate = temp.Current.cate;
                    element.Type = temp.Current.type;
                    element.Manager = temp.Current.manager;
                    element.HOST_CODE = temp.Current.HOST_CODE;
                    element.PASSWD = temp.Current.PASSWD;
                    element.ACTIVE = temp.Current.ACTIVE;

                    result.Add(element);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public IList<LanData> SELECT_BY_PTID(short ptid, bool isused)
        {
            try
            {
                IList<LanData> result = new List<LanData>();
                var temp = (from row in db.U_landata where row.ptid == ptid && row.isused == isused orderby row.building ascending select row).GetEnumerator();
                while (temp.MoveNext())
                {
                    LanData element = new LanData();

                    element.ID = temp.Current.id;
                    element.AreaData = temp.Current.areaid;
                    element.Lng = temp.Current.lng;
                    element.Lat = temp.Current.lat;
                    element.Building = temp.Current.building;
                    element.Address = temp.Current.address;
                    element.Ptid = temp.Current.ptid;
                    element.Mtid = temp.Current.mtid;
                    element.Isused = temp.Current.isused;
                    element.Cate = temp.Current.cate;
                    element.Type = temp.Current.type;
                    element.Manager = temp.Current.manager;
                    element.HOST_CODE = temp.Current.HOST_CODE;
                    element.PASSWD = temp.Current.PASSWD;
                    element.ACTIVE = temp.Current.ACTIVE;

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
