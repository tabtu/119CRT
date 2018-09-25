using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

using ttxy.Model;
using ttxy.DAL;

namespace ttxy.BLL
{
    public class DataImport
    {
        /// <summary>
        /// 导入XML文档数据
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="lan"></param>
        /// <returns></returns>
        public bool ImportXml(string filename, LanData lan)
        {
            try
            {
                DNodeData dnd = new DNodeData();
                DEquipData ded = new DEquipData();
                XmlDocument doc = new XmlDocument();
                doc.Load(StrUtil.upload + filename);
                //doc.Load("H:\\Users\\ttxy\\Desktop\\LanMap\\WebSite\\Upload\\map\\凯宾斯基.xml");
                XmlElement rootElem = doc.DocumentElement;
                XmlNodeList pronodes = rootElem.GetElementsByTagName("project");
                for (int i = 0; i < pronodes.Count; i++)
                {
                    string pro = ((XmlElement)pronodes[i]).GetAttribute("name");
                    if (lan.Building != pro)
                    {
                        //Console.WriteLine(pro);
                        return false;
                    }
                    XmlNodeList lnodes = pronodes[i].ChildNodes;
                    for (int j = 0; j < lnodes.Count; j++)
                    {
                        string zone = ((XmlElement)lnodes[j]).GetAttribute("name");
                        //Console.WriteLine(zone);

                        NodeData nd = new NodeData();
                        nd.Lid = lan.ID;
                        nd.PicName = zone;
                        nd.Mainmap = false;
                        nd.PicDescription = ((XmlElement)lnodes[j]).GetAttribute("picpath");
                        nd.PicPath = pro + zone;
                        nd.Sort = 32767;
                        nd.Description = ((XmlElement)lnodes[j]).GetAttribute("description");
                        nd.Isused = true;
                        int nid = dnd.INSERT(nd);

                        XmlNodeList enodes = lnodes[j].ChildNodes;
                        foreach (XmlNode enode in enodes)
                        {
                            string devicenumber = ((XmlElement)enode).GetAttribute("devicenumber");
                            //Console.Write(devicenumber);

                            EquipData ed = new EquipData();
                            ed.Nid = nid;
                            ed.Logicid = devicenumber;
                            ed.Status = 1;
                            ed.Type = short.Parse(((XmlElement)enode).GetAttribute("deviceTypeid"));
                            ed.Url = "";
                            ed.X = short.Parse(((XmlElement)enode).GetAttribute("left"));
                            ed.Y = short.Parse(((XmlElement)enode).GetAttribute("top"));
                            ed.Description = (((XmlElement)enode).GetAttribute("mark"));
                            ed.Isused = true;
                            ded.INSERT(ed);


                        }
                    }

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
