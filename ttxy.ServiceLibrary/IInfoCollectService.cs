using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

using ttxy.Model;

namespace ttxy.Host
{
    //JSON传输
    [ServiceContract]
    public interface IttxyServiceJson
    {
        [OperationContract(Name = "echoJson")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "echo/{Message}", BodyStyle = WebMessageBodyStyle.Bare)]
        string echo (string Message);

        [OperationContract(Name = "loginJson")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "login/{Usn}/{Pwd}", BodyStyle = WebMessageBodyStyle.Bare)]
        Members login(string Usn, string Pwd);

        [OperationContract(Name = "getbuildingsJson")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "geb/{mid}", BodyStyle = WebMessageBodyStyle.Bare)]
        IList<LanData> getbuildings(string mid);

        [OperationContract(Name = "getlevelsJson")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "gel/{lid}", BodyStyle = WebMessageBodyStyle.Bare)]
        IList<NodeData> getlevels(string lid);

        [OperationContract(Name = "getequipsJson")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "gee/{nid}", BodyStyle = WebMessageBodyStyle.Bare)]
        IList<EquipData> getequips(string nid);
    }

    //XML传输
    [ServiceContract]
    public interface IttxyServiceXml
    {
        [OperationContract(Name = "echoXml")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "echo/{Message}", BodyStyle = WebMessageBodyStyle.Bare)]
        string echo (string Message);

        [OperationContract(Name = "loginXml")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "login/{Usn}/{Pwd}", BodyStyle = WebMessageBodyStyle.Bare)]
        Members login(string Usn, string Pwd);

        [OperationContract(Name = "getbuildingsXml")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "geb/{mid}", BodyStyle = WebMessageBodyStyle.Bare)]
        IList<LanData> getbuildings(string mid);

        [OperationContract(Name = "getlevelsXml")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "gel/{lid}", BodyStyle = WebMessageBodyStyle.Bare)]
        IList<NodeData> getlevels(string lid);

        [OperationContract(Name = "getequipsXml")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "gee/{nid}", BodyStyle = WebMessageBodyStyle.Bare)]
        IList<EquipData> getequips(string nid);
    }
}
